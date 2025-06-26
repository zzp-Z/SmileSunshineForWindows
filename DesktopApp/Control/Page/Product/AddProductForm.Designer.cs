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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.chkSafetyCertification = new System.Windows.Forms.CheckBox();
            this.chkIsPublic = new System.Windows.Forms.CheckBox();
            this.lblDesignId = new System.Windows.Forms.Label();
            this.txtDesignId = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(45, 42);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(166, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Product Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(209, 38);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(344, 35);
            this.txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(45, 99);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(250, 24);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Product Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(292, 95);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(261, 111);
            this.txtDescription.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(45, 240);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(214, 24);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price (in cents):";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(253, 236);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(300, 35);
            this.txtPrice.TabIndex = 5;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(45, 296);
            this.lblImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(178, 24);
            this.lblImage.TabIndex = 6;
            this.lblImage.Text = "Product Image:";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(231, 292);
            this.txtImagePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(322, 35);
            this.txtImagePath.TabIndex = 7;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(562, 287);
            this.btnSelectImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(120, 42);
            this.btnSelectImage.TabIndex = 8;
            this.btnSelectImage.Text = "Select Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(690, 38);
            this.picPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(306, 291);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 9;
            this.picPreview.TabStop = false;
            // 
            // chkSafetyCertification
            // 
            this.chkSafetyCertification.AutoSize = true;
            this.chkSafetyCertification.Location = new System.Drawing.Point(180, 409);
            this.chkSafetyCertification.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSafetyCertification.Name = "chkSafetyCertification";
            this.chkSafetyCertification.Size = new System.Drawing.Size(282, 28);
            this.chkSafetyCertification.TabIndex = 10;
            this.chkSafetyCertification.Text = "Safety Certification";
            this.chkSafetyCertification.UseVisualStyleBackColor = true;
            // 
            // chkIsPublic
            // 
            this.chkIsPublic.AutoSize = true;
            this.chkIsPublic.Checked = true;
            this.chkIsPublic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsPublic.Location = new System.Drawing.Point(520, 409);
            this.chkIsPublic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIsPublic.Name = "chkIsPublic";
            this.chkIsPublic.Size = new System.Drawing.Size(222, 28);
            this.chkIsPublic.TabIndex = 11;
            this.chkIsPublic.Text = "Public Products";
            this.chkIsPublic.UseVisualStyleBackColor = true;
            // 
            // lblDesignId
            // 
            this.lblDesignId.AutoSize = true;
            this.lblDesignId.Location = new System.Drawing.Point(45, 466);
            this.lblDesignId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesignId.Name = "lblDesignId";
            this.lblDesignId.Size = new System.Drawing.Size(130, 24);
            this.lblDesignId.TabIndex = 12;
            this.lblDesignId.Text = "Design ID:";
            // 
            // txtDesignId
            // 
            this.txtDesignId.Location = new System.Drawing.Point(180, 462);
            this.txtDesignId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDesignId.Name = "txtDesignId";
            this.txtDesignId.Size = new System.Drawing.Size(282, 35);
            this.txtDesignId.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(675, 452);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 49);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(840, 452);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 49);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image File|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            this.openFileDialog.Title = "Select Product Image";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(45, 353);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(238, 24);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "Inventory Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(291, 349);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(262, 35);
            this.txtQuantity.TabIndex = 17;
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 536);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Product";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        
        private Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private Label lblImage;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.PictureBox picPreview;
        private CheckBox chkSafetyCertification;
        private System.Windows.Forms.CheckBox chkIsPublic;
        private Label lblDesignId;
        private System.Windows.Forms.TextBox txtDesignId;
        private Button btnSave;
        private Button btnCancel;
        private OpenFileDialog openFileDialog;
        private Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
    }
}