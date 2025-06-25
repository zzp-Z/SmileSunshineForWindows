using System;
using System.Windows.Forms;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.Customer
{
    public partial class AddCustomer : Form
    {
        private CustomerFunc _customerFunc;
        
        public AddCustomer()
        {
            InitializeComponent();
            _customerFunc = new CustomerFunc();
            InitializeForm();
        }
        
        private void InitializeForm()
        {
            this.Text = "添加客户";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;
                
                var customer = new Database.Customer
                {
                    Name = txtName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };
                
                if (_customerFunc.CreateCustomer(customer))
                {
                    MessageBox.Show("客户添加成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("客户添加失败，请重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加客户时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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