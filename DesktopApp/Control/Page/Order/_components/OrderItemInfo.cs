using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;
using DesktopApp.Utils;

namespace DesktopApp.Control.Page.Order._components
{
    public partial class OrderItemInfo : UserControl
    {
        private OrderItem _orderItem;
        private Database.Product _product;
        private ProductFunc _productFunc;
        
        public OrderItem OrderItem
        {
            get => _orderItem;
            set
            {
                _orderItem = value;
                LoadProductInfo();
                UpdateDisplay();
            }
        }
        
        public OrderItemInfo()
        {
            InitializeComponent();
            _productFunc = new ProductFunc();
        }
        
        public OrderItemInfo(OrderItem orderItem) : this()
        {
            OrderItem = orderItem;
        }
        

        
        private void LoadProductInfo()
        {
            if (_orderItem?.ProductId != null)
            {
                try
                {
                    _product = _productFunc.GetProductById(_orderItem.ProductId);
                }
                catch (Exception ex)
                {
                    // 处理异常，设置默认值
                    _product = null;
                }
            }
        }
        
        private void UpdateDisplay()
        {
            if (_orderItem == null) return;
            
            // 更新产品名称
            _productNameLabel.Text = _product?.Name ?? "unknown product";
            
            // 更新产品描述
            _productDescriptionLabel.Text = _product?.Description ?? "No description";
            
            // 更新数量
            _quantityLabel.Text = $"Quantity: {_orderItem.Quantity ?? 0}";
            
            // 更新单价
            if (_orderItem.UnitPriceCents.HasValue)
            {
                _unitPriceLabel.Text = $"Unit Price: ${_orderItem.UnitPriceCents.Value / 100.0:F2}";
            }
            else
            {
                _unitPriceLabel.Text = "Unit Price: Unknown";
            }
            
            // 更新总价
            if (_orderItem.TotalPriceCents.HasValue)
            {
                _totalPriceLabel.Text = $"Total: ${_orderItem.TotalPriceCents.Value / 100.0:F2}";
            }
            else
            {
                _totalPriceLabel.Text = "Total: Unknown";
            }
            
            // 更新产品图片
            LoadProductImage();
        }
        
        private void LoadProductImage()
        {
            try
            {
                if (_product != null && !string.IsNullOrEmpty(_product.ImageUrl))
                {
                    string fullImagePath = ImageManager.GetCompatibleImagePath(_product.ImageUrl);
                    
                    if (File.Exists(fullImagePath))
                    {
                        _productImage.Image = Image.FromFile(fullImagePath);
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
            catch
            {
                SetDefaultImage();
            }
        }
        
        private void SetDefaultImage()
        {
            _productImage.Image = null;
            _productImage.BackColor = Color.LightGray;
        }
        
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(245, 245, 245);
        }
        
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Color.White;
        }
    }
}