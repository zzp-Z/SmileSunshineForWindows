using System;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.SystemManage.Permission
{
    public partial class AddPermission : Form
    {
        private readonly PermissionFunc _permissionFunc;

        public AddPermission()
        {
            InitializeComponent();
            _permissionFunc = new PermissionFunc();
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
                var permission = new Database.Permission
                {
                    PermissionName = txtPermissionName.Text.Trim(),
                    ApiPath = txtApiPath.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                if (_permissionFunc.CreatePermission(permission))
                {
                    MessageBox.Show("权限添加成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("权限添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加权限时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}