using System;
using System.Windows.Forms;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.Customer
{
    public partial class EditCustomer : Form
    {
        private CustomerFunc _customerFunc;
        private Database.Customer _customer;
        
        public EditCustomer(Database.Customer customer)
        {
            InitializeComponent();
            _customerFunc = new CustomerFunc();
            _customer = customer;
            InitializeForm();
            LoadCustomerData();
        }
        
        private void InitializeForm()
        {
            this.Text = "编辑客户";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        
        private void LoadCustomerData()
        {
            if (_customer != null)
            {
                txtName.Text = _customer.Name;
                txtAddress.Text = _customer.Address;
                txtPhone.Text = _customer.Phone;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;
                
                _customer.Name = txtName.Text.Trim();
                _customer.Address = txtAddress.Text.Trim();
                _customer.Phone = txtPhone.Text.Trim();
                
                if (_customerFunc.UpdateCustomer(_customer))
                {
                    MessageBox.Show("客户信息更新成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("客户信息更新失败，请重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新客户信息时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入客户姓名。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("请输入客户电话。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            
            return true;
        }
    }
}