using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;
using DesktopApp.Database.Func;

namespace DesktopApp.Control.Page.SystemManage.Permission
{
    public partial class PermissionManagePageControl : UserControl
    {
        private readonly PermissionFunc _permissionFunc;
        private List<Database.Permission> _permissions;

        public PermissionManagePageControl()
        {
            InitializeComponent();
            _permissionFunc = new PermissionFunc();
            InitializeDataGridView();
            LoadPermissions();
        }

        private void InitializeDataGridView()
        {
            // 设置列
            dgvPermissions.Columns.Clear();
            dgvPermissions.Columns.Add("Id", "ID");
            dgvPermissions.Columns.Add("PermissionName", "Permission Name");
            dgvPermissions.Columns.Add("ApiPath", "API Path");
            dgvPermissions.Columns.Add("Description", "Description");
            dgvPermissions.Columns.Add("CreatedAt", "Creation time");
            dgvPermissions.Columns.Add("UpdatedAt", "Update time");

            // 设置列宽
            dgvPermissions.Columns["Id"].Width = 60;
            dgvPermissions.Columns["PermissionName"].Width = 150;
            dgvPermissions.Columns["ApiPath"].Width = 200;
            dgvPermissions.Columns["Description"].Width = 200;
            dgvPermissions.Columns["CreatedAt"].Width = 120;
            dgvPermissions.Columns["UpdatedAt"].Width = 120;

            // 隐藏ID列
            dgvPermissions.Columns["Id"].Visible = false;
        }

        private void LoadPermissions()
        {
            try
            {
                _permissions = _permissionFunc.GetAllPermissions();
                dgvPermissions.Rows.Clear();

                foreach (var permission in _permissions)
                {
                    dgvPermissions.Rows.Add(
                        permission.Id,
                        permission.PermissionName,
                        permission.ApiPath,
                        permission.Description,
                        permission.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                        permission.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load permission data：{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddPermission();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadPermissions(); // 刷新数据
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPermissions.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a record to edit", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvPermissions.SelectedRows[0];
            var permissionId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            
            var editForm = new EditPermission(permissionId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadPermissions(); // 刷新数据
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPermissions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the record to delete", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedCount = dgvPermissions.SelectedRows.Count;
            var result = MessageBox.Show($"Confirm that you want to delete the selected {selectedCount} permission record?？", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var deleteCount = 0;
                    var failCount = 0;

                    foreach (DataGridViewRow row in dgvPermissions.SelectedRows)
                    {
                        var permissionId = Convert.ToInt32(row.Cells["Id"].Value);
                        if (_permissionFunc.DeletePermission(permissionId))
                        {
                            deleteCount++;
                        }
                        else
                        {
                            failCount++;
                        }
                    }

                    if (failCount > 0)
                    {
                        MessageBox.Show($"Deletion completed: Success {deleteCount} ，Fail {failCount} ", "Delete Results", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"Successfully deleted {deleteCount} record", "Deleted successfully", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadPermissions(); // 刷新数据
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Deletion failed：{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPermissions();
        }
    }
}