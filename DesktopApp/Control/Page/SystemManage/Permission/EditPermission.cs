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
                    MessageBox.Show("The specified permission record was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load permission data：{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
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
                _currentPermission.PermissionName = txtPermissionName.Text.Trim();
                _currentPermission.ApiPath = txtApiPath.Text.Trim();
                _currentPermission.Description = txtDescription.Text.Trim();

                if (_permissionFunc.UpdatePermission(_currentPermission))
                {
                    MessageBox.Show("Permissions updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Permission update failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating permissions：{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}