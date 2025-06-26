using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DesktopApp.Utils;

namespace DesktopApp.Control.Page.Product
{
    public partial class ProductOrderCardControl : UserControl
    {
        private Database.Product _product;
        private int _selectedQuantity;
        
        public Database.Product Product => _product;
        public int SelectedQuantity => _selectedQuantity;
        public bool IsSelected => _selectedQuantity > 0;
        
        public ProductOrderCardControl(Database.Product product)
        {
            InitializeComponent();
            _product = product;
            _selectedQuantity = 0;
            UpdateDisplay();
        }
        
        private void UpdateDisplay()
        {
            if (_product == null) return;
            
            lblProductName.Text = _product.Name ?? "Unnamed product";
            lblDescription.Text = _product.Description ?? "No description yet";
            
            // 正确显示价格：PriceCents除以100转换为元
            if (_product.PriceCents.HasValue)
            {
                lblPrice.Text = $"${_product.PriceCents.Value / 100.0:F2}";
            }
            else
            {
                lblPrice.Text = "Price not set";
            }
            
            lblStock.Text = $"Inventory:{_product.QuantityInStock}";
            
            // 设置数量选择器的最大值
            numQuantity.Maximum = _product.QuantityInStock;
            numQuantity.Value = _selectedQuantity;
            
            // 根据库存状态设置颜色
            if (_product.QuantityInStock <= 0)
            {
                lblStock.ForeColor = Color.Red;
                numQuantity.Enabled = false;
            }
            else if (_product.QuantityInStock <= 10)
            {
                lblStock.ForeColor = Color.Orange;
                numQuantity.Enabled = true;
            }
            else
            {
                lblStock.ForeColor = Color.Green;
                numQuantity.Enabled = true;
            }
            
            // 显示安全认证状态
            if (_product.SafetyCertification == true)
            {
                lblSafety.Text = "✓ Safety certification";
                lblSafety.ForeColor = Color.Green;
            }
            else
            {
                lblSafety.Text = "✗ No certification";
                lblSafety.ForeColor = Color.Gray;
            }
            
            // 加载产品图片
            LoadProductImage();
        }
        
        private void LoadProductImage()
        {
            try
            {
                if (!string.IsNullOrEmpty(_product.ImageUrl))
                {
                    string fullImagePath = ImageManager.GetCompatibleImagePath(_product.ImageUrl);
                    
                    if (File.Exists(fullImagePath))
                    {
                        pictureBoxProduct.Image = Image.FromFile(fullImagePath);
                        pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        SetDefaultImage();
                    }
                }
                else
                {
                    SetDefaultImage();
                }
            }
            catch (Exception ex)
            {
                SetDefaultImage();
                Console.WriteLine($"Failed to load product images: {ex.Message}");
            }
        }
        
        private void SetDefaultImage()
        {
            pictureBoxProduct.Image = null;
            pictureBoxProduct.BackColor = Color.LightGray;
        }
        
        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            _selectedQuantity = (int)numQuantity.Value;
            
            // 更新卡片背景色以指示选择状态
            if (_selectedQuantity > 0)
            {
                this.BackColor = Color.FromArgb(240, 248, 255); // 浅蓝色
                this.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                this.BackColor = Color.White;
                this.BorderStyle = BorderStyle.None;
            }
        }
        
        public void ResetSelection()
        {
            _selectedQuantity = 0;
            numQuantity.Value = 0;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.None;
        }
    }
}