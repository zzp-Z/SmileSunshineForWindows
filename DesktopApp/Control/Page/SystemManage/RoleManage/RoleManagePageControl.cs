using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;

namespace DesktopApp.Control.Page.SystemManage.RoleManage
{
    public partial class RoleManagePageControl : UserControl
    {
        private List<Department> departments;
        private DataTable roleDataTable;
        private readonly Database.Func.DepartmentFunc  _departmentFunc;
        private readonly Database.Func.RoleFunc  _roleFunc;

        public RoleManagePageControl()
        {
            _departmentFunc = new Database.Func.DepartmentFunc();
            _roleFunc = new Database.Func.RoleFunc();
            InitializeComponent();
            InitializeData();
            InitializeUi();
        }

        private void InitializeData()
        {
            // 初始化数据 - 部门
            departments = _departmentFunc.GetAllDepartments();
            
        }

        private void InitializeUi()
        {
            // 初始化部门下拉框
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "Id";
            cmbDepartment.DataSource = departments;

            // 初始化DataGridView
            InitializeDataGridView();

            // 加载第一个部门的角色数据
            if (departments.Count > 0)
            {
                LoadRolesByDepartment(departments[0].Id);
            }
        }

        private void InitializeDataGridView()
        {
            // 创建DataTable
            roleDataTable = new DataTable();
            roleDataTable.Columns.Add("Id", typeof(int));
            roleDataTable.Columns.Add("Character Name", typeof(string));
            roleDataTable.Columns.Add("Department", typeof(string));
            roleDataTable.Columns.Add("Description", typeof(string));
            roleDataTable.Columns.Add("Creation Time", typeof(DateTime));
            roleDataTable.Columns.Add("Update Time", typeof(DateTime));

            // 绑定到DataGridView
            dgvRoles.DataSource = roleDataTable;

            // 设置列属性
            dgvRoles.Columns["Id"].Visible = false; // 隐藏ID列
            dgvRoles.Columns["Character Name"].Width = 150;
            dgvRoles.Columns["Department"].Width = 100;
            dgvRoles.Columns["Description"].Width = 200;
            dgvRoles.Columns["Creation Time"].Width = 120;
            dgvRoles.Columns["Update Time"].Width = 120;

            // 设置多选模式
            dgvRoles.MultiSelect = true;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadRolesByDepartment(int departmentId)
        {
            // 检查roleDataTable是否已初始化
            if (roleDataTable == null)
            {
                InitializeDataGridView();
            }
            roleDataTable.Clear();
            var departmentRoles = _roleFunc.GetRolesByDepartmentId(departmentId);
            var department = departments.FirstOrDefault(d => d.Id == departmentId);

            foreach (var role in departmentRoles)
            {
                roleDataTable.Rows.Add(
                    role.Id,
                    role.RoleName,
                    department?.Name ?? "Unknown Department",
                    role.Description,
                    role.CreatedAt,
                    role.UpdatedAt
                );
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedValue != null)
            {
                int departmentId = (int)cmbDepartment.SelectedValue;
                LoadRolesByDepartment(departmentId);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new RoleAddEditForm(departments, null))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    var newRole = new Role()
                    {
                        RoleName = addForm.Role.RoleName,
                        DepartmentId = addForm.Role.DepartmentId,
                        Description = addForm.Role.Description,
                    };
                    
                    if (_roleFunc.CreateRole(newRole))
                    {
                        // 获取新创建角色的ID（需要重新查询获取ID）
                        var createdRole = _roleFunc.GetAllRoles().LastOrDefault(r => 
                            r.RoleName == newRole.RoleName && 
                            r.DepartmentId == newRole.DepartmentId);
                        
                        if (createdRole != null)
                        {
                            // 分配权限给新角色
                            _roleFunc.AssignPermissionsToRole(createdRole.Id, addForm.SelectedPermissionIds);
                        }
                        
                        // 如果新角色属于当前选中的部门，刷新显示
                        if (cmbDepartment.SelectedValue != null && newRole.DepartmentId == (int)cmbDepartment.SelectedValue)
                        {
                            LoadRolesByDepartment(newRole.DepartmentId);
                        }

                        MessageBox.Show("Role added successfully!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add role!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a role to modify!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roleId = (int)dgvRoles.SelectedRows[0].Cells["Id"].Value;
            var role = _roleFunc.GetRoleById(roleId);

            if (role != null)
            {
                using (var editForm = new RoleAddEditForm(departments, role))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        role.RoleName = editForm.Role.RoleName;
                        role.DepartmentId = editForm.Role.DepartmentId;
                        role.Description = editForm.Role.Description;
                        
                        if (_roleFunc.UpdateRole(role))
                        {
                            // 更新角色权限
                            _roleFunc.AssignPermissionsToRole(role.Id, editForm.SelectedPermissionIds);
                            
                            // 刷新当前部门的显示
                            if (cmbDepartment.SelectedValue != null)
                            {
                                LoadRolesByDepartment((int)cmbDepartment.SelectedValue);
                            }

                            MessageBox.Show("Role modified successfully!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update role!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the role to delete!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete the selected {dgvRoles.SelectedRows.Count} roles?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvRoles.SelectedRows)
                {
                    _roleFunc.DeleteRole((int)row.Cells["Id"].Value);
                }


                // 刷新当前部门的显示
                if (cmbDepartment.SelectedValue != null)
                {
                    LoadRolesByDepartment((int)cmbDepartment.SelectedValue);
                }

                MessageBox.Show("Role deleted successfully!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    // 角色添加/编辑窗体
    public partial class RoleAddEditForm : Form
    {
        public Role Role { get; private set; }
        public List<int> SelectedPermissionIds { get; private set; }
        private List<Department> departments;
        private List<Database.Permission> permissions;
        private bool isEdit;
        private readonly Database.Func.PermissionFunc _permissionFunc;
        private readonly Database.Func.RoleFunc _roleFunc;

        public RoleAddEditForm(List<Department> departments, Role role)
        {
            this.departments = departments;
            this.isEdit = role != null;
            this.Role = role ?? new Role();
            this._permissionFunc = new Database.Func.PermissionFunc();
            this._roleFunc = new Database.Func.RoleFunc();
            this.SelectedPermissionIds = new List<int>();
            
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // 设置窗体标题
            this.Text = isEdit ? "Modify Role" : "Add Role";
            
            // 初始化部门下拉框
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "Id";
            cmbDepartment.DataSource = departments;

            // 加载所有权限
            LoadPermissions();

            if (isEdit)
            {
                // 编辑模式，填充现有数据
                cmbDepartment.SelectedValue = Role.DepartmentId;
                txtRoleName.Text = Role.RoleName;
                txtDescription.Text = Role.Description;
                
                // 加载角色已有的权限
                LoadRolePermissions();
            }
        }

        private void LoadPermissions()
        {
            permissions = _permissionFunc.GetAllPermissions();
            clbPermissions.Items.Clear();
            
            foreach (var permission in permissions)
            {
                clbPermissions.Items.Add(new PermissionItem
                {
                    Id = permission.Id,
                    Name = permission.PermissionName,
                    Description = permission.Description
                });
            }
        }

        private void LoadRolePermissions()
        {
            if (isEdit && Role.Id > 0)
            {
                var rolePermissionIds = _roleFunc.GetRolePermissions(Role.Id);
                
                for (int i = 0; i < clbPermissions.Items.Count; i++)
                {
                    var permissionItem = (PermissionItem)clbPermissions.Items[i];
                    if (rolePermissionIds.Contains(permissionItem.Id))
                    {
                        clbPermissions.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                MessageBox.Show("Please enter the role name!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("Please select the department!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 获取选中的权限ID
            SelectedPermissionIds.Clear();
            for (int i = 0; i < clbPermissions.Items.Count; i++)
            {
                if (clbPermissions.GetItemChecked(i))
                {
                    var permissionItem = (PermissionItem)clbPermissions.Items[i];
                    SelectedPermissionIds.Add(permissionItem.Id);
                }
            }

            Role.RoleName = txtRoleName.Text.Trim();
            Role.DepartmentId = (int)cmbDepartment.SelectedValue;
            Role.Description = txtDescription.Text.Trim();
        }
    }

    // 权限项类，用于CheckedListBox显示
    public class PermissionItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Description}";
        }
    }
}