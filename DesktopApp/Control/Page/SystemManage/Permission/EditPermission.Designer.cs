using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.SystemManage.Permission
{
    partial class EditPermission
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
            this.lblPermissionName = new System.Windows.Forms.Label();
            this.txtPermissionName = new System.Windows.Forms.TextBox();
            this.lblApiPath = new System.Windows.Forms.Label();
            this.txtApiPath = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPermissionName
            // 
            this.lblPermissionName.AutoSize = true;
            this.lblPermissionName.Location = new System.Drawing.Point(45, 45);
            this.lblPermissionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPermissionName.Name = "lblPermissionName";
            this.lblPermissionName.Size = new System.Drawing.Size(161, 18);
            this.lblPermissionName.TabIndex = 0;
            this.lblPermissionName.Text = "Permission Name：";
            // 
            // txtPermissionName
            // 
            this.txtPermissionName.Location = new System.Drawing.Point(199, 40);
            this.txtPermissionName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPermissionName.Name = "txtPermissionName";
            this.txtPermissionName.Size = new System.Drawing.Size(324, 28);
            this.txtPermissionName.TabIndex = 1;
            // 
            // lblApiPath
            // 
            this.lblApiPath.AutoSize = true;
            this.lblApiPath.Location = new System.Drawing.Point(45, 105);
            this.lblApiPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApiPath.Name = "lblApiPath";
            this.lblApiPath.Size = new System.Drawing.Size(98, 18);
            this.lblApiPath.TabIndex = 2;
            this.lblApiPath.Text = "API Path：";
            // 
            // txtApiPath
            // 
            this.txtApiPath.Location = new System.Drawing.Point(199, 100);
            this.txtApiPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApiPath.Name = "txtApiPath";
            this.txtApiPath.Size = new System.Drawing.Size(324, 28);
            this.txtApiPath.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(45, 165);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(125, 18);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description：";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(199, 160);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(324, 118);
            this.txtDescription.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 330);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 45);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 330);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 45);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EditPermission
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtApiPath);
            this.Controls.Add(this.lblApiPath);
            this.Controls.Add(this.txtPermissionName);
            this.Controls.Add(this.lblPermissionName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Permission";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblPermissionName;
        private System.Windows.Forms.TextBox txtPermissionName;
        private Label lblApiPath;
        private System.Windows.Forms.TextBox txtApiPath;
        private Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;
    }
}