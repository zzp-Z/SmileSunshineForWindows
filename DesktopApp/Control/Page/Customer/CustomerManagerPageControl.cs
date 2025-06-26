using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.Customer
{
    public partial class CustomerManagerPageControl : UserControl
    {
        private CustomerFunc _customerFunc;
        private List<Database.Customer> _customers;
        
        public CustomerManagerPageControl()
        {
            InitializeComponent();
            _customerFunc = new CustomerFunc();
            InitializeControl();
            LoadCustomers();
        }
        
        private void InitializeControl()
        {
            // 设置ListView属性
            listViewCustomers.View = View.Details;
            listViewCustomers.FullRowSelect = true;
            listViewCustomers.GridLines = true;
            listViewCustomers.MultiSelect = false;
            
            // 添加列
            listViewCustomers.Columns.Add("ID", 60);
            listViewCustomers.Columns.Add("Customer Name", 150);
            listViewCustomers.Columns.Add("Customer Address", 200);
            listViewCustomers.Columns.Add("Contact Number", 120);
        }
        
        private void LoadCustomers()
        {
            try
            {
                _customers = _customerFunc.GetAllCustomers();
                RefreshCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the customer list: {ex.Message}", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void RefreshCustomerList()
        {
            listViewCustomers.Items.Clear();
            
            foreach (var customer in _customers)
            {
                var item = new ListViewItem(customer.Id.ToString());
                item.SubItems.Add(customer.Name);
                item.SubItems.Add(customer.Address);
                item.SubItems.Add(customer.Phone);
                item.Tag = customer;
                listViewCustomers.Items.Add(item);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddCustomer();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var selectedCustomer = (Database.Customer)listViewCustomers.SelectedItems[0].Tag;
            var editForm = new EditCustomer(selectedCustomer);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var selectedCustomer = (Database.Customer)listViewCustomers.SelectedItems[0].Tag;
            
            var result = MessageBox.Show($"Are you sure you want to delete customer '{selectedCustomer.Name}' ?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_customerFunc.DeleteCustomer(selectedCustomer.Id))
                    {
                        MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers();
                    }
                    else
                    {
                        MessageBox.Show("Customer deletion failed, please try again.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the customer: {ex.Message}", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.Trim();
            
            if (string.IsNullOrEmpty(searchText))
            {
                RefreshCustomerList();
                return;
            }
            
            try
            {
                var searchResults = _customerFunc.SearchCustomersByName(searchText);
                _customers = searchResults;
                RefreshCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for customers: {ex.Message}", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadCustomers();
        }
        
        private void listViewCustomers_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}