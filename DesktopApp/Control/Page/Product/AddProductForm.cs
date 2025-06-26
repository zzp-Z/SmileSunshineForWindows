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
                    MessageBox.Show($"Cannot load image:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 验证输入
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the product name.", "**Validation error**", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            
            int designId = 0;
            if (!string.IsNullOrWhiteSpace(txtDesignId.Text))
            {
                if (!int.TryParse(txtDesignId.Text, out designId))
                {
                    MessageBox.Show("Design ID must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDesignId.Focus();
                    return;
                }
            }
            
            int? priceCents = null;
            if (!string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                if (!int.TryParse(txtPrice.Text, out int price))
                {
                    MessageBox.Show("Please enter a valid price (in cents).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Please enter a valid inventory quantity (non-negative integer).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Product addition failed. Please check the database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the product:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        

    }
}