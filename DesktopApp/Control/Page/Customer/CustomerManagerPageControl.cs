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
            listViewCustomers.Columns.Add("客户姓名", 150);
            listViewCustomers.Columns.Add("客户地址", 200);
            listViewCustomers.Columns.Add("联系电话", 120);
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
                MessageBox.Show($"加载客户列表时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("请选择要编辑的客户。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("请选择要删除的客户。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var selectedCustomer = (Database.Customer)listViewCustomers.SelectedItems[0].Tag;
            
            var result = MessageBox.Show($"确定要删除客户 '{selectedCustomer.Name}' 吗？", "确认删除", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_customerFunc.DeleteCustomer(selectedCustomer.Id))
                    {
                        MessageBox.Show("客户删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers();
                    }
                    else
                    {
                        MessageBox.Show("客户删除失败，请重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除客户时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"搜索客户时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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