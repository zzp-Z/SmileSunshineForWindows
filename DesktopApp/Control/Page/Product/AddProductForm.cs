using System;
using System.IO;
using System.Windows.Forms;
using DesktopApp.Database.Func;
using DesktopApp.Utils;

namespace DesktopApp.Control.Page.Product
{
    public partial class AddProductForm : Form
    {
        private readonly ProductFunc _productFunc;
        private string _selectedImagePath = string.Empty;
        
        public AddProductForm()
        {
            InitializeComponent();
            _productFunc = new ProductFunc();
        }
        
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = openFileDialog.FileName;
                txtImagePath.Text = Path.GetFileName(_selectedImagePath);
                
                // 显示图片预览
                try
                {
                    if (_selectedImagePath != null)
                        picPreview.Image = System.Drawing.Image.FromFile(_selectedImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"无法加载图片: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 验证输入
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入产品名称", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            
            int designId = 0;
            if (!string.IsNullOrWhiteSpace(txtDesignId.Text))
            {
                if (!int.TryParse(txtDesignId.Text, out designId))
                {
                    MessageBox.Show("设计ID必须是数字", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDesignId.Focus();
                    return;
                }
            }
            
            int? priceCents = null;
            if (!string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                if (!int.TryParse(txtPrice.Text, out int price))
                {
                    MessageBox.Show("请输入有效的价格(分)", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice.Focus();
                    return;
                }
                priceCents = price;
            }

            int quantityInStock = 0;
            if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                if (!int.TryParse(txtQuantity.Text, out quantityInStock) || quantityInStock < 0)
                {
                    MessageBox.Show("请输入有效的库存数量（非负整数）", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Focus();
                    return;
                }
            }
            
            try
            {
                // 使用ImageManager保存图片
                string imageUrl = string.Empty;
                if (!string.IsNullOrEmpty(_selectedImagePath))
                {
                    imageUrl = ImageManager.SaveProductImage(_selectedImagePath);
                }
                
                // 创建产品对象
                var product = new Database.Product
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    PriceCents = priceCents,
                    ImageUrl = imageUrl,
                    SafetyCertification = chkSafetyCertification.Checked ? (bool?)true : null,
                    CreateDate = DateTime.Now,
                    IsPublic = chkIsPublic.Checked,
                    DesignId = designId,
                    QuantityInStock = quantityInStock
                };
                
                // 保存到数据库
                if (_productFunc.CreateProduct(product))
                {
                    MessageBox.Show("产品添加成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("产品添加失败，请检查数据库连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存产品时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        

    }
}