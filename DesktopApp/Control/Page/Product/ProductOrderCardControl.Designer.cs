using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.Product
{
    partial class ProductOrderCardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxProduct = new PictureBox();
            this.lblProductName = new Label();
            this.lblDescription = new Label();
            this.lblPrice = new Label();
            this.lblStock = new Label();
            this.lblSafety = new Label();
            this.lblQuantityLabel = new Label();
            this.numQuantity = new NumericUpDown();
            this.panelInfo = new Panel();
            ((ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            ((ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.BackColor = Color.LightGray;
            this.pictureBoxProduct.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxProduct.Location = new Point(10, 10);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new Size(100, 100);
            this.pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxProduct.TabIndex = 0;
            this.pictureBoxProduct.TabStop = false;
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.numQuantity);
            this.panelInfo.Controls.Add(this.lblQuantityLabel);
            this.panelInfo.Controls.Add(this.lblSafety);
            this.panelInfo.Controls.Add(this.lblStock);
            this.panelInfo.Controls.Add(this.lblPrice);
            this.panelInfo.Controls.Add(this.lblDescription);
            this.panelInfo.Controls.Add(this.lblProductName);
            this.panelInfo.Location = new Point(120, 10);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new Size(450, 100);
            this.panelInfo.TabIndex = 1;
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold);
            this.lblProductName.Location = new Point(0, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new Size(200, 20);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name";
            // 
            // lblDescription
            // 
            this.lblDescription.ForeColor = Color.Gray;
            this.lblDescription.Location = new Point(0, 25);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(300, 15);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Product Description";
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold);
            this.lblPrice.ForeColor = Color.Red;
            this.lblPrice.Location = new Point(0, 45);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new Size(100, 15);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "$0.00";
            // 
            // lblStock
            // 
            this.lblStock.Location = new Point(110, 45);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new Size(80, 15);
            this.lblStock.TabIndex = 3;
            this.lblStock.Text = "Inventory: 0";
            // 
            // lblSafety
            // 
            this.lblSafety.Location = new Point(200, 45);
            this.lblSafety.Name = "lblSafety";
            this.lblSafety.Size = new Size(80, 15);
            this.lblSafety.TabIndex = 4;
            this.lblSafety.Text = "Security Authentication";
            // 
            // lblQuantityLabel
            // 
            this.lblQuantityLabel.Location = new Point(0, 70);
            this.lblQuantityLabel.Name = "lblQuantityLabel";
            this.lblQuantityLabel.Size = new Size(50, 20);
            this.lblQuantityLabel.TabIndex = 5;
            this.lblQuantityLabel.Text = "Quantity:";
            this.lblQuantityLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new Point(55, 70);
            this.numQuantity.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new Size(80, 21);
            this.numQuantity.TabIndex = 6;
            this.numQuantity.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.numQuantity.ValueChanged += new EventHandler(this.numQuantity_ValueChanged);
            // 
            // ProductOrderCardControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.pictureBoxProduct);
            this.Name = "ProductOrderCardControl";
            this.Size = new Size(580, 120);
            ((ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            ((ISupportInitialize)(this.numQuantity)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        
        private PictureBox pictureBoxProduct;
        private Label lblProductName;
        private Label lblDescription;
        private Label lblPrice;
        private Label lblStock;
        private Label lblSafety;
        private Label lblQuantityLabel;
        private NumericUpDown numQuantity;
        private Panel panelInfo;
    }
}