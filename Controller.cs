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
        private Random rng;
        private readonly EyeTrackingEngine _eyeTrackingEngine; //TODO Remove underscore. Silly naming convention with an IDE.
        private Point gazePoint;
        private Point latestPoint;
        private bool stableGaze;
        private int keyhole = 120; // constant for gazePoint noise detection
        private bool greenButtonPressed;
        private BaseFactory factory;
        private BaseRasterizer rasterizer;
        private bool useMouse;
        private Timer paint;
        private Color currentColor;
        private readonly Color DEFAULT_COLOR = Color.Crimson;
        private bool CHANGE_TOOL_RANDOMLY_EACH_NEW_STROKE = true;
        private bool CHANGE_TOOL_RANDOMLY_CONSTANTLY = false;
        private bool treeMode = true;
        private bool cloudMode = false;
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
            _eyeTrackingEngine.GazePoint += OnGazePoint;
            _eyeTrackingEngine.Initialize();

            stableGaze = false;
            greenButtonPressed = false;
            gazePoint = new Point(0, 0);
            latestPoint = new Point(0, 0);
            rng = new Random();
            currentColor = DEFAULT_COLOR;

            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            if (treeMode)
            {
                rasterizer = new TreeRasterizer(width, height);
                factory = new TreeFactory();
            }
            else if (cloudMode)
            {
                rasterizer = new CloudRasterizer(width, height);
                factory = new CloudFactory();
            }

            paint = new System.Windows.Forms.Timer();
            paint.Interval = 33;
            paint.Enabled = false;
            paint.Tick += onTick;
        }

        // Grows the model and refreshes the canvas
        private void onTick(object sender, System.EventArgs e)
        {
            factory.Grow();
            Invalidate();

            if (CHANGE_TOOL_RANDOMLY_CONSTANTLY)
                setRandomPaintTool();
        }

        // Starts the timer, enabling tick events
        private void startPaintingTimer()
        {
            if (paint.Enabled)
                return;

            if (!stableGaze)
                return;

            if (CHANGE_TOOL_RANDOMLY_EACH_NEW_STROKE)
                setRandomPaintTool();

            paint.Enabled = true;
        }

        // Stops the timer, disabling tick events
        private void stopPaintingTimer()
        {
            paint.Enabled = false;
        }

        // Rasterizes the model and returns an image object
        private Image getPainting()
        {
            Image image = rasterizer.Rasterize(factory);
            return image;
        }

        // Clears the canvas
        private void resetPainting()
        {
            rasterizer.Undo();
            Invalidate();
        }

        private void setRandomPaintTool()
        {
            //TODO Set more settings randomly than just the tool color.
            currentColor = Color.FromArgb(55 + rng.Next(200), rng.Next(255), rng.Next(255), rng.Next(255));
        }

        // Writes rasterized image to a file
        private void storePainting()
        {
            Image image = getPainting();
            image.Save("painting.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (useMouse)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        OnGreenButtonUp(sender, e);
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (useMouse)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        OnGreenButtonDown(sender, e);
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    OnGreenButtonDown(sender, e);
                    break;
                case Keys.Back:
                    OnRedButtonDown(sender, e);
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
                case Keys.S:
                    storePainting();
                    break;
                default:
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    OnGreenButtonUp(sender, e);
                    break;
                case Keys.Back:
                    OnRedButtonUp(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void OnGreenButtonDown(object sender, EventArgs e)
        {
            if (greenButtonPressed) {
                return;
            }

            greenButtonPressed = true;
            gazePoint = latestPoint;
            AddPoint(gazePoint, true);
            startPaintingTimer();
        }

        private void OnGreenButtonUp(object sender, EventArgs e)
        {
            greenButtonPressed = false;
            gazePoint = latestPoint;
            stopPaintingTimer();
        }

        private void OnRedButtonDown(object sender, EventArgs e)
        {
            resetPainting();
        }

        private void OnRedButtonUp(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnMove(object sender, EventArgs e)
        {
            WarnIfOutsideEyeTrackingScreenBounds(); //TODO Neccessary?
            stableGaze = false; // TODO Neccessary?
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Image image = getPainting();
            if (image != null)
            {
                e.Graphics.DrawImageUnscaled(image, new Point(0, 0));
            }
        }

        // Adds a new point to the model
        private void AddPoint(Point p, bool alwaysAdd = false)
        {
            factory.Add(p, currentColor, alwaysAdd);
        }

        // Stores a new point in 'latestPoint' and determines whether or not to add it
        private void TrackPoint(Point p)
        {
            stableGaze = true;
            latestPoint = p;

            double distance = Math.Sqrt(Math.Pow(gazePoint.X - p.X, 2) + Math.Pow(gazePoint.Y - p.Y, 2));

            if (distance > keyhole)
            {
                gazePoint = p;
                if (greenButtonPressed)
                {
                    AddPoint(gazePoint);
                }
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (useMouse)
            {
                Point p = new Point(e.X, e.Y);
                TrackPoint(p);
            }
        }

        private void OnGazePoint(object sender, GazePointEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            TrackPoint(p);
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
