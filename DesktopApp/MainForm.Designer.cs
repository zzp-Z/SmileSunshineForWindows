using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DesktopApp.Control.Sidebar;

namespace DesktopApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.sidebarControl = new SidebarControl();
            this.mainContentPanel = new Panel();
            this.SuspendLayout();
            // 
            // sidebarControl
            // 
            this.sidebarControl.Dock = DockStyle.Left;
            this.sidebarControl.Location = new Point(0, 0);
            this.sidebarControl.Name = "sidebarControl";
            this.sidebarControl.Size = new Size(250, 450);
            this.sidebarControl.TabIndex = 0;
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.Dock = DockStyle.Fill;
            this.mainContentPanel.Location = new Point(250, 0);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new Size(550, 450);
            this.mainContentPanel.TabIndex = 1;
            this.mainContentPanel.BackColor = Color.White;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.sidebarControl);
            this.Name = "MainForm";
            this.Text = "Smile Sunshine";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        #endregion

        private SidebarControl sidebarControl;
        private Panel mainContentPanel;
    }
}