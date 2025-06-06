using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.SystemManage.UserManage
{
    public partial class UserAddEditForm : Form
    {
        private readonly DepartmentFunc _departmentFunc;
        private readonly RoleFunc _roleFunc;
        private readonly UserFunc _userFunc;
        private readonly User _editingUser;
        private readonly bool _isEditMode;
        private List<Department> _departments;
        private List<Role> _roles;

        public UserAddEditForm(DepartmentFunc departmentFunc, RoleFunc roleFunc, UserFunc userFunc, User editingUser = null)
        {
            _departmentFunc = departmentFunc;
            _roleFunc = roleFunc;
            _userFunc = userFunc;
            _editingUser = editingUser;
            _isEditMode = editingUser != null;

            InitializeComponent();
            LoadDepartments();
            SetupForm();
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
                    // 手动加载第一个部门的角色数据
                    LoadRolesByDepartment(_departments[0].Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载部门数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRolesByDepartment(int departmentId)
        {
            try
            {
                _roles = _roleFunc.GetRolesByDepartmentId(departmentId);
                roleComboBox.DataSource = _roles;
                roleComboBox.DisplayMember = "RoleName";
                roleComboBox.ValueMember = "Id";

                if (_roles.Count > 0)
                {
                    roleComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载角色数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupForm()
        {
            this.Text = _isEditMode ? "编辑用户" : "添加用户";
            saveButton.Text = _isEditMode ? "保存" : "添加";

            // 设置性别下拉框
            genderComboBox.Items.Clear();
            genderComboBox.Items.Add("男");
            genderComboBox.Items.Add("女");
            genderComboBox.SelectedIndex = 0;

            if (_isEditMode && _editingUser != null)
            {
                // 填充编辑数据
                usernameTextBox.Text = _editingUser.Username;
                realNameTextBox.Text = _editingUser.RealName;
                emailTextBox.Text = _editingUser.Email;
                phoneTextBox.Text = _editingUser.Phone;
                // 将数据库中的英文性别值转换为中文显示
                genderComboBox.Text = _editingUser.Gender == "male" ? "男" : "女";
                
                // 编辑模式下隐藏密码相关控件
                passwordLabel.Visible = false;
                passwordTextBox.Visible = false;
            }
            else
            {
                // 创建模式下隐藏密码相关控件，使用默认密码
                passwordLabel.Visible = false;
                passwordTextBox.Visible = false;
            }
        }

        private void departmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (departmentComboBox.SelectedValue != null && departmentComboBox.SelectedValue is int departmentId)
            {
                LoadRolesByDepartment(departmentId);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                // 将中文性别转换为数据库对应的英文值
                string genderValue = genderComboBox.Text == "男" ? "male" : "female";
                
                var user = new User
                {
                    Username = usernameTextBox.Text.Trim(),
                    RealName = realNameTextBox.Text.Trim(),
                    Email = emailTextBox.Text.Trim(),
                    Phone = phoneTextBox.Text.Trim(),
                    Gender = genderValue
                };

                if (_isEditMode)
                {
                    user.Id = _editingUser.Id;
                    // 编辑模式下保持原密码不变
                    user.Password = _editingUser.Password;
                    
                    if (_userFunc.UpdateUser(user))
                    {
                        // 更新用户角色
                        if (roleComboBox.SelectedValue is int roleId)
                        {
                            // 这里简化处理，实际应该先删除旧角色再添加新角色
                            _userFunc.AddRoleToUser(user.Id, roleId);
                        }
                        
                        MessageBox.Show("用户更新成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户更新失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    user.Password = "123123"; // 默认密码
                    
                    if (_userFunc.CreateUser(user))
                    {
                        // 添加用户角色
                        if (roleComboBox.SelectedValue is int roleId)
                        {
                            // 获取新创建用户的ID（这里简化处理，实际应该从CreateUser返回ID）
                            var createdUser = _userFunc.GetAllUsers().LastOrDefault(u => u.Username == user.Username);
                            if (createdUser != null)
                            {
                                _userFunc.AddRoleToUser(createdUser.Id, roleId);
                            }
                        }
                        
                        MessageBox.Show("用户创建成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户创建失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                MessageBox.Show("请输入用户名。", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernameTextBox.Focus();
                return false;
            }

            // 创建和编辑模式都不需要验证密码

            if (string.IsNullOrWhiteSpace(realNameTextBox.Text))
            {
                MessageBox.Show("请输入真实姓名。", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                realNameTextBox.Focus();
                return false;
            }

            if (departmentComboBox.SelectedValue == null)
            {
                MessageBox.Show("请选择部门。", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (roleComboBox.SelectedValue == null)
            {
                MessageBox.Show("请选择角色。", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}