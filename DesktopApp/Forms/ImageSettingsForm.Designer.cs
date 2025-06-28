using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    partial class ImageSettingsForm
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
            this.lblTitle = new Label();
            this.lblDefaultPath = new Label();
            this.chkUseCustomPath = new CheckBox();
            this.lblCustomPath = new Label();
            this.txtCustomPath = new TextBox();
            this.btnBrowse = new Button();
            this.lblCurrentPath = new Label();
            this.lblPathStatus = new Label();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.btnReset = new Button();
            this.SuspendLayout();
            
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(120, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Image storage settings";
            
            // 
            // lblDefaultPath
            // 
            this.lblDefaultPath.AutoSize = true;
            this.lblDefaultPath.Location = new Point(20, 60);
            this.lblDefaultPath.Name = "lblDefaultPath";
            this.lblDefaultPath.Size = new Size(200, 13);
            this.lblDefaultPath.TabIndex = 1;
            this.lblDefaultPath.Text = "Default path:";
            
            // 
            // chkUseCustomPath
            // 
            this.chkUseCustomPath.AutoSize = true;
            this.chkUseCustomPath.Location = new Point(20, 90);
            this.chkUseCustomPath.Name = "chkUseCustomPath";
            this.chkUseCustomPath.Size = new Size(120, 17);
            this.chkUseCustomPath.TabIndex = 2;
            this.chkUseCustomPath.Text = "Use custom paths";
            this.chkUseCustomPath.UseVisualStyleBackColor = true;
            this.chkUseCustomPath.CheckedChanged += new System.EventHandler(this.chkUseCustomPath_CheckedChanged);
            
            // 
            // lblCustomPath
            // 
            this.lblCustomPath.AutoSize = true;
            this.lblCustomPath.Location = new Point(40, 120);
            this.lblCustomPath.Name = "lblCustomPath";
            this.lblCustomPath.Size = new Size(67, 13);
            this.lblCustomPath.TabIndex = 3;
            this.lblCustomPath.Text = "Custom path:";
            
            // 
            // txtCustomPath
            // 
            this.txtCustomPath.Location = new Point(40, 140);
            this.txtCustomPath.Name = "txtCustomPath";
            this.txtCustomPath.Size = new Size(350, 20);
            this.txtCustomPath.TabIndex = 4;
            this.txtCustomPath.TextChanged += new System.EventHandler(this.txtCustomPath_TextChanged);
            
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new Point(400, 138);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new Size(75, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            
            // 
            // lblCurrentPath
            // 
            this.lblCurrentPath.AutoSize = true;
            this.lblCurrentPath.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.lblCurrentPath.Location = new Point(20, 180);
            this.lblCurrentPath.Name = "lblCurrentPath";
            this.lblCurrentPath.Size = new Size(200, 13);
            this.lblCurrentPath.TabIndex = 6;
            this.lblCurrentPath.Text = "Current use:";
            
            // 
            // lblPathStatus
            // 
            this.lblPathStatus.AutoSize = true;
            this.lblPathStatus.Location = new Point(40, 200);
            this.lblPathStatus.Name = "lblPathStatus";
            this.lblPathStatus.Size = new Size(0, 13);
            this.lblPathStatus.TabIndex = 7;
            
            // 
            // btnOK
            // 
            this.btnOK.Location = new Point(240, 240);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Sure";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(330, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // 
            // btnReset
            // 
            this.btnReset.Location = new Point(420, 240);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            
            // 
            // ImageSettingsForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(520, 290);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblPathStatus);
            this.Controls.Add(this.lblCurrentPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtCustomPath);
            this.Controls.Add(this.lblCustomPath);
            this.Controls.Add(this.chkUseCustomPath);
            this.Controls.Add(this.lblDefaultPath);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageSettingsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Image storage settings";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        #endregion
        
        private Label lblTitle;
        private Label lblDefaultPath;
        private CheckBox chkUseCustomPath;
        private Label lblCustomPath;
        private TextBox txtCustomPath;
        private Button btnBrowse;
        private Label lblCurrentPath;
        private Label lblPathStatus;
        private Button btnOK;
        private Button btnCancel;
        private Button btnReset;
    }
}