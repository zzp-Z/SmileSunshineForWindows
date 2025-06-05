using System;
using System.Windows.Forms;
using DesktopApp.Database;

namespace DesktopApp.Control.Page.SystemManage.DepartmentManage
{
    public partial class DepartmentAddEditForm : Form
    {
        private readonly Database.Func.DepartmentFunc  _departmentFunc;
        public string DepartmentName { get; private set; }
        public string DepartmentDescription { get; private set; }
        
        private Department _department;
        // private bool _isEditMode;

        public DepartmentAddEditForm()
        {
            Engine dbEngine = Engine.Instance;
            _departmentFunc = new Database.Func.DepartmentFunc(dbEngine);
            InitializeComponent();
            // _isEditMode = false;
            this.Text = "添加部门";
        }

        public DepartmentAddEditForm(Department department)
        {
            Engine dbEngine = Engine.Instance;
            _departmentFunc = new Database.Func.DepartmentFunc(dbEngine);
            InitializeComponent();
            _department = department;
            // _isEditMode = true;
            this.Text = "编辑部门";
            LoadDepartmentData();
        }

        private void LoadDepartmentData()
        {
            if (_department != null)
            {
                txtName.Text = _department.Name;
                txtDescription.Text = _department.Description;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    if (_department == null)
                    {
                        // 添加模式
                        DepartmentName = txtName.Text.Trim();
                        DepartmentDescription = txtDescription.Text.Trim();
                    }
                    else
                    {
                        // 编辑模式
                        _department.Name = txtName.Text.Trim();
                        _department.Description = txtDescription.Text.Trim();
                        _departmentFunc.UpdateDepartment(_department);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    string errorMessage = GetUserFriendlyErrorMessage(ex.Message);
                    string operation = _department == null ? "添加" : "更新";
                    MessageBox.Show($"{operation}部门失败：{errorMessage}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                MessageBox.Show("请输入部门名称！", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtName.Text.Trim().Length > 50)
            {
                MessageBox.Show("部门名称不能超过50个字符！", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtDescription.Text.Trim().Length > 200)
            {
                MessageBox.Show("部门描述不能超过200个字符！", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }

        private string GetUserFriendlyErrorMessage(string originalError)
        {
            if (string.IsNullOrEmpty(originalError))
                return "未知错误";

            // 检查外键约束错误
            if (originalError.Contains("foreign key constraint fails"))
            {
                if (originalError.Contains("`role`") && originalError.Contains("department_id"))
                {
                    return "请先删除部门角色";
                }
                return "存在关联数据，请先删除相关记录";
            }

            // 检查唯一约束错误
            if (originalError.Contains("Duplicate entry") || originalError.Contains("UNIQUE constraint"))
            {
                return "部门名称已存在，请使用其他名称";
            }

            // 检查非空约束错误
            if (originalError.Contains("cannot be null") || originalError.Contains("NOT NULL constraint"))
            {
                return "必填字段不能为空";
            }

            // 检查数据长度错误
            if (originalError.Contains("Data too long"))
            {
                return "输入数据过长，请缩短内容";
            }

            // 返回原始错误信息（简化版）
            return originalError.Length > 100 ? originalError.Substring(0, 100) + "..." : originalError;
        }
    }
}