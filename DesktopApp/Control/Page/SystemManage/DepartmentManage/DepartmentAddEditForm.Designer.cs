using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.SystemManage.DepartmentManage
{
    partial class DepartmentAddEditForm
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
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(65, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "部门名称：";
            // 
            // txtName
            // 
            this.txtName.Location = new Point(90, 17);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(250, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(20, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(65, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "部门描述：";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new Point(90, 47);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = ScrollBars.Vertical;
            this.txtDescription.Size = new Size(250, 80);
            this.txtDescription.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new Point(180, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(265, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // DepartmentAddEditForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new Size(370, 200);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepartmentAddEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "部门管理";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnOK;
        private Button btnCancel;
    }
}