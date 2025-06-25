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
                MessageBox.Show($"加载产品数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"打开添加产品窗口失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedProducts = GetSelectedProducts();
            
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("请选择要编辑的产品", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (selectedProducts.Count > 1)
            {
                MessageBox.Show("编辑功能只能选择一个产品", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"打开编辑产品窗口失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedProducts = GetSelectedProducts();
            
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("请选择要删除的产品", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            string message = selectedProducts.Count == 1 
                ? $"确定要删除产品 '{selectedProducts[0].Name}' 吗？"
                : $"确定要删除选中的 {selectedProducts.Count} 个产品吗？";
                
            if (MessageBox.Show(message, "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    
                    string resultMessage = $"删除完成：成功 {successCount} 个";
                    if (failCount > 0)
                    {
                        resultMessage += $"，失败 {failCount} 个";
                    }
                    
                    MessageBox.Show(resultMessage, "删除结果", MessageBoxButtons.OK, 
                        failCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                    
                    LoadProducts(); // 重新加载数据
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除产品失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    "这将把所有产品图片迁移到当前配置的存储位置。\n" +
                    "迁移过程可能需要一些时间，确定要继续吗？",
                    "确认图片迁移",
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
                MessageBox.Show($"图片迁移失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            "图片存储设置已更新。是否要刷新产品列表以应用新设置？",
                            "设置已更新",
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
                MessageBox.Show($"打开图片设置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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