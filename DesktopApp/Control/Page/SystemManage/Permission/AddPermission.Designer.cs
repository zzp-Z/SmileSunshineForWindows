using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.SystemManage.Permission
{
    partial class AddPermission
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
            this.lblPermissionName = new Label();
            this.txtPermissionName = new TextBox();
            this.lblApiPath = new Label();
            this.txtApiPath = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // 
            // lblPermissionName
            // 
            this.lblPermissionName.AutoSize = true;
            this.lblPermissionName.Location = new Point(30, 30);
            this.lblPermissionName.Name = "lblPermissionName";
            this.lblPermissionName.Size = new Size(65, 12);
            this.lblPermissionName.TabIndex = 0;
            this.lblPermissionName.Text = "Permission Name：";
            // 
            // txtPermissionName
            // 
            this.txtPermissionName.Location = new Point(100, 27);
            this.txtPermissionName.Name = "txtPermissionName";
            this.txtPermissionName.Size = new Size(250, 21);
            this.txtPermissionName.TabIndex = 1;
            // 
            // lblApiPath
            // 
            this.lblApiPath.AutoSize = true;
            this.lblApiPath.Location = new Point(30, 70);
            this.lblApiPath.Name = "lblApiPath";
            this.lblApiPath.Size = new Size(59, 12);
            this.lblApiPath.TabIndex = 2;
            this.lblApiPath.Text = "API Path：";
            // 
            // txtApiPath
            // 
            this.txtApiPath.Location = new Point(100, 67);
            this.txtApiPath.Name = "txtApiPath";
            this.txtApiPath.Size = new Size(250, 21);
            this.txtApiPath.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(30, 110);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(41, 12);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description：";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new Point(100, 107);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new Size(250, 80);
            this.txtDescription.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(100, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(75, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(200, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddPermission
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new Size(400, 300);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtApiPath);
            this.Controls.Add(this.lblApiPath);
            this.Controls.Add(this.txtPermissionName);
            this.Controls.Add(this.lblPermissionName);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPermission";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add Permission";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblPermissionName;
        private TextBox txtPermissionName;
        private Label lblApiPath;
        private TextBox txtApiPath;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;
    }
}