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
                MessageBox.Show("Please enter the permission name", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPermissionName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApiPath.Text))
            {
                MessageBox.Show("Please enter the API path", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Permission added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add permissions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding permissions：{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}