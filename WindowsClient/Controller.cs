﻿namespace EyePaint
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Tobii.Gaze.Core;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class EyeTrackingForm : Form
    {
        private readonly EyeTrackingEngine _eyeTrackingEngine; //TODO Remove underscore. Silly naming convention with an IDE.
        private Point _gazePoint; //TODO Remove underscore. Silly naming convention with an IDE.
        private bool gazeFixed;
        private TreeFactory treeFactory;
        private ImageFactory imageFactory;
        private bool useMouse;
        private Timer paint;
        private Color currentColor;
        private readonly Color DEFAULT_COLOR = Color.Crimson;
        private delegate void UpdateStateDelegate(EyeTrackingStateChangedEventArgs eyeTrackingStateChangedEventArgs);

        public EyeTrackingForm(EyeTrackingEngine eyeTrackingEngine)
        {
            InitializeComponent();
            Shown += OnShown;
            Paint += OnPaint;
            Move += OnMove;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
            MouseMove += OnMouseMove;
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;

            _eyeTrackingEngine = eyeTrackingEngine;
            _eyeTrackingEngine.StateChanged += StateChanged;
            _eyeTrackingEngine.GazePoint += GazePoint;
            _eyeTrackingEngine.Initialize();

            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
            imageFactory = new ImageFactory(width, height);
            treeFactory = new TreeFactory();

            currentColor = DEFAULT_COLOR;

            paint = new System.Windows.Forms.Timer();
            paint.Interval = 33;
            paint.Enabled = false;
            paint.Tick += new EventHandler((object sender, System.EventArgs e) => { treeFactory.ExpandTree(); Invalidate(); });
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    OnGreenButtonUp(sender, e); // Simulate event. TODO Stop doing this.
                    break;
                default:
                    break;
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    OnGreenButtonDown(sender, e); // Simulate event. TODO Stop doing this.
                    break;
                default:
                    break;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (useMouse && !gazeFixed)
                _gazePoint = new Point(e.X, e.Y);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    OnGreenButtonDown(sender, e); // Simulate event. TODO Stop doing this.
                    break;
                case Keys.Back:
                    OnRedButtonDown(sender, e); // Simulate event. TODO Stop doing this.
                    break;
                case Keys.R:
                    currentColor = Color.Crimson;
                    break;
                case Keys.G:
                    currentColor = Color.ForestGreen;
                    break;
                case Keys.B:
                    currentColor = Color.CornflowerBlue;
                    break;
                case Keys.Enter:
                    StorePaintingAsFile();
                    break;
                default:
                    break;
            }
        }

        private void StorePaintingAsFile()
        {
            //TODO Call Henrik's IO library.
            throw new NotImplementedException();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    OnGreenButtonUp(sender, e); // Simulate event. TODO Stop doing this.
                    break;
                case Keys.Back:
                    OnRedButtonUp(sender, e); // Simulate event. TODO Stop doing this.
                    break;
                default:
                    break;
            }
        }

        private void OnGreenButtonDown(object sender, EventArgs e)
        {
            gazeFixed = true;
            if (!paint.Enabled)
                treeFactory.CreateTree(PointToClient(_gazePoint), currentColor);
            paint.Enabled = true;
        }


        private void OnGreenButtonUp(object sender, EventArgs e)
        {
            gazeFixed = false;
            paint.Enabled = false;
        }

        private void OnRedButtonDown(object sender, EventArgs e)
        {
            imageFactory.Undo();
            Invalidate();
        }

        private void OnRedButtonUp(object sender, EventArgs e)
        {
            //TODO Define button behaviour.
        }

        private void OnMove(object sender, EventArgs e)
        {
            WarnIfOutsideEyeTrackingScreenBounds(); //TODO Neccessary?
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            try
            {
                var trees = treeFactory.trees;
                Image image = imageFactory.RasterizeTrees(ref trees);
                e.Graphics.DrawImageUnscaled(image, new Point(0, 0));
            }
            catch (InvalidOperationException)
            {
                return;
            }
        }

        private void GazePoint(object sender, GazePointEventArgs e)
        {
            //TODO Add noise reduction and calibration.
            if (!gazeFixed)
                _gazePoint = new Point(e.X, e.Y);
        }

        private void OnShown(object sender, EventArgs e)
        {
            WarnIfOutsideEyeTrackingScreenBounds();
            BringToFront();
        }

        private void StateChanged(object sender, EyeTrackingStateChangedEventArgs e)
        {
            // Forward state change to UI thread
            if (InvokeRequired)
            {
                var updateStateDelegate = new UpdateStateDelegate(UpdateState);
                Invoke(updateStateDelegate, new object[] { e });
            }
            else
            {
                UpdateState(e);
            }
        }

        private void UpdateState(EyeTrackingStateChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.ErrorMessage))
            {
                InfoMessage.Visible = false;
                ErrorMessagePanel.Visible = true;
                ErrorMessage.Text = e.ErrorMessage;
                Resolve.Enabled = e.CanResolve;
                Retry.Enabled = e.CanRetry;
                return;
            }

            ErrorMessagePanel.Visible = false;

            if (e.EyeTrackingState != EyeTrackingState.Tracking)
            {
                InfoMessage.Visible = true;
                InfoMessage.Text = "Connecting to eye tracker, please wait...";
            }
            else
            {
                InfoMessage.Visible = false;
            }
        }

        private void OpenControlPanelClick(object sender, EventArgs e)
        {
            _eyeTrackingEngine.ResolveError();
        }

        private void RetryClick(object sender, EventArgs e)
        {
            _eyeTrackingEngine.Retry();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void WarnIfOutsideEyeTrackingScreenBounds()
        {
            var screenBounds = _eyeTrackingEngine.EyeTrackingScreenBounds;

            if (screenBounds.HasValue && (Bounds.Left > screenBounds.Value.Right || Bounds.Right < screenBounds.Value.X))
            {
                InfoMessage.Visible = true;
                InfoMessage.Text = "Warning!! Application window is outside of tracking area";
                InfoMessage.BringToFront();
            }
            else
            {
                InfoMessage.Visible = false;
            }
        }

        private void EnableMouseClick(object sender, EventArgs e)
        {
            useMouse = true;
            ErrorMessagePanel.Visible = false;
        }
    }
}
