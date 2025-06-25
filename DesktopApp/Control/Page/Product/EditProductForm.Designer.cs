using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.Product
{
    partial class EditProductForm
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
            this.lblQuantity = new Label();
            this.txtQuantity = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.openFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(30, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(65, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Product Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new Point(120, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(200, 21);
            this.txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(30, 70);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(65, 12);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Product Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new Point(120, 67);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new Size(200, 60);
            this.txtDescription.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new Point(30, 150);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new Size(77, 12);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price (Cents):";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new Point(120, 147);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new Size(200, 21);
            this.txtPrice.TabIndex = 5;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new Point(30, 190);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new Size(65, 12);
            this.lblImage.TabIndex = 6;
            this.lblImage.Text = "产品图片:";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new Point(120, 187);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new Size(150, 21);
            this.txtImagePath.TabIndex = 7;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new Point(280, 185);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new Size(75, 23);
            this.btnSelectImage.TabIndex = 8;
            this.btnSelectImage.Text = "Select Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new EventHandler(this.btnSelectImage_Click);
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = BorderStyle.FixedSingle;
            this.picPreview.Location = new Point(380, 27);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new Size(200, 200);
            this.picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 9;
            this.picPreview.TabStop = false;
            // 
            // chkSafetyCertification
            // 
            this.chkSafetyCertification.AutoSize = true;
            this.chkSafetyCertification.Location = new Point(120, 270);
            this.chkSafetyCertification.Name = "chkSafetyCertification";
            this.chkSafetyCertification.Size = new Size(72, 16);
            this.chkSafetyCertification.TabIndex = 12;
            this.chkSafetyCertification.Text = "Security Authentication";
            this.chkSafetyCertification.UseVisualStyleBackColor = true;
            // 
            // chkIsPublic
            // 
            this.chkIsPublic.AutoSize = true;
            this.chkIsPublic.Location = new Point(220, 270);
            this.chkIsPublic.Name = "chkIsPublic";
            this.chkIsPublic.Size = new Size(72, 16);
            this.chkIsPublic.TabIndex = 13;
            this.chkIsPublic.Text = "Public Products";
            this.chkIsPublic.UseVisualStyleBackColor = true;
            // 
            // lblDesignId
            // 
            this.lblDesignId.AutoSize = true;
            this.lblDesignId.Location = new Point(30, 310);
            this.lblDesignId.Name = "lblDesignId";
            this.lblDesignId.Size = new Size(53, 12);
            this.lblDesignId.TabIndex = 14;
            this.lblDesignId.Text = "Design ID:";
            // 
            // txtDesignId
            // 
            this.txtDesignId.Location = new Point(120, 307);
            this.txtDesignId.Name = "txtDesignId";
            this.txtDesignId.Size = new Size(200, 21);
            this.txtDesignId.TabIndex = 15;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new Point(30, 230);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new Size(65, 12);
            this.lblQuantity.TabIndex = 10;
            this.lblQuantity.Text = "Inventory Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new Point(120, 227);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new Size(200, 21);
            this.txtQuantity.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(380, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(75, 30);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(480, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 30);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image File|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            this.openFileDialog.Title = "Select Product Image";
            // 
            // EditProductForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(620, 360);
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
            this.Name = "EditProductForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Edit Product";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
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
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnSave;
        private Button btnCancel;
        private OpenFileDialog openFileDialog;
    }
}