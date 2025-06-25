using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.Product
{
    public partial class ProductPageControl : UserControl
    {
        private readonly ProductFunc _productFunc;
        private List<Database.Product> _products;
        private List<ProductOrderCardControl> _productCards;
        
        public ProductPageControl()
        {
            InitializeComponent();
            _productFunc = new ProductFunc();
            _productCards = new List<ProductOrderCardControl>();
            LoadProducts();
        }
        
        private void LoadProducts()
        {
            try
            {
                _products = _productFunc.GetAllProducts().Where(p => p.IsPublic && p.QuantityInStock > 0).ToList();
                
                // 清除现有的产品卡片
                foreach (var card in _productCards)
                {
                    flowLayoutPanelProducts.Controls.Remove(card);
                    card.Dispose();
                }
                _productCards.Clear();
                
                // 为每个产品创建ProductOrderCardControl
                foreach (var product in _products)
                {
                    var productCard = new ProductOrderCardControl(product);
                    _productCards.Add(productCard);
                    flowLayoutPanelProducts.Controls.Add(productCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载产品数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            var selectedItems = GetSelectedOrderItems();
            
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("请选择要订购的产品并设置数量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                var createOrderForm = new CreateOrderForm(selectedItems);
                if (createOrderForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(); // 重新加载数据
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开创建订单窗口失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
        
        private List<OrderItemInfo> GetSelectedOrderItems()
        {
            var selectedItems = new List<OrderItemInfo>();
            
            foreach (var productCard in _productCards)
            {
                if (productCard.IsSelected)
                {
                    selectedItems.Add(new OrderItemInfo
                    {
                        Product = productCard.Product,
                        Quantity = productCard.SelectedQuantity
                    });
                }
            }
            
            return selectedItems;
        }
    }
    
    public class OrderItemInfo
    {
        public Database.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}