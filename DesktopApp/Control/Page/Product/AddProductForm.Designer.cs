using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.Product
{
    partial class AddProductForm
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
            if (disposing)
            {
                // 释放图片资源
                if (picPreview?.Image != null)
                {
                    picPreview.Image.Dispose();
                }
                
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.lblImage = new Label();
            this.txtImagePath = new TextBox();
            this.btnSelectImage = new Button();
            this.picPreview = new PictureBox();
            this.chkSafetyCertification = new CheckBox();
            this.chkIsPublic = new CheckBox();
            this.lblDesignId = new Label();
            this.txtDesignId = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.openFileDialog = new OpenFileDialog();
            this.lblQuantity = new Label();
            this.txtQuantity = new TextBox();
            ((ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            
            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(30, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(68, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "产品名称:";
            
            // txtName
            this.txtName.Location = new Point(120, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(250, 25);
            this.txtName.TabIndex = 1;
            
            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(30, 70);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(68, 17);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "产品描述:";
            
            // txtDescription
            this.txtDescription.Location = new Point(120, 67);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new Size(250, 80);
            this.txtDescription.TabIndex = 3;
            
            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new Point(30, 170);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new Size(80, 17);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "价格(分):";
            
            // txtPrice
            this.txtPrice.Location = new Point(120, 167);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new Size(150, 25);
            this.txtPrice.TabIndex = 5;
            
            // lblImage
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new Point(30, 210);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new Size(68, 17);
            this.lblImage.TabIndex = 6;
            this.lblImage.Text = "产品图片:";
            
            // txtImagePath
            this.txtImagePath.Location = new Point(120, 207);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new Size(200, 25);
            this.txtImagePath.TabIndex = 7;
            
            // btnSelectImage
            this.btnSelectImage.Location = new Point(330, 205);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new Size(80, 30);
            this.btnSelectImage.TabIndex = 8;
            this.btnSelectImage.Text = "选择图片";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new EventHandler(this.btnSelectImage_Click);
            
            // picPreview
            this.picPreview.BorderStyle = BorderStyle.FixedSingle;
            this.picPreview.Location = new Point(450, 30);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new Size(200, 200);
            this.picPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 9;
            this.picPreview.TabStop = false;
            
            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new Point(30, 250);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new Size(68, 17);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "库存数量:";

            // txtQuantity
            this.txtQuantity.Location = new Point(120, 247);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new Size(150, 25);
            this.txtQuantity.TabIndex = 17;

            // chkSafetyCertification
            this.chkSafetyCertification.AutoSize = true;
            this.chkSafetyCertification.Location = new Point(120, 290);
            this.chkSafetyCertification.Name = "chkSafetyCertification";
            this.chkSafetyCertification.Size = new Size(89, 21);
            this.chkSafetyCertification.TabIndex = 10;
            this.chkSafetyCertification.Text = "安全认证";
            this.chkSafetyCertification.UseVisualStyleBackColor = true;
            
            // chkIsPublic
            this.chkIsPublic.AutoSize = true;
            this.chkIsPublic.Checked = true;
            this.chkIsPublic.CheckState = CheckState.Checked;
            this.chkIsPublic.Location = new Point(230, 290);
            this.chkIsPublic.Name = "chkIsPublic";
            this.chkIsPublic.Size = new Size(89, 21);
            this.chkIsPublic.TabIndex = 11;
            this.chkIsPublic.Text = "公开产品";
            this.chkIsPublic.UseVisualStyleBackColor = true;
            
            // lblDesignId
            this.lblDesignId.AutoSize = true;
            this.lblDesignId.Location = new Point(30, 330);
            this.lblDesignId.Name = "lblDesignId";
            this.lblDesignId.Size = new Size(68, 17);
            this.lblDesignId.TabIndex = 12;
            this.lblDesignId.Text = "设计ID:";
            
            // txtDesignId
            this.txtDesignId.Location = new Point(120, 327);
            this.txtDesignId.Name = "txtDesignId";
            this.txtDesignId.Size = new Size(150, 25);
            this.txtDesignId.TabIndex = 13;
            
            // btnSave
            this.btnSave.Location = new Point(450, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(90, 35);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            
            // btnCancel
            this.btnCancel.Location = new Point(560, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 35);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            
            // openFileDialog
            this.openFileDialog.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            this.openFileDialog.Title = "选择产品图片";
            
            // AddProductForm
            this.AutoScaleDimensions = new SizeF(8F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 380);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDesignId);
            this.Controls.Add(this.lblDesignId);
            this.Controls.Add(this.chkIsPublic);
            this.Controls.Add(this.chkSafetyCertification);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "添加产品";
            ((ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        
        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblImage;
        private TextBox txtImagePath;
        private Button btnSelectImage;
        private PictureBox picPreview;
        private CheckBox chkSafetyCertification;
        private CheckBox chkIsPublic;
        private Label lblDesignId;
        private TextBox txtDesignId;
        private Button btnSave;
        private Button btnCancel;
        private OpenFileDialog openFileDialog;
        private Label lblQuantity;
        private TextBox txtQuantity;
    }
}