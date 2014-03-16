﻿namespace EyePaint
{
    partial class EyePaintingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        System.ComponentModel.IContainer components = null;

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
        void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EyePaintingForm));
            this.ProgramControlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NewSessionButton = new System.Windows.Forms.Button();
            this.SavePaintingButton = new System.Windows.Forms.Button();
            this.ClearPaintingButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.ToolButton = new System.Windows.Forms.Button();
            this.PaintToolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ColorToolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.ProgramControlPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgramControlPanel
            // 
            this.ProgramControlPanel.AutoSize = true;
            this.ProgramControlPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProgramControlPanel.BackColor = System.Drawing.Color.Transparent;
            this.ProgramControlPanel.Controls.Add(this.NewSessionButton);
            this.ProgramControlPanel.Controls.Add(this.SavePaintingButton);
            this.ProgramControlPanel.Controls.Add(this.ClearPaintingButton);
            this.ProgramControlPanel.Controls.Add(this.ColorButton);
            this.ProgramControlPanel.Controls.Add(this.ToolButton);
            this.ProgramControlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProgramControlPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ProgramControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ProgramControlPanel.Name = "ProgramControlPanel";
            this.ProgramControlPanel.Size = new System.Drawing.Size(750, 150);
            this.ProgramControlPanel.TabIndex = 0;
            // 
            // NewSessionButton
            // 
            this.NewSessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewSessionButton.AutoSize = true;
            this.NewSessionButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.NewSessionButton.FlatAppearance.BorderSize = 10;
            this.NewSessionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewSessionButton.Image = ((System.Drawing.Image)(resources.GetObject("NewSessionButton.Image")));
            this.NewSessionButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewSessionButton.Location = new System.Drawing.Point(0, 0);
            this.NewSessionButton.Margin = new System.Windows.Forms.Padding(0);
            this.NewSessionButton.Name = "NewSessionButton";
            this.NewSessionButton.Size = new System.Drawing.Size(150, 150);
            this.NewSessionButton.TabIndex = 0;
            this.NewSessionButton.TabStop = false;
            this.NewSessionButton.Click += new System.EventHandler(this.onButtonClicked);
            this.NewSessionButton.Enter += new System.EventHandler(this.onButtonFocus);
            this.NewSessionButton.Leave += new System.EventHandler(this.onButtonBlur);
            // 
            // SavePaintingButton
            // 
            this.SavePaintingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePaintingButton.AutoSize = true;
            this.SavePaintingButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SavePaintingButton.FlatAppearance.BorderSize = 10;
            this.SavePaintingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SavePaintingButton.Image = ((System.Drawing.Image)(resources.GetObject("SavePaintingButton.Image")));
            this.SavePaintingButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SavePaintingButton.Location = new System.Drawing.Point(150, 0);
            this.SavePaintingButton.Margin = new System.Windows.Forms.Padding(0);
            this.SavePaintingButton.Name = "SavePaintingButton";
            this.SavePaintingButton.Size = new System.Drawing.Size(150, 150);
            this.SavePaintingButton.TabIndex = 1;
            this.SavePaintingButton.TabStop = false;
            this.SavePaintingButton.Click += new System.EventHandler(this.onButtonClicked);
            this.SavePaintingButton.Enter += new System.EventHandler(this.onButtonFocus);
            this.SavePaintingButton.Leave += new System.EventHandler(this.onButtonBlur);
            // 
            // ClearPaintingButton
            // 
            this.ClearPaintingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearPaintingButton.AutoSize = true;
            this.ClearPaintingButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ClearPaintingButton.FlatAppearance.BorderSize = 10;
            this.ClearPaintingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearPaintingButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearPaintingButton.Image")));
            this.ClearPaintingButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ClearPaintingButton.Location = new System.Drawing.Point(300, 0);
            this.ClearPaintingButton.Margin = new System.Windows.Forms.Padding(0);
            this.ClearPaintingButton.Name = "ClearPaintingButton";
            this.ClearPaintingButton.Size = new System.Drawing.Size(150, 150);
            this.ClearPaintingButton.TabIndex = 2;
            this.ClearPaintingButton.TabStop = false;
            this.ClearPaintingButton.Click += new System.EventHandler(this.onButtonClicked);
            this.ClearPaintingButton.Enter += new System.EventHandler(this.onButtonFocus);
            this.ClearPaintingButton.Leave += new System.EventHandler(this.onButtonBlur);
            // 
            // ColorButton
            // 
            this.ColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorButton.AutoSize = true;
            this.ColorButton.BackColor = System.Drawing.Color.Transparent;
            this.ColorButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ColorButton.FlatAppearance.BorderSize = 10;
            this.ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorButton.Image = ((System.Drawing.Image)(resources.GetObject("ColorButton.Image")));
            this.ColorButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ColorButton.Location = new System.Drawing.Point(450, 0);
            this.ColorButton.Margin = new System.Windows.Forms.Padding(0);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(150, 150);
            this.ColorButton.TabIndex = 3;
            this.ColorButton.TabStop = false;
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.onButtonClicked);
            this.ColorButton.Enter += new System.EventHandler(this.onButtonFocus);
            this.ColorButton.Leave += new System.EventHandler(this.onButtonBlur);
            // 
            // ToolButton
            // 
            this.ToolButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolButton.AutoSize = true;
            this.ToolButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ToolButton.FlatAppearance.BorderSize = 10;
            this.ToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToolButton.Image = ((System.Drawing.Image)(resources.GetObject("ToolButton.Image")));
            this.ToolButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ToolButton.Location = new System.Drawing.Point(600, 0);
            this.ToolButton.Margin = new System.Windows.Forms.Padding(0);
            this.ToolButton.Name = "ToolButton";
            this.ToolButton.Size = new System.Drawing.Size(150, 150);
            this.ToolButton.TabIndex = 4;
            this.ToolButton.TabStop = false;
            this.ToolButton.Visible = false;
            this.ToolButton.Click += new System.EventHandler(this.onButtonClicked);
            this.ToolButton.Enter += new System.EventHandler(this.onButtonFocus);
            this.ToolButton.Leave += new System.EventHandler(this.onButtonBlur);
            // 
            // PaintToolsPanel
            // 
            this.PaintToolsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PaintToolsPanel.BackColor = System.Drawing.Color.Transparent;
            this.PaintToolsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.PaintToolsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PaintToolsPanel.Location = new System.Drawing.Point(660, 0);
            this.PaintToolsPanel.Name = "PaintToolsPanel";
            this.PaintToolsPanel.Size = new System.Drawing.Size(624, 150);
            this.PaintToolsPanel.TabIndex = 0;
            // 
            // ColorToolsPanel
            // 
            this.ColorToolsPanel.AutoSize = true;
            this.ColorToolsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ColorToolsPanel.BackColor = System.Drawing.Color.Transparent;
            this.ColorToolsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ColorToolsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ColorToolsPanel.Location = new System.Drawing.Point(1284, 0);
            this.ColorToolsPanel.Name = "ColorToolsPanel";
            this.ColorToolsPanel.Size = new System.Drawing.Size(0, 150);
            this.ColorToolsPanel.TabIndex = 4;
            this.ColorToolsPanel.Visible = false;
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.White;
            this.MenuPanel.Controls.Add(this.ProgramControlPanel);
            this.MenuPanel.Controls.Add(this.PaintToolsPanel);
            this.MenuPanel.Controls.Add(this.ColorToolsPanel);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuPanel.MinimumSize = new System.Drawing.Size(642, 150);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(1284, 150);
            this.MenuPanel.TabIndex = 6;
            // 
            // EyePaintingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1284, 780);
            this.ControlBox = false;
            this.Controls.Add(this.MenuPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EyePaintingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ProgramControlPanel.ResumeLayout(false);
            this.ProgramControlPanel.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ProgramControlPanel;
        private System.Windows.Forms.Button NewSessionButton;
        private System.Windows.Forms.Button SavePaintingButton;
        private System.Windows.Forms.Button ClearPaintingButton;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button ToolButton;
        private System.Windows.Forms.FlowLayoutPanel PaintToolsPanel;
        private System.Windows.Forms.FlowLayoutPanel ColorToolsPanel;
        private System.Windows.Forms.Panel MenuPanel;
    }
}

