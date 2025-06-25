using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;

namespace DesktopApp.Control.Page.SystemManage.DepartmentManage
{
    public partial class DepartmentManagePageControl : UserControl
    {
        private List<Department> _departments;
        private readonly Database.Func.DepartmentFunc  _departmentFunc;

        public DepartmentManagePageControl()
        {
            _departmentFunc = new Database.Func.DepartmentFunc();
            InitializeComponent();
            InitializeDataGridView();
            LoadData();
        }

        private void InitializeData()
        {
            // 初始化数据
            _departments = _departmentFunc.GetAllDepartments();
        }

        private void InitializeDataGridView()
        {
            // 设置表格属性
            dataGridViewDepartments.MultiSelect = true;
            dataGridViewDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDepartments.AutoGenerateColumns = false;

            // 添加列
            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 60,
                ReadOnly = true
            });

            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Department Name",
                DataPropertyName = "Name",
                Width = 150
            });

            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Department Description",
                DataPropertyName = "Description",
                Width = 250
            });

            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedAt",
                HeaderText = "Creation Time",
                DataPropertyName = "CreatedAt",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UpdatedAt",
                HeaderText = "Update Time",
                DataPropertyName = "UpdatedAt",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });
        }

        private void LoadData()
        {
            InitializeData();
            dataGridViewDepartments.DataSource = null;
            dataGridViewDepartments.DataSource = _departments;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new DepartmentAddEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newDepartment = new Department
                    {
                        Name = addForm.DepartmentName,
                        Description = addForm.DepartmentDescription,
                    };
                    _departmentFunc.CreateDepartment(newDepartment);
                    LoadData();
                    MessageBox.Show("**Department added successfully!**", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string errorMessage = GetUserFriendlyErrorMessage(ex.Message);
                    MessageBox.Show($"Failed to add department:{errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the department to edit!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridViewDepartments.SelectedRows.Count > 1)
            {
                MessageBox.Show("Only one department can be selected for editing!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedDepartment = (Department)dataGridViewDepartments.SelectedRows[0].DataBoundItem;
            var editForm = new DepartmentAddEditForm(selectedDepartment);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Department edited successfully!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the department to delete!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete the selected {dataGridViewDepartments.SelectedRows.Count} departments?", 
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    var selectedDepartments = dataGridViewDepartments.SelectedRows.Cast<DataGridViewRow>()
                        .Select(row => (Department)row.DataBoundItem).ToList();
                    
                    foreach (var dept in selectedDepartments)
                    {
                        _departmentFunc.DeleteDepartment(dept.Id);
                    }
                    
                    LoadData();
                    MessageBox.Show("Department deleted successfully!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string errorMessage = GetUserFriendlyErrorMessage(ex.Message);
                    MessageBox.Show($"Failed to delete department:{errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Data refreshed successfully!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetUserFriendlyErrorMessage(string originalError)
        {
            if (string.IsNullOrEmpty(originalError))
                return "Unknown error";

            // 检查外键约束错误
            if (originalError.Contains("foreign key constraint fails"))
            {
                if (originalError.Contains("`role`") && originalError.Contains("department_id"))
                {
                    return "Please delete department roles first.";
                }
                return "There is associated data, please delete the relevant records first.";
            }

            // 检查唯一约束错误
            if (originalError.Contains("Duplicate entry") || originalError.Contains("UNIQUE constraint"))
            {
                return "The department name already exists. Please use another name.";
            }

            // 检查非空约束错误
            if (originalError.Contains("cannot be null") || originalError.Contains("NOT NULL constraint"))
            {
                return "Required fields cannot be empty.";
            }

            // 检查数据长度错误
            if (originalError.Contains("Data too long"))
            {
                return "The input data is too long. Please shorten the content.";
            }

            // 返回原始错误信息（简化版）
            return originalError.Length > 100 ? originalError.Substring(0, 100) + "..." : originalError;
        }
    }
}