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
        private PictureBox _productImage;
        private Label _productNameLabel;
        private Label _productDescriptionLabel;
        private Label _quantityLabel;
        private Label _unitPriceLabel;
        private Label _totalPriceLabel;
        private Panel _contentPanel;
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
            InitializeControls();
        }
        
        public OrderItemInfo(OrderItem orderItem) : this()
        {
            OrderItem = orderItem;
        }
        
        private void InitializeControls()
        {
            this.Size = new Size(780, 100);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;
            this.Margin = new Padding(5);
            
            // 主容器面板
            _contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            this.Controls.Add(_contentPanel);
            
            // 产品图片
            _productImage = new PictureBox
            {
                Location = new Point(10, 10),
                Size = new Size(70, 70),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray
            };
            _contentPanel.Controls.Add(_productImage);
            
            // 产品名称
            _productNameLabel = new Label
            {
                Location = new Point(100, 15),
                Size = new Size(180, 20),
                Font = new Font("微软雅黑", 10, FontStyle.Bold),
                ForeColor = Color.Black
            };
            _contentPanel.Controls.Add(_productNameLabel);
            
            // 产品描述
            _productDescriptionLabel = new Label
            {
                Location = new Point(100, 40),
                Size = new Size(180, 30),
                Font = new Font("微软雅黑", 8),
                ForeColor = Color.Gray,
                AutoEllipsis = true
            };
            _contentPanel.Controls.Add(_productDescriptionLabel);
            
            // 数量
            _quantityLabel = new Label
            {
                Location = new Point(300, 15),
                Size = new Size(80, 20),
                Font = new Font("微软雅黑", 9, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleLeft
            };
            _contentPanel.Controls.Add(_quantityLabel);
            
            // 单价
            _unitPriceLabel = new Label
            {
                Location = new Point(400, 15),
                Size = new Size(100, 20),
                Font = new Font("微软雅黑", 9),
                ForeColor = Color.Green,
                TextAlign = ContentAlignment.MiddleLeft
            };
            _contentPanel.Controls.Add(_unitPriceLabel);
            
            // 总价
            _totalPriceLabel = new Label
            {
                Location = new Point(520, 15),
                Size = new Size(120, 20),
                Font = new Font("微软雅黑", 10, FontStyle.Bold),
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleLeft
            };
            _contentPanel.Controls.Add(_totalPriceLabel);
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
            _productNameLabel.Text = _product?.Name ?? "未知产品";
            
            // 更新产品描述
            _productDescriptionLabel.Text = _product?.Description ?? "暂无描述";
            
            // 更新数量
            _quantityLabel.Text = $"数量: {_orderItem.Quantity ?? 0}";
            
            // 更新单价
            if (_orderItem.UnitPriceCents.HasValue)
            {
                _unitPriceLabel.Text = $"单价: ¥{_orderItem.UnitPriceCents.Value / 100.0:F2}";
            }
            else
            {
                _unitPriceLabel.Text = "单价: 未设置";
            }
            
            // 更新总价
            if (_orderItem.TotalPriceCents.HasValue)
            {
                _totalPriceLabel.Text = $"总价: ¥{_orderItem.TotalPriceCents.Value / 100.0:F2}";
            }
            else
            {
                _totalPriceLabel.Text = "总价: 未设置";
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