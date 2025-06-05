using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Sidebar._components
{
    partial class UserInfoControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameLabel = new Label();
            this.positionLabel = new Label();
            this.timeLabel = new Label();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = Color.White;
            this.usernameLabel.Location = new Point(10, 10);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new Size(80, 17);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "用户名";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel.ForeColor = Color.LightGray;
            this.positionLabel.Location = new Point(10, 35);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new Size(44, 15);
            this.positionLabel.TabIndex = 1;
            this.positionLabel.Text = "职位";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = Color.LightGray;
            this.timeLabel.Location = new Point(10, 60);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new Size(100, 13);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "系统时间";
            // 
            // UserInfoControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.timeLabel);
            this.Name = "UserInfoControl";
            this.Size = new Size(250, 100);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label usernameLabel;
        private Label positionLabel;
        private Label timeLabel;
    }
}