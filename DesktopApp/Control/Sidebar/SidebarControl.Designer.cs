using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DesktopApp.Control.Sidebar._components;

namespace DesktopApp.Control.Sidebar
{
    partial class SidebarControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logoControl = new LogoControl();
            this.menuPanel = new Panel();
            this.SuspendLayout();
            // 
            // logoControl
            // 
            this.logoControl.Dock = DockStyle.Top;
            this.logoControl.Location = new Point(0, 0);
            this.logoControl.Name = "logoControl";
            this.logoControl.Size = new Size(250, 80);
            this.logoControl.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = Color.FromArgb(35, 35, 35);
            this.menuPanel.Dock = DockStyle.Fill;
            this.menuPanel.Location = new Point(0, 100);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new Size(250, 400);
            this.menuPanel.TabIndex = 1;
            // 
            // SidebarControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(45, 45, 45);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.logoControl);
            this.Name = "SidebarControl";
            this.Size = new Size(250, 600);
            this.ResumeLayout(false);
        }

        #endregion

        private LogoControl logoControl;
        private Panel menuPanel;
    }
}