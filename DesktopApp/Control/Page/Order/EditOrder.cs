using System;
using System.Globalization;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.Order
{
    public partial class EditOrder : UserControl, IOrderEditor
    {
        private SalesOrder currentOrder;
        private OrderFunc orderFunc;
        
        public EditOrder()
        {
            InitializeComponent();
            orderFunc = new OrderFunc();
        }
        
        public void LoadOrder(SalesOrder order)
        {
            currentOrder = order;
            PopulateFields();
        }
        
        private void PopulateFields()
        {
            if (currentOrder == null) return;
            
            txtOrderNumber.Text = currentOrder.OrderNumber ?? string.Empty;
            txtCustomerId.Text = currentOrder.CustomerId.ToString();
            
            // 设置支付方式
            if (!string.IsNullOrEmpty(currentOrder.PaymentMethod))
            {
                int paymentIndex = cmbPaymentMethod.FindStringExact(currentOrder.PaymentMethod);
                if (paymentIndex >= 0)
                    cmbPaymentMethod.SelectedIndex = paymentIndex;
            }
            
            // 设置日期
            if (currentOrder.OrderDate.HasValue)
                dtpOrderDate.Value = currentOrder.OrderDate.Value;
            else
                dtpOrderDate.Value = DateTime.Now;
                
            if (currentOrder.DeliveryDate.HasValue)
                dtpDeliveryDate.Value = currentOrder.DeliveryDate.Value;
            else
                dtpDeliveryDate.Value = DateTime.Now.AddDays(7);
            
            // 设置状态
            if (!string.IsNullOrEmpty(currentOrder.Status))
            {
                int statusIndex = cmbStatus.FindStringExact(currentOrder.Status);
                if (statusIndex >= 0)
                    cmbStatus.SelectedIndex = statusIndex;
            }
            
            txtShippingAddress.Text = currentOrder.ShippingAddress ?? string.Empty;
            
            // 设置总金额（转换为元）
            if (currentOrder.TotalAmountCents.HasValue)
            {
                decimal amount = currentOrder.TotalAmountCents.Value / 100.0m;
                txtTotalAmount.Text = amount.ToString("F2");
            }
            
            chkIsCustomized.Checked = currentOrder.IsCustomized;
            txtSpecialRequirements.Text = currentOrder.SpecialRequirements ?? string.Empty;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
                
            try
            {
                UpdateOrderFromFields();
                
                bool success = orderFunc.UpdateSalesOrder(currentOrder);
                if (success)
                {
                    MessageBox.Show("订单更新成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 设置对话框结果为OK
                    var parentForm = this.FindForm();
                    if (parentForm != null)
                    {
                        parentForm.DialogResult = DialogResult.OK;
                        parentForm.Close();
                    }
                }
                else
                {
                    MessageBox.Show("订单更新失败，请重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存订单时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.DialogResult = DialogResult.Cancel;
                parentForm.Close();
            }
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
            {
                MessageBox.Show("请输入订单号", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrderNumber.Focus();
                return false;
            }
            
            if (!int.TryParse(txtCustomerId.Text, out _))
            {
                MessageBox.Show("请输入有效的客户ID", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerId.Focus();
                return false;
            }
            
            if (cmbPaymentMethod.SelectedIndex < 0)
            {
                MessageBox.Show("请选择支付方式", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentMethod.Focus();
                return false;
            }
            
            if (cmbStatus.SelectedIndex < 0)
            {
                MessageBox.Show("请选择订单状态", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }
            
            if (!string.IsNullOrWhiteSpace(txtTotalAmount.Text))
            {
                if (!decimal.TryParse(txtTotalAmount.Text, out decimal amount) || amount < 0)
                {
                    MessageBox.Show("请输入有效的总金额", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTotalAmount.Focus();
                    return false;
                }
            }
            
            return true;
        }
        
        private void UpdateOrderFromFields()
        {
            currentOrder.OrderNumber = txtOrderNumber.Text.Trim();
            currentOrder.CustomerId = int.Parse(txtCustomerId.Text);
            currentOrder.PaymentMethod = cmbPaymentMethod.SelectedItem.ToString();
            currentOrder.OrderDate = dtpOrderDate.Value;
            currentOrder.DeliveryDate = dtpDeliveryDate.Value;
            currentOrder.Status = cmbStatus.SelectedItem.ToString();
            currentOrder.ShippingAddress = txtShippingAddress.Text.Trim();
            
            // 转换总金额为分
            if (!string.IsNullOrWhiteSpace(txtTotalAmount.Text))
            {
                if (decimal.TryParse(txtTotalAmount.Text, out decimal amount))
                {
                    currentOrder.TotalAmountCents = (int)(amount * 100);
                }
            }
            
            currentOrder.IsCustomized = chkIsCustomized.Checked;
            currentOrder.SpecialRequirements = txtSpecialRequirements.Text.Trim();
        }
    }
}