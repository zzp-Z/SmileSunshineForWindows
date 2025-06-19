using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DesktopApp.Control.Sidebar;
using DesktopApp.Control.Sidebar._components;

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
            this.sidebarControl = new DesktopApp.Control.Sidebar.SidebarControl();
            this.userInfoControl = new DesktopApp.Control.Sidebar._components.UserInfoControl();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarControl
            // 
            this.sidebarControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sidebarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarControl.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.sidebarControl.Name = "sidebarControl";
            this.sidebarControl.Width = 500;
            // 
            // userInfoControl
            // 
            this.userInfoControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.userInfoControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.userInfoControl.Location = new System.Drawing.Point(0, 0);
            this.userInfoControl.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.userInfoControl.Name = "userInfoControl";
            this.userInfoControl.Height = 150;
            
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = Color.Red;
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Name = "mainContentPanel";
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.Aqua;
            this.rightPanel.Controls.Add(this.mainContentPanel);
            this.rightPanel.Controls.Add(this.userInfoControl);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rightPanel.Name = "rightPanel";

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 800);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.sidebarControl);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smile Sunshine";
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private SidebarControl sidebarControl;
        private UserInfoControl userInfoControl;
        private System.Windows.Forms.Panel mainContentPanel;
        private Panel rightPanel;
    }
}