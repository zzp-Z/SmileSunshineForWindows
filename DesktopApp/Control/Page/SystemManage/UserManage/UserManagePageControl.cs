using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;

namespace DesktopApp.Control.Page.SystemManage.UserManage
{
    public partial class UserManagePageControl : UserControl
    {
        private readonly Database.Func.DepartmentFunc _departmentFunc;
        private readonly Database.Func.RoleFunc _roleFunc;
        private readonly Database.Func.UserFunc _userFunc;
        private List<Department> _departments;
        private List<User> _currentUsers;

        public UserManagePageControl()
        {
            _departmentFunc = new Database.Func.DepartmentFunc();
            _roleFunc = new Database.Func.RoleFunc();
            _userFunc = new Database.Func.UserFunc();
            
            InitializeComponent();
            SetupDataGridView();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                _departments = _departmentFunc.GetAllDepartments();
                departmentComboBox.DataSource = _departments;
                departmentComboBox.DisplayMember = "Name";
                departmentComboBox.ValueMember = "Id";
                
                if (_departments.Count > 0)
                {
                    departmentComboBox.SelectedIndex = 0;
                    // 手动加载第一个部门的用户数据
                    LoadUsersByDepartment(_departments[0].Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load department data.{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            usersDataGridView.MultiSelect = true;
            usersDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            // 设置列
            usersDataGridView.Columns.Clear();
            usersDataGridView.Columns.Add("Id", "ID");
            usersDataGridView.Columns.Add("Username", "Username");
            usersDataGridView.Columns.Add("RealName", "Real Name");
            usersDataGridView.Columns.Add("Gender", "Gender");
            usersDataGridView.Columns.Add("Email", "Email");
            usersDataGridView.Columns.Add("Phone", "Phone");
            usersDataGridView.Columns.Add("CreatedAt", "CreatedAt");
            
            // 隐藏ID列
            usersDataGridView.Columns["Id"].Visible = false;
            
            // 设置列宽
            usersDataGridView.Columns["Username"].Width = 120;
            usersDataGridView.Columns["RealName"].Width = 100;
            usersDataGridView.Columns["Gender"].Width = 60;
            usersDataGridView.Columns["Email"].Width = 150;
            usersDataGridView.Columns["Phone"].Width = 120;
            usersDataGridView.Columns["CreatedAt"].Width = 150;
        }

        private void LoadUsersByDepartment(int departmentId)
        {
            try
            {
                _currentUsers = _userFunc.GetUsersByDepartmentId(departmentId);
                usersDataGridView.Rows.Clear();
                
                foreach (var user in _currentUsers)
                {
                    // 将数据库中的英文性别值转换为中文显示
                    string genderDisplay = user.Gender == "male" ? "男" : "女";
                    
                    usersDataGridView.Rows.Add(
                        user.Id,
                        user.Username,
                        user.RealName,
                        genderDisplay,
                        user.Email,
                        user.Phone,
                        user.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load user data. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void departmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (departmentComboBox.SelectedValue != null && departmentComboBox.SelectedValue is int departmentId)
            {
                LoadUsersByDepartment(departmentId);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addForm = new UserAddEditForm(_departmentFunc, _roleFunc, _userFunc);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // 刷新当前部门的用户列表
                if (departmentComboBox.SelectedValue is int departmentId)
                {
                    LoadUsersByDepartment(departmentId);
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count == 1)
            {
                var selectedRow = usersDataGridView.SelectedRows[0];
                var userId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                var user = _userFunc.GetUserById(userId);
                
                if (user != null)
                {
                    var editForm = new UserAddEditForm(_departmentFunc, _roleFunc, _userFunc, user);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // 刷新当前部门的用户列表
                        if (departmentComboBox.SelectedValue is int departmentId)
                        {
                            LoadUsersByDepartment(departmentId);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count > 0)
            {
                var selectedUserIds = new List<int>();
                foreach (DataGridViewRow row in usersDataGridView.SelectedRows)
                {
                    selectedUserIds.Add(Convert.ToInt32(row.Cells["Id"].Value));
                }

                var result = MessageBox.Show(
                    $"Are you sure you want to delete the selected {selectedUserIds.Count} users? This operation cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    var successCount = 0;
                    var failCount = 0;

                    foreach (var userId in selectedUserIds)
                    {
                        try
                        {
                            if (_userFunc.DeleteUser(userId))
                            {
                                successCount++;
                            }
                            else
                            {
                                failCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            failCount++;
                            Console.WriteLine($"Delete User {userId} Failed: {ex.Message}");
                        }
                    }

                    if (failCount > 0)
                    {
                        MessageBox.Show(
                            $"Deletion completed. Success: {successCount}, Failure: {failCount}.",
                            "Delete Results",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Successfully deleted {successCount} users.",
                            "Delete Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }

                    // 刷新当前部门的用户列表
                    if (departmentComboBox.SelectedValue is int departmentId)
                    {
                        LoadUsersByDepartment(departmentId);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the users to delete.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void resetPasswordButton_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count > 0)
            {
                var selectedUserIds = new List<int>();
                foreach (DataGridViewRow row in usersDataGridView.SelectedRows)
                {
                    selectedUserIds.Add(Convert.ToInt32(row.Cells["Id"].Value));
                }

                var result = MessageBox.Show(
                    $"Are you sure you want to reset the passwords of the selected {selectedUserIds.Count} users to the default password (123123)?",
                    "Confirm Password Reset",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    var successCount = 0;
                    var failCount = 0;

                    foreach (var userId in selectedUserIds)
                    {
                        try
                        {
                            if (_userFunc.ResetUserPassword(userId))
                            {
                                successCount++;
                            }
                            else
                            {
                                failCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            failCount++;
                            Console.WriteLine($"Reset User {userId} Password Failed: {ex.Message}");
                        }
                    }

                    if (failCount > 0)
                    {
                        MessageBox.Show(
                            $"Password reset completed. Success: {successCount}, Failure: {failCount}.",
                            "Reset Results",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Successfully reset the passwords of {successCount} users.",
                            "Reset Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the users to reset passwords for.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}