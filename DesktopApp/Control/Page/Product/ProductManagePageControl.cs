using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;
using DesktopApp.Forms;
using DesktopApp.Utils;

namespace DesktopApp.Control.Page.Product
{
    public partial class ProductManagePageControl : UserControl
    {
        private readonly ProductFunc _productFunc;
        private List<Database.Product> _products;
        private List<ProductCardControl> _productCards;
        
        public ProductManagePageControl()
        {
            InitializeComponent();
            _productFunc = new ProductFunc();
            _productCards = new List<ProductCardControl>();
            LoadProducts();
        }
        

        
        private void LoadProducts()
        {
            try
            {
                _products = _productFunc.GetAllProducts();
                
                // 清除现有的产品卡片
                foreach (var card in _productCards)
                {
                    flowLayoutPanelProducts.Controls.Remove(card);
                    card.Dispose();
                }
                _productCards.Clear();
                
                // 为每个产品创建ProductCardControl
                foreach (var product in _products)
                {
                    var productCard = new ProductCardControl(product);
                    productCard.SelectionChanged += ProductCard_SelectionChanged;
                    
                    _productCards.Add(productCard);
                    flowLayoutPanelProducts.Controls.Add(productCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to Load Product Data:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ProductCard_SelectionChanged(object sender, EventArgs e)
        {
            // 当产品卡片的选择状态改变时，可以在这里处理相关逻辑
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new AddProductForm();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(); // 重新加载数据
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to Open Add Product Window:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedProducts = GetSelectedProducts();
            
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Please select the product to edit", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (selectedProducts.Count > 1)
            {
                MessageBox.Show("Only one product can be selected for the editing function.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                var editForm = new EditProductForm(selectedProducts[0]);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(); // 重新加载数据
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to Open Edit Product Window: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedProducts = GetSelectedProducts();
            
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Please select the product to delete", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            string message = selectedProducts.Count == 1 
                ? $"Are you sure you want to delete the product '{selectedProducts[0].Name}'?"
                : $"Are you sure you want to delete the selected {selectedProducts.Count} products?";
                
            if (MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int successCount = 0;
                    int failCount = 0;
                    
                    foreach (var product in selectedProducts)
                    {
                        if (_productFunc.DeleteProduct(product.Id))
                        {
                            successCount++;
                        }
                        else
                        {
                            failCount++;
                        }
                    }
                    
                    string resultMessage = $"Delete completed: {successCount} successful";
                    if (failCount > 0)
                    {
                        resultMessage += $", {failCount} failed";
                    }
                    
                    MessageBox.Show(resultMessage, "Delete result", MessageBoxButtons.OK, 
                        failCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                    
                    LoadProducts(); // 重新加载数据
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Delete product failed:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
        
        private void btnMigrateImages_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show(
                    "This will migrate all product images to the currently configured storage location.\n" +
                    "The migration process may take some time. Are you sure you want to proceed?",
                    "Confirm image migration",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                if (confirmResult == DialogResult.Yes)
                {
                    // 显示进度提示
                    this.Cursor = Cursors.WaitCursor;
                    
                    // 执行迁移
                    var result = ImageMigrationHelper.MigrateImages();
                    
                    // 显示结果
                    ImageMigrationHelper.ShowMigrationResult(result);
                    
                    // 刷新产品列表
                    if (result.SuccessCount > 0)
                    {
                        LoadProducts();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Image migration failed:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        private void btnImageSettings_Click(object sender, EventArgs e)
        {
            try
            {
                using (var settingsForm = new ImageSettingsForm())
                {
                    if (settingsForm.ShowDialog(this) == DialogResult.OK)
                    {
                        // 设置已更新，可以选择刷新产品列表
                        var refreshResult = MessageBox.Show(
                            "The image storage settings have been updated. Do you want to refresh the product list to apply the new settings?",
                            "Settings updated",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        
                        if (refreshResult == DialogResult.Yes)
                        {
                            LoadProducts();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open image settings:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private List<Database.Product> GetSelectedProducts()
        {
            var selectedProducts = new List<Database.Product>();
            
            foreach (var productCard in _productCards)
            {
                if (productCard.IsSelected)
                {
                    selectedProducts.Add(productCard.Product);
                }
            }
            
            return selectedProducts;
        }
    }
}