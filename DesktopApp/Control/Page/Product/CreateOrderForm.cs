using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.Product
{
    public partial class CreateOrderForm : Form
    {
        private List<OrderItemInfo> _orderItems;
        private CustomerFunc _customerFunc;
        private OrderFunc _orderFunc;
        private ProductFunc _productFunc;
        
        public CreateOrderForm(List<OrderItemInfo> orderItems)
        {
            InitializeComponent();
            _orderItems = orderItems ?? new List<OrderItemInfo>();
            _customerFunc = new CustomerFunc();
            _orderFunc = new OrderFunc();
            _productFunc = new ProductFunc();
            
            InitializeForm();
        }
        
        private void InitializeForm()
        {
            LoadCustomers();
            LoadOrderItems();
            CalculateTotals();
            
            // 设置默认值
            dtpOrderDate.Value = DateTime.Now;
            dtpDeliveryDate.Value = DateTime.Now.AddDays(7);
            cmbPaymentMethod.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }
        
        private void LoadCustomers()
        {
            try
            {
                var customers = _customerFunc.GetAllCustomers();
                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "Id";
                
                if (customers.Count == 0)
                {
                    MessageBox.Show("没有找到客户信息，请先添加客户。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载客户信息失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadOrderItems()
        {
            listViewOrderItems.Items.Clear();
            
            foreach (var item in _orderItems)
            {
                var listItem = new ListViewItem(item.Product.Name);
                listItem.SubItems.Add(item.Quantity.ToString());
                listItem.SubItems.Add($"¥{(item.Product.PriceCents ?? 0) / 100.0m:F2}");
                listItem.SubItems.Add($"¥{(item.Product.PriceCents ?? 0) * item.Quantity / 100.0m:F2}");
                listItem.Tag = item;
                
                listViewOrderItems.Items.Add(listItem);
            }
        }
        
        private void CalculateTotals()
        {
            decimal productAmount = _orderItems.Sum(item => (item.Product.PriceCents ?? 0) * item.Quantity / 100.0m);
            decimal shippingCost = numShippingCost.Value;
            decimal taxAmount = productAmount * 0.1m; // 假设税率为10%
            decimal totalAmount = productAmount + shippingCost + taxAmount;
            
            lblProductAmount.Text = $"¥{productAmount:F2}";
            lblTaxAmount.Text = $"¥{taxAmount:F2}";
            lblTotalAmount.Text = $"¥{totalAmount:F2}";
        }
        
        private void numShippingCost_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotals();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;
                
                var salesOrder = CreateSalesOrder();
                int orderId = _orderFunc.CreateOrder(salesOrder);
                
                // 检查订单是否创建成功
                if (orderId <= 0)
                {
                    MessageBox.Show("创建订单失败，请检查订单信息。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // 检查库存是否充足
                foreach (var item in _orderItems)
                {
                    if (!_productFunc.CheckProductStock(item.Product.Id, item.Quantity))
                    {
                        MessageBox.Show($"产品 '{item.Product.Name}' 库存不足。当前需要 {item.Quantity} 件，请检查库存。", "库存不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                
                // 创建订单项
                bool allItemsCreated = true;
                List<int> processedProductIds = new List<int>(); // 记录已处理的产品ID，用于回滚
                
                foreach (var item in _orderItems)
                {
                    var orderItem = new Database.OrderItem
                    {
                        OrderId = orderId,
                        ProductId = item.Product.Id,
                        Quantity = item.Quantity,
                        UnitPriceCents = item.Product.PriceCents ?? 0,
                        TotalPriceCents = (item.Product.PriceCents ?? 0) * item.Quantity
                    };
                    
                    if (!_orderFunc.AddOrderItem(orderItem))
                    {
                        allItemsCreated = false;
                        break;
                    }
                    
                    // 减少产品库存
                    if (!_productFunc.ReduceProductStock(item.Product.Id, item.Quantity))
                    {
                        MessageBox.Show($"减少产品 '{item.Product.Name}' 库存失败。", "库存更新失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        allItemsCreated = false;
                        break;
                    }
                    
                    processedProductIds.Add(item.Product.Id);
                }
                
                if (!allItemsCreated)
                {
                    // 如果创建失败，需要回滚已减少的库存
                    foreach (var productId in processedProductIds)
                    {
                        var item = _orderItems.FirstOrDefault(x => x.Product.Id == productId);
                        if (item != null)
                        {
                            // 通过增加库存来回滚（这里简化处理，实际项目中可能需要更复杂的回滚机制）
                            var product = _productFunc.GetProductById(productId);
                            if (product != null)
                            {
                                product.QuantityInStock += item.Quantity;
                                _productFunc.UpdateProduct(product);
                            }
                        }
                    }
                    MessageBox.Show("创建订单项失败，订单可能不完整，已回滚库存变更。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("订单创建成功，产品库存已更新！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"创建订单失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool ValidateInput()
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("请选择客户。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
            {
                MessageBox.Show("请输入订单号。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtShippingAddress.Text))
            {
                MessageBox.Show("请输入配送地址。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (_orderItems.Count == 0)
            {
                MessageBox.Show("订单中没有商品。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
        
        private Database.SalesOrder CreateSalesOrder()
        {
            decimal productAmount = _orderItems.Sum(item => (item.Product.PriceCents ?? 0) * item.Quantity / 100.0m);
            decimal shippingCost = numShippingCost.Value;
            decimal taxAmount = productAmount * 0.1m;
            decimal totalAmount = productAmount + shippingCost + taxAmount;
            
            return new Database.SalesOrder
            {
                CustomerId = (int)cmbCustomer.SelectedValue,
                OrderNumber = txtOrderNumber.Text.Trim(),
                PaymentMethod = ConvertPaymentMethodToEnglish(cmbPaymentMethod.Text),
                OrderDate = dtpOrderDate.Value,
                DeliveryDate = dtpDeliveryDate.Value,
                PaymentTerms = txtPaymentTerms.Text.Trim(),
                ShippingAddress = txtShippingAddress.Text.Trim(),
                Status = ConvertStatusToEnglish(cmbStatus.Text),
                ProductAmountCents = (int)(productAmount * 100),
                ShippingCostCents = (int)(shippingCost * 100),
                TaxAmountCents = (int)(taxAmount * 100),
                TotalAmountCents = (int)(totalAmount * 100),
                DownPaymentPercent = (int)numDownPaymentPercent.Value,
                IsDownPaymentPaid = chkDownPaymentPaid.Checked,
                IsCustomized = chkIsCustomized.Checked,
                SpecialRequirements = txtSpecialRequirements.Text.Trim()
            };
        }
        
        private string ConvertPaymentMethodToEnglish(string chinesePaymentMethod)
        {
            switch (chinesePaymentMethod)
            {
                case "现金":
                    return "cash";
                case "信用卡":
                    return "credit card";
                case "银行转账":
                    return "bank transfer";
                default:
                    return "cash"; // 默认值
            }
        }
        
        private string ConvertStatusToEnglish(string chineseStatus)
        {
            switch (chineseStatus)
            {
                case "待处理":
                    return "pending";
                case "已完成":
                    return "completed";
                case "已取消":
                    return "cancelled";
                default:
                    return "pending"; // 默认值
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // 这里可以打开添加客户的窗体
            MessageBox.Show("添加客户功能待实现。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}