﻿namespace EyePaint
{
    partial class EyePaintingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EyePaintingForm));
            this.SetupPanel = new System.Windows.Forms.Panel();
            this.EnableEyeTrackerButton = new System.Windows.Forms.Button();
            this.EnableMouseButton = new System.Windows.Forms.Button();
            this.CloseSetupPanelButton = new System.Windows.Forms.Button();
            this.OpenControlPanelButton = new System.Windows.Forms.Button();
            this.SetupMessage = new System.Windows.Forms.Label();
            this.PaintToolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SetupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetupPanel
            // 
            resources.ApplyResources(this.SetupPanel, "SetupPanel");
            this.SetupPanel.BackColor = System.Drawing.Color.White;
            this.SetupPanel.Controls.Add(this.EnableEyeTrackerButton);
            this.SetupPanel.Controls.Add(this.EnableMouseButton);
            this.SetupPanel.Controls.Add(this.CloseSetupPanelButton);
            this.SetupPanel.Controls.Add(this.OpenControlPanelButton);
            this.SetupPanel.Controls.Add(this.SetupMessage);
            this.SetupPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SetupPanel.Name = "SetupPanel";
            // 
            // EnableEyeTrackerButton
            // 
            this.EnableEyeTrackerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.EnableEyeTrackerButton, "EnableEyeTrackerButton");
            this.EnableEyeTrackerButton.Name = "EnableEyeTrackerButton";
            this.EnableEyeTrackerButton.UseVisualStyleBackColor = true;
            this.EnableEyeTrackerButton.Click += new System.EventHandler(this.UseEyeTrackerClick);
            // 
            // EnableMouseButton
            // 
            this.EnableMouseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.EnableMouseButton, "EnableMouseButton");
            this.EnableMouseButton.Name = "EnableMouseButton";
            this.EnableMouseButton.UseVisualStyleBackColor = true;
            this.EnableMouseButton.Click += new System.EventHandler(this.UseMouseClick);
            // 
            // CloseSetupPanelButton
            // 
            resources.ApplyResources(this.CloseSetupPanelButton, "CloseSetupPanelButton");
            this.CloseSetupPanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseSetupPanelButton.Name = "CloseSetupPanelButton";
            this.CloseSetupPanelButton.UseVisualStyleBackColor = true;
            this.CloseSetupPanelButton.Click += new System.EventHandler(this.CloseSetupPanelClick);
            // 
            // OpenControlPanelButton
            // 
            this.OpenControlPanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.OpenControlPanelButton, "OpenControlPanelButton");
            this.OpenControlPanelButton.Name = "OpenControlPanelButton";
            this.OpenControlPanelButton.UseVisualStyleBackColor = true;
            this.OpenControlPanelButton.Click += new System.EventHandler(this.OpenControlPanelClick);
            // 
            // SetupMessage
            // 
            resources.ApplyResources(this.SetupMessage, "SetupMessage");
            this.SetupMessage.Name = "SetupMessage";
            // 
            // PaintToolsPanel
            // 
            resources.ApplyResources(this.PaintToolsPanel, "PaintToolsPanel");
            this.PaintToolsPanel.BackColor = System.Drawing.Color.Transparent;
            this.PaintToolsPanel.Name = "PaintToolsPanel";
            // 
            // EyePaintingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ControlBox = false;
            this.Controls.Add(this.PaintToolsPanel);
            this.Controls.Add(this.SetupPanel);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "EyePaintingForm";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SetupPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SetupPanel;
        private System.Windows.Forms.Button OpenControlPanelButton;
        private System.Windows.Forms.Label SetupMessage;
        private System.Windows.Forms.Button CloseSetupPanelButton;
        private System.Windows.Forms.Button EnableMouseButton;
        private System.Windows.Forms.Button EnableEyeTrackerButton;
        private System.Windows.Forms.FlowLayoutPanel PaintToolsPanel;
    }
}

