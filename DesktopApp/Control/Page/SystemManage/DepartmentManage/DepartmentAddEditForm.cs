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
            _departmentFunc = new Database.Func.DepartmentFunc();
            InitializeComponent();
            // _isEditMode = false;
            this.Text = "Add Department";
        }

        public DepartmentAddEditForm(Department department)
        {
            _departmentFunc = new Database.Func.DepartmentFunc();
            InitializeComponent();
            _department = department;
            // _isEditMode = true;
            this.Text = "Edit Department";
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
                    string operation = _department == null ? "Add" : "Update";
                    MessageBox.Show($"{operation}Department Failure:{errorMessage}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please enter the department name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtName.Text.Trim().Length > 50)
            {
                MessageBox.Show("The department name cannot exceed 50 characters!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtDescription.Text.Trim().Length > 200)
            {
                MessageBox.Show("The department description cannot exceed 200 characters!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }

        private string GetUserFriendlyErrorMessage(string originalError)
        {
            if (string.IsNullOrEmpty(originalError))
                return "Unknown Error";

            // 检查外键约束错误
            if (originalError.Contains("foreign key constraint fails"))
            {
                if (originalError.Contains("`role`") && originalError.Contains("department_id"))
                {
                    return "Please delete the department roles first.";
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
                return "Input data is too long, please shorten the content.";
            }

            // 返回原始错误信息（简化版）
            return originalError.Length > 100 ? originalError.Substring(0, 100) + "..." : originalError;
        }
    }
}