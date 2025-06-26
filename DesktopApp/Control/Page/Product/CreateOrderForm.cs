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
                    MessageBox.Show("No customer information found, please add the customer first.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load customer information: {ex.Message}", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadOrderItems()
        {
            listViewOrderItems.Items.Clear();
            
            foreach (var item in _orderItems)
            {
                var listItem = new ListViewItem(item.Product.Name);
                listItem.SubItems.Add(item.Quantity.ToString());
                listItem.SubItems.Add($"${(item.Product.PriceCents ?? 0) / 100.0m:F2}");
                listItem.SubItems.Add($"${(item.Product.PriceCents ?? 0) * item.Quantity / 100.0m:F2}");
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
            
            lblProductAmount.Text = $"${productAmount:F2}";
            lblTaxAmount.Text = $"${taxAmount:F2}";
            lblTotalAmount.Text = $"${totalAmount:F2}";
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
                    MessageBox.Show("Order creation failed. Please check the order information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // 检查库存是否充足
                foreach (var item in _orderItems)
                {
                    if (!_productFunc.CheckProductStock(item.Product.Id, item.Quantity))
                    {
                        MessageBox.Show($"The inventory of product '{{item.Product.Name}}' is insufficient. Currently, {item.Quantity} pieces are needed. Please check the inventory.", "Inventory is insufficient.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show($"Failed to reduce the inventory of product '{item.Product.Name}'.", "Inventory update failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Failed to create order item. The order may be incomplete, and the inventory change has been rolled back.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Order created successfully. Product inventory has been updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool ValidateInput()
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Please select a customer.", "Verification failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
            {
                MessageBox.Show("Please enter the order number.", "Verification failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtShippingAddress.Text))
            {
                MessageBox.Show("Please enter the delivery address.", "Verification failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (_orderItems.Count == 0)
            {
                MessageBox.Show("There are no items in the order.", "Verification failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                case "Cash":
                    return "cash";
                case "Credit Card":
                    return "credit card";
                case "Bank Transfer":
                    return "bank transfer";
                default:
                    return "cash"; // 默认值
            }
        }
        
        private string ConvertStatusToEnglish(string chineseStatus)
        {
            switch (chineseStatus)
            {
                case "Pending":
                    return "pending";
                case "Completed":
                    return "completed";
                case "Cancelled":
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
            MessageBox.Show("Adding customer function is pending implementation.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}