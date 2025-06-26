using System;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.SystemManage.Permission
{
    public partial class EditPermission : Form
    {
        private readonly PermissionFunc _permissionFunc;
        private readonly int _permissionId;
        private Database.Permission _currentPermission;

        public EditPermission(int permissionId)
        {
            InitializeComponent();
            _permissionFunc = new PermissionFunc();
            _permissionId = permissionId;
            LoadPermissionData();
        }

        private void LoadPermissionData()
        {
            try
            {
                _currentPermission = _permissionFunc.GetPermissionById(_permissionId);
                if (_currentPermission != null)
                {
                    txtPermissionName.Text = _currentPermission.PermissionName;
                    txtApiPath.Text = _currentPermission.ApiPath;
                    txtDescription.Text = _currentPermission.Description;
                }
                else
                {
                    MessageBox.Show("未找到指定的权限记录", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载权限数据失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 验证输入
            if (string.IsNullOrWhiteSpace(txtPermissionName.Text))
            {
                MessageBox.Show("请输入权限名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPermissionName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApiPath.Text))
            {
                MessageBox.Show("请输入API路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApiPath.Focus();
                return;
            }

            try
            {
                _currentPermission.PermissionName = txtPermissionName.Text.Trim();
                _currentPermission.ApiPath = txtApiPath.Text.Trim();
                _currentPermission.Description = txtDescription.Text.Trim();

                if (_permissionFunc.UpdatePermission(_currentPermission))
                {
                    MessageBox.Show("权限更新成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("权限更新失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新权限时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}