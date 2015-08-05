﻿using FlickrNet;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EyePaint
{
  /// <summary>
  /// Stores the input bitmap to disk, uploads it to Flickr and displays the Flickr URL to the image as a QR code.
  /// </summary>
  public partial class PublishWindow : Window
  {
    BackgroundWorker bw;

    public PublishWindow(Window owner, RenderTargetBitmap drawing)
    {
      InitializeComponent();
      Owner = owner;
      Show();
      saveImage(drawing, "drawing.png");
      flickrUploadImage("drawing.png");
      //(App.Current as App).Globals.IsResettable = false;
    }

    /// <summary>
    /// Save drawing to file system.
    /// </summary>
    void saveImage(RenderTargetBitmap drawing, String imageDestinationPath)
    {
      try
      {
        var pbe = new PngBitmapEncoder();
        pbe.Frames.Add(BitmapFrame.Create(drawing));
        using (var fs = System.IO.File.OpenWrite(imageDestinationPath)) pbe.Save(fs);
      }
      catch (Exception ex)
      {
        (App.Current as App).SendErrorReport("(EyePaint) Image Saving Error", "An image could not be saved. Check if another program on the computer is using the image. Error: " + ex.Message);
        new ErrorWindow();
      }
    }

    /// <summary>
    /// Upload image to Flickr.
    /// </summary>
    void flickrUploadImage(String pathToImage)
    {
      try
      {
        bw = new BackgroundWorker();
        var photoId = "";
        bw.WorkerReportsProgress = true;
        bw.ProgressChanged += (_s, _e) => UploadProgress.Value = _e.ProgressPercentage;
        bw.DoWork += (_s, _e) =>
        {
          // Login
          var f = new Flickr(Properties.Settings.Default.FlickrKey, Properties.Settings.Default.FlickrSecret);
          f.OAuthAccessToken = Properties.Settings.Default.FlickrAccessToken.Token;
          f.OAuthAccessTokenSecret = Properties.Settings.Default.FlickrAccessToken.TokenSecret;

          // Upload photo.
          f.OnUploadProgress += (__s, __e) => bw.ReportProgress(__e.ProcessPercentage);
          photoId = f.UploadPicture("drawing.png", Properties.Settings.Default.FlickrTitle, Properties.Settings.Default.FlickrDescription, Properties.Settings.Default.FlickrTags, true, true, true);

          //TODO Handle exceptions
          // Add photo to set. If set doesn'strokeDuration exist, create it first.
          var photosets = f.PhotosetsGetList().Where(set => set.Title == Properties.Settings.Default.FlickrPhotoset).ToList();
          if (photosets.Count == 0) f.PhotosetsCreate(Properties.Settings.Default.FlickrPhotoset, photoId);
          else f.PhotosetsAddPhoto(photosets[0].PhotosetId, photoId);
        };
        bw.RunWorkerCompleted += (_s, _e) =>
        {
          // Hide progress bar upon completion.
          UploadProgress.Visibility = Visibility.Hidden;

          // Shortened URL to drawing on Flickr.
          var shortPhotoId = Base58Encoder.Encode(ulong.Parse(photoId));
          var url = "http://flic.kr/center/" + shortPhotoId;

          // Create and display URL as text and QR code.
          QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
          QrCode qrCode = qrEncoder.Encode(url);
          Renderer r = new Renderer(5);
          var size = r.Measure(qrCode.Matrix.Width);
          var rtb = new RenderTargetBitmap(size, size, 96, 96, PixelFormats.Pbgra32);
          DrawingVisual dv = new DrawingVisual();
          using (DrawingContext dc = dv.RenderOpen()) r.Draw(dc, qrCode.Matrix);
          rtb.Render(dv);
          UploadQR.Source = rtb;
          UploadURL.Text = shortPhotoId;
          (App.Current as App).Globals.IsResettable = true;
        };
        bw.RunWorkerAsync();
      }
      catch (Exception ex)
      {
        (App.Current as App).SendErrorReport("(EyePaint) Image Upload Error", "An image could not be uploaded. Check if Flickr is authenticated in the program settings. To see the program settings press escape at the calibration screen. The drawing is stored in the program folder and could be manually recovered before a new drawing is made. Error: " + ex.Message);
        new ErrorWindow();
      }
    }
  }
}
