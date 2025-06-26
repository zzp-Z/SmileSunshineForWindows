using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DesktopApp.Utils;

namespace DesktopApp.Control.Page.Product
{
    public partial class ProductCardControl : UserControl
    {
        private Database.Product _product;
        private CheckBox _selectCheckBox;
        private PictureBox _productImage;
        private Label _nameLabel;
        private Label _descriptionLabel;
        private Label _priceLabel;
        private Label _certificationLabel;
        private Label _statusLabel;
        private Label _createDateLabel;
        private Label _quantityLabel;
        private Panel _contentPanel;
        
        public Database.Product Product
        {
            get => _product;
            set
            {
                _product = value;
                UpdateDisplay();
            }
        }
        
        public bool IsSelected
        {
            get => _selectCheckBox.Checked;
            set => _selectCheckBox.Checked = value;
        }
        
        public event EventHandler SelectionChanged;
        
        public ProductCardControl()
        {
            InitializeComponent();
            InitializeControls();
        }
        
        public ProductCardControl(Database.Product product) : this()
        {
            Product = product;
        }
        
        private void InitializeControls()
        {
            this.Size = new Size(800, 120);
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
            
            // 选择复选框
            _selectCheckBox = new CheckBox
            {
                Location = new Point(10, 10),
                Size = new Size(20, 20),
                Text = ""
            };
            _selectCheckBox.CheckedChanged += (s, e) => SelectionChanged?.Invoke(this, e);
            _contentPanel.Controls.Add(_selectCheckBox);
            
            // 产品图片
            _productImage = new PictureBox
            {
                Location = new Point(40, 10),
                Size = new Size(80, 80),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray
            };
            _contentPanel.Controls.Add(_productImage);
            
            // 产品名称
            _nameLabel = new Label
            {
                Location = new Point(140, 15),
                Size = new Size(150, 20),
                Font = new Font("Microsoft YaHei", 10, FontStyle.Bold),
                ForeColor = Color.Black
            };
            _contentPanel.Controls.Add(_nameLabel);
            
            // 产品描述
            _descriptionLabel = new Label
            {
                Location = new Point(140, 40),
                Size = new Size(200, 40),
                Font = new Font("Microsoft YaHei", 9),
                ForeColor = Color.Gray,
                AutoEllipsis = true
            };
            _contentPanel.Controls.Add(_descriptionLabel);
            
            // 价格
            _priceLabel = new Label
            {
                Location = new Point(360, 15),
                Size = new Size(100, 20),
                Font = new Font("Microsoft YaHei", 9, FontStyle.Bold),
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleLeft
            };
            _contentPanel.Controls.Add(_priceLabel);
            
            // 安全认证
            _certificationLabel = new Label
            {
                Location = new Point(360, 40),
                Size = new Size(80, 20),
                Font = new Font("Microsoft YaHei", 8),
                ForeColor = Color.Green,
                TextAlign = ContentAlignment.MiddleLeft
            };
            _contentPanel.Controls.Add(_certificationLabel);
            
            // 公开状态
            _statusLabel = new Label
            {
                Location = new Point(450, 40),
                Size = new Size(60, 20),
                Font = new Font("Microsoft YaHei", 8),
                ForeColor = Color.Blue,
                TextAlign = ContentAlignment.MiddleLeft
            };
            _contentPanel.Controls.Add(_statusLabel);
            
            // 创建时间
            _createDateLabel = new Label
            {
                Location = new Point(520, 15),
                Size = new Size(120, 20),
                Font = new Font("Microsoft YaHei", 8),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleLeft
            };
            _contentPanel.Controls.Add(_createDateLabel);

            // 库存数量
            _quantityLabel = new Label
            {
                Location = new Point(360, 65),
                Size = new Size(150, 20),
                Font = new Font("Microsoft YaHei", 9, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleLeft
            };
            _contentPanel.Controls.Add(_quantityLabel);
        }
        
        private void UpdateDisplay()
        {
            if (_product == null) return;
            
            // 更新产品名称
            _nameLabel.Text = _product.Name ?? "暂无描述";
            
            // 更新产品描述
            _descriptionLabel.Text = _product.Description ?? "No Description";
            
            // 更新价格
            if (_product.PriceCents.HasValue)
            {
                _priceLabel.Text = $"${_product.PriceCents.Value / 100.0:F2}";
            }
            else
            {
                _priceLabel.Text = "Price Not Set";
            }
            
            // 更新安全认证
            _certificationLabel.Text = (_product.SafetyCertification ?? false) ? "Certified" : "UnCertified";
            _certificationLabel.ForeColor = (_product.SafetyCertification ?? false) ? Color.Green : Color.Orange;
            
            // 更新公开状态
            _statusLabel.Text = _product.IsPublic ? "Public" : "Private";
            _statusLabel.ForeColor = _product.IsPublic ? Color.Blue : Color.Gray;
            
            // 更新创建时间
            if (_product.CreateDate.HasValue)
            {
                _createDateLabel.Text = _product.CreateDate.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                _createDateLabel.Text = "Unknown Time";
            }

            // 更新库存数量
            _quantityLabel.Text = $"Inventory: {_product.QuantityInStock}";
            _quantityLabel.ForeColor = _product.QuantityInStock > 0 ? Color.DarkBlue : Color.Red;
            
            // 更新产品图片
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