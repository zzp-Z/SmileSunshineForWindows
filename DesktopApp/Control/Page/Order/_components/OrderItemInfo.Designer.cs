using System.ComponentModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.Order._components
{
    partial class OrderItemInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
        
        private Panel _contentPanel;
        private PictureBox _productImage;
        private Label _productNameLabel;
        private Label _productDescriptionLabel;
        private Label _quantityLabel;
        private Label _unitPriceLabel;
        private Label _totalPriceLabel;

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
            this._contentPanel = new Panel();
            this._productImage = new PictureBox();
            this._productNameLabel = new Label();
            this._productDescriptionLabel = new Label();
            this._quantityLabel = new Label();
            this._unitPriceLabel = new Label();
            this._totalPriceLabel = new Label();
            this._contentPanel.SuspendLayout();
            ((ISupportInitialize)(this._productImage)).BeginInit();
            this.SuspendLayout();
            // 
            // _contentPanel
            // 
            this._contentPanel.Controls.Add(this._totalPriceLabel);
            this._contentPanel.Controls.Add(this._unitPriceLabel);
            this._contentPanel.Controls.Add(this._quantityLabel);
            this._contentPanel.Controls.Add(this._productDescriptionLabel);
            this._contentPanel.Controls.Add(this._productNameLabel);
            this._contentPanel.Controls.Add(this._productImage);
            this._contentPanel.Dock = DockStyle.Fill;
            this._contentPanel.Location = new Point(0, 0);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Padding = new Padding(10);
            this._contentPanel.Size = new Size(800, 120);
            this._contentPanel.TabIndex = 0;
            // 
            // _productImage
            // 
            this._productImage.BackColor = Color.LightGray;
            this._productImage.BorderStyle = BorderStyle.FixedSingle;
            this._productImage.Location = new Point(15, 15);
            this._productImage.Name = "_productImage";
            this._productImage.Size = new Size(80, 80);
            this._productImage.SizeMode = PictureBoxSizeMode.Zoom;
            this._productImage.TabIndex = 0;
            this._productImage.TabStop = false;
            // 
            // _productNameLabel
            // 
            this._productNameLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this._productNameLabel.ForeColor = Color.Black;
            this._productNameLabel.Location = new Point(110, 15);
            this._productNameLabel.Name = "_productNameLabel";
            this._productNameLabel.Size = new Size(200, 25);
            this._productNameLabel.TabIndex = 1;
            this._productNameLabel.Text = "Product Name";
            this._productNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _productDescriptionLabel
            // 
            this._productDescriptionLabel.AutoEllipsis = true;
            this._productDescriptionLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this._productDescriptionLabel.ForeColor = Color.Gray;
            this._productDescriptionLabel.Location = new Point(110, 45);
            this._productDescriptionLabel.Name = "_productDescriptionLabel";
            this._productDescriptionLabel.Size = new Size(200, 40);
            this._productDescriptionLabel.TabIndex = 2;
            this._productDescriptionLabel.Text = "Product Description";
            this._productDescriptionLabel.TextAlign = ContentAlignment.TopLeft;
            // 
            // _quantityLabel
            // 
            this._quantityLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this._quantityLabel.ForeColor = Color.DarkBlue;
            this._quantityLabel.Location = new Point(330, 15);
            this._quantityLabel.Name = "_quantityLabel";
            this._quantityLabel.Size = new Size(100, 25);
            this._quantityLabel.TabIndex = 3;
            this._quantityLabel.Text = "Quantity: 0";
            this._quantityLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _unitPriceLabel
            // 
            this._unitPriceLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this._unitPriceLabel.ForeColor = Color.Green;
            this._unitPriceLabel.Location = new Point(330, 45);
            this._unitPriceLabel.Name = "_unitPriceLabel";
            this._unitPriceLabel.Size = new Size(120, 25);
            this._unitPriceLabel.TabIndex = 4;
            this._unitPriceLabel.Text = "Unit Price: $0.00";
            this._unitPriceLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _totalPriceLabel
            // 
            this._totalPriceLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this._totalPriceLabel.ForeColor = Color.Red;
            this._totalPriceLabel.Location = new Point(470, 15);
            this._totalPriceLabel.Name = "_totalPriceLabel";
            this._totalPriceLabel.Size = new Size(150, 25);
            this._totalPriceLabel.TabIndex = 5;
            this._totalPriceLabel.Text = "Total: $0.00";
            this._totalPriceLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderItemInfo
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this._contentPanel);
            this.Margin = new Padding(5);
            this.Name = "OrderItemInfo";
            this.Size = new Size(800, 120);
            this._contentPanel.ResumeLayout(false);
            ((ISupportInitialize)(this._productImage)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}