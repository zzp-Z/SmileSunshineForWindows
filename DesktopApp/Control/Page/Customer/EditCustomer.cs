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
            this.Text = "Edit Customer";
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
                    MessageBox.Show("Customer information updated successfully！", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Customer information update failed, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating customer information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please enter the customer name.", "Authentication failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter the customer's phone number.", "Authentication failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            
            return true;
        }
    }
}