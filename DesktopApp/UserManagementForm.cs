using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;
using ZstdSharp.Unsafe;

namespace DesktopApp
{
    public partial class UserManagementForm : Form
    {
        private readonly Database.Func.DepartmentFunc _departmentFunc;
        private readonly Database.Func.UserFunc _userFunc;
        private readonly Database.Func.RoleFunc _roleFunc;
        
        public UserManagementForm(Database.Func.DepartmentFunc departmentFunc, Database.Func.UserFunc userFunc, Database.Func.RoleFunc roleFunc)
        {
            _userFunc = userFunc;
            _roleFunc = roleFunc;
            _departmentFunc = departmentFunc;
            
            InitializeComponent();
        }
        /// <summary>
        /// 加载用户管理窗体时的事件处理函数
        /// </summary>
        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            // 加载部门数据到下拉框
            LoadDepartments();
            
            // 加载角色数据到下拉框
            LoadRoles();
            
            // 初始化性别下拉框
            if (cmbGender.Items.Count == 0)
            {
                cmbGender.Items.Add("男");
                cmbGender.Items.Add("女");
            }
            
            // 如果有部门，默认选择第一个并加载数据
            if (cmbDepartment.Items.Count > 0)
            {
                cmbDepartment.SelectedIndex = 0;
                LoadEmployeesByDepartment();
            }
        }
        /// <summary>
        /// 加载部门数据到下拉框
        /// </summary>
        private void LoadDepartments()
        {
            // 这里应该从数据库加载部门数据
            // 示例代码，实际应该使用数据库查询
            cmbDepartment.Items.Clear();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "Id";
            
            // 模拟数据，实际应该从数据库获取
            List<Department> departments = _departmentFunc.GetAllDepartments();
            
            foreach (var dept in departments)
            {
                cmbDepartment.Items.Add(dept);
            }
        }
        /// <summary>
        /// 加载角色数据到下拉框
        /// </summary>
        private void LoadRoles()
        {
            // 这里应该从数据库加载角色数据
            // 示例代码，实际应该使用数据库查询
            cmbRole.Items.Clear();
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "Id";
            
            // 模拟数据，实际应该从数据库获取
            List<Role> roles = new List<Role>
            {
                new Role { Id = 1, RoleName = "管理员" },
                new Role { Id = 2, RoleName = "普通用户" },
                new Role { Id = 3, RoleName = "经理" },
                new Role { Id = 4, RoleName = "主管" }
            };
            
            foreach (var role in roles)
            {
                cmbRole.Items.Add(role);
            }
        }
        /// <summary>
        /// 加载选中部门的员工数据到DataGridView
        /// </summary>
        private void LoadEmployeesByDepartment()
        {
            // 获取选中的部门ID
            if (cmbDepartment.SelectedItem == null) return;
            
            Department selectedDept = (Department)cmbDepartment.SelectedItem;
            int departmentId = selectedDept.Id;
            
            // 这里应该根据部门ID从数据库加载员工数据
            List<User> employees = _userFunc.GetEmployeesByDepartmentId(departmentId);
            
            
            
            // 绑定数据到DataGridView
            bindingSource.DataSource = employees;
        }
        /// <summary>
        ///加载角色数据到角色下拉框
        /// </summary>
        private void LoadRoleByDepartment()
        {
            // 获取选中的部门ID
            if (cmbDepartment.SelectedItem == null) return;
            
            Department selectedDept = (Department)cmbDepartment.SelectedItem;
            int departmentId = selectedDept.Id;
            
            // 这里应该根据部门ID从数据库加载角色数据
            // 使用数据库查询根据部门ID获取角色列表
            List<Role> roles = _roleFunc.GetRoleByDepartmentId(departmentId);
            cmbRole.DataSource = roles;
        }
        
        /// <summary>
        /// 监听部门下拉框选择变化的事件处理函数
        /// </summary>
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 当选择的部门变化时，重新加载员工数据和角色数据
            LoadEmployeesByDepartment();
            LoadRoleByDepartment();
        }
        /// <summary>
        /// 重置所有表单字段的事件处理函数
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // 重置表单
            txtName.Text = string.Empty;
            cmbGender.SelectedIndex = -1;
            cmbRole.SelectedIndex = -1;
            txtRemark.Text = string.Empty;
        }
        /// <summary>
        /// 提交表单数据的事件处理函数
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 验证表单
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show("请选择性别", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("请选择角色", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // 获取表单数据
            string name = txtName.Text.Trim();
            string gender = cmbGender.SelectedItem.ToString();
            Role selectedRole = (Role)cmbRole.SelectedItem;
            string remark = txtRemark.Text.Trim();
            Database.User newUser = new Database.User
            {
                Username = name,
                Password = "123456",
                Gender = gender,
            };
            newUser = _userFunc.CreateUser(newUser);
            _roleFunc.AssignRoleToUser(newUser.Id, selectedRole.Id);
            // 这里应该将数据保存到数据库
            // 示例代码，实际应该使用数据库操作
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // 重新加载员工数据
            LoadEmployeesByDepartment();
            
            // 重置表单
            btnReset_Click(sender, e);
        }
    }
}