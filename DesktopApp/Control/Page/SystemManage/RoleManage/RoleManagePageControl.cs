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
            Engine dbEngine = Engine.Instance;
            _departmentFunc = new Database.Func.DepartmentFunc(dbEngine);
            _roleFunc = new Database.Func.RoleFunc(dbEngine);
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
            roleDataTable.Columns.Add("角色名称", typeof(string));
            roleDataTable.Columns.Add("部门", typeof(string));
            roleDataTable.Columns.Add("描述", typeof(string));
            roleDataTable.Columns.Add("创建时间", typeof(DateTime));
            roleDataTable.Columns.Add("更新时间", typeof(DateTime));

            // 绑定到DataGridView
            dgvRoles.DataSource = roleDataTable;

            // 设置列属性
            dgvRoles.Columns["Id"].Visible = false; // 隐藏ID列
            dgvRoles.Columns["角色名称"].Width = 150;
            dgvRoles.Columns["部门"].Width = 100;
            dgvRoles.Columns["描述"].Width = 200;
            dgvRoles.Columns["创建时间"].Width = 120;
            dgvRoles.Columns["更新时间"].Width = 120;

            // 设置多选模式
            dgvRoles.MultiSelect = true;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadRolesByDepartment(int departmentId)
        {
            roleDataTable.Clear();
            var departmentRoles = _roleFunc.GetRolesByDepartmentId(departmentId);
            var department = departments.FirstOrDefault(d => d.Id == departmentId);

            foreach (var role in departmentRoles)
            {
                roleDataTable.Rows.Add(
                    role.Id,
                    role.RoleName,
                    department?.Name ?? "未知部门",
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
                    _roleFunc.CreateRole(newRole);
                    

                    // 如果新角色属于当前选中的部门，刷新显示
                    if (cmbDepartment.SelectedValue != null && newRole.DepartmentId == (int)cmbDepartment.SelectedValue)
                    {
                        LoadRolesByDepartment(newRole.DepartmentId);
                    }

                    MessageBox.Show("角色添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一个角色进行修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        _roleFunc.UpdateRole(role);
                        // 刷新当前部门的显示
                        if (cmbDepartment.SelectedValue != null)
                        {
                            LoadRolesByDepartment((int)cmbDepartment.SelectedValue);
                        }

                        MessageBox.Show("角色修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的角色！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"确定要删除选中的 {dgvRoles.SelectedRows.Count} 个角色吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                MessageBox.Show("角色删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    // 角色添加/编辑窗体
    public partial class RoleAddEditForm : Form
    {
        public Role Role { get; private set; }
        private List<Department> departments;
        private bool isEdit;

        private ComboBox _cmbDepartment;
        private TextBox txtRoleName;
        private TextBox txtDescription;
        private Button btnOK;
        private Button btnCancel;
        private Label lblDepartment;
        private Label lblRoleName;
        private Label lblDescription;

        public RoleAddEditForm(List<Department> departments, Role role)
        {
            this.departments = departments;
            this.isEdit = role != null;
            this.Role = role ?? new Role();
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeComponent()
        {
            this._cmbDepartment = new ComboBox();
            this.txtRoleName = new TextBox();
            this.txtDescription = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.lblDepartment = new Label();
            this.lblRoleName = new Label();
            this.lblDescription = new Label();
            this.SuspendLayout();

            // Form
            this.Text = isEdit ? "修改角色" : "添加角色";
            this.Size = new System.Drawing.Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // lblDepartment
            this.lblDepartment.Text = "部门:";
            this.lblDepartment.Location = new System.Drawing.Point(20, 20);
            this.lblDepartment.Size = new System.Drawing.Size(60, 23);

            // cmbDepartment
            this._cmbDepartment.Location = new System.Drawing.Point(90, 20);
            this._cmbDepartment.Size = new System.Drawing.Size(280, 21);
            this._cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

            // lblRoleName
            this.lblRoleName.Text = "角色名称:";
            this.lblRoleName.Location = new System.Drawing.Point(20, 60);
            this.lblRoleName.Size = new System.Drawing.Size(60, 23);

            // txtRoleName
            this.txtRoleName.Location = new System.Drawing.Point(90, 60);
            this.txtRoleName.Size = new System.Drawing.Size(280, 20);

            // lblDescription
            this.lblDescription.Text = "描述:";
            this.lblDescription.Location = new System.Drawing.Point(20, 100);
            this.lblDescription.Size = new System.Drawing.Size(60, 23);

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(90, 100);
            this.txtDescription.Size = new System.Drawing.Size(280, 60);
            this.txtDescription.Multiline = true;

            // btnOK
            this.btnOK.Text = "确定";
            this.btnOK.Location = new System.Drawing.Point(215, 180);
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Text = "取消";
            this.btnCancel.Location = new System.Drawing.Point(295, 180);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.DialogResult = DialogResult.Cancel;

            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this._cmbDepartment);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
        }

        private void InitializeForm()
        {
            // 初始化部门下拉框
            _cmbDepartment.DisplayMember = "Name";
            _cmbDepartment.ValueMember = "Id";
            _cmbDepartment.DataSource = departments;

            if (isEdit)
            {
                // 编辑模式，填充现有数据
                _cmbDepartment.SelectedValue = Role.DepartmentId;
                txtRoleName.Text = Role.RoleName;
                txtDescription.Text = Role.Description;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                MessageBox.Show("请输入角色名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("请选择部门！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Role.RoleName = txtRoleName.Text.Trim();
            Role.DepartmentId = (int)_cmbDepartment.SelectedValue;
            Role.Description = txtDescription.Text.Trim();
        }
    }
}