using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.SystemManage.RoleManage
{
    partial class RoleAddEditForm
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
            this.components = new Container();
            this.lblDepartment = new Label();
            this.cmbDepartment = new ComboBox();
            this.lblRoleName = new Label();
            this.txtRoleName = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblPermissions = new Label();
            this.clbPermissions = new CheckedListBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new Point(20, 20);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new Size(60, 13);
            this.lblDepartment.TabIndex = 0;
            this.lblDepartment.Text = "Department:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new Point(90, 17);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new Size(280, 21);
            this.cmbDepartment.TabIndex = 1;
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Location = new Point(20, 60);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new Size(60, 13);
            this.lblRoleName.TabIndex = 2;
            this.lblRoleName.Text = "Role Name:";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new Point(90, 57);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new Size(280, 20);
            this.txtRoleName.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(20, 100);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new Point(90, 97);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new Size(280, 60);
            this.txtDescription.TabIndex = 5;
            // 
            // lblPermissions
            // 
            this.lblPermissions.AutoSize = true;
            this.lblPermissions.Location = new Point(20, 180);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new Size(65, 13);
            this.lblPermissions.TabIndex = 6;
            this.lblPermissions.Text = "Permissions:";
            // 
            // clbPermissions
            // 
            this.clbPermissions.CheckOnClick = true;
            this.clbPermissions.FormattingEnabled = true;
            this.clbPermissions.Location = new Point(90, 177);
            this.clbPermissions.Name = "clbPermissions";
            this.clbPermissions.Size = new Size(280, 140);
            this.clbPermissions.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(215, 340);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Confirm";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(295, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // RoleAddEditForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 380);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.clbPermissions);
            this.Controls.Add(this.lblPermissions);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoleAddEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Role Management";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblDepartment;
        private ComboBox cmbDepartment;
        private Label lblRoleName;
        private TextBox txtRoleName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblPermissions;
        private CheckedListBox clbPermissions;
        private Button btnOK;
        private Button btnCancel;
    }
}