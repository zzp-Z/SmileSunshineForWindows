using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApp.Database.Func;
using DesktopApp.Database;
using DesktopApp.Utils;

namespace DesktopApp.Control.Page.Product
{
    public partial class EditProductForm : Form
    {
        private Database.Product _product;
        private string _selectedImagePath;
        private bool _imageChanged = false;

        public EditProductForm(Database.Product product)
        {
            InitializeComponent();
            _product = product;
            LoadProductData();
        }

        private void LoadProductData()
        {
            if (_product != null)
            {
                txtName.Text = _product.Name;
                txtDescription.Text = _product.Description;
                txtPrice.Text = _product.PriceCents?.ToString() ?? "0";
                txtImagePath.Text = _product.ImageUrl;
                chkSafetyCertification.Checked = _product.SafetyCertification ?? false;
                chkIsPublic.Checked = _product.IsPublic;
                txtDesignId.Text = _product.DesignId.ToString();
                txtQuantity.Text = _product.QuantityInStock.ToString();

                // 加载现有图片
                LoadExistingImage();
            }
        }

        private void LoadExistingImage()
        {
            if (!string.IsNullOrEmpty(_product.ImageUrl))
            {
                try
                {
                    string fullPath = ImageManager.GetCompatibleImagePath(_product.ImageUrl);
                    if (File.Exists(fullPath))
                    {
                        picPreview.Image = Image.FromFile(fullPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"加载图片失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = openFileDialog.FileName;
                _imageChanged = true;
                
                try
                {
                    // 显示预览
                    if (picPreview.Image != null)
                    {
                        picPreview.Image.Dispose();
                    }
                    picPreview.Image = Image.FromFile(_selectedImagePath);
                    txtImagePath.Text = Path.GetFileName(_selectedImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"加载图片失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 验证输入
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("请输入产品名称", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                if (!int.TryParse(txtPrice.Text, out int price) || price < 0)
                {
                    MessageBox.Show("请输入有效的价格（非负整数）", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice.Focus();
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

                if (!int.TryParse(txtQuantity.Text, out int quantityInStock) || quantityInStock < 0)
                {
                    MessageBox.Show("请输入有效的库存数量（非负整数）", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Focus();
                    return;
                }

                // 处理图片
                string imageUrl = _product.ImageUrl;
                if (_imageChanged && !string.IsNullOrEmpty(_selectedImagePath))
                {
                    imageUrl = SaveImage(_selectedImagePath);
                }

                // 更新产品信息
                _product.Name = txtName.Text.Trim();
                _product.Description = txtDescription.Text.Trim();
                _product.PriceCents = price;
                _product.ImageUrl = imageUrl;
                _product.SafetyCertification = chkSafetyCertification.Checked;
                _product.IsPublic = chkIsPublic.Checked;
                _product.DesignId = designId;
                _product.QuantityInStock = quantityInStock;

                // 保存到数据库
                var productFunc = new ProductFunc();
                bool success = productFunc.UpdateProduct(_product);

                if (success)
                {
                    MessageBox.Show("产品更新成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("产品更新失败，请重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存产品时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveImage(string sourcePath)
        {
            try
            {
                return ImageManager.SaveProductImage(sourcePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存图片失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return _product.ImageUrl; // 返回原图片路径
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}