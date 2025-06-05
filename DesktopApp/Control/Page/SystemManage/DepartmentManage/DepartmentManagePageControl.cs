using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp.Database;

namespace DesktopApp.Control.Page.SystemManage.DepartmentManage
{
    public partial class DepartmentManagePageControl : UserControl
    {
        private List<Department> _departments;
        private readonly Database.Func.DepartmentFunc  _departmentFunc;

        public DepartmentManagePageControl()
        {
            Engine dbEngine = Engine.Instance;
            _departmentFunc = new Database.Func.DepartmentFunc(dbEngine);
            InitializeComponent();
            InitializeDataGridView();
            LoadData();
        }

        private void InitializeData()
        {
            // 初始化数据
            _departments = _departmentFunc.GetAllDepartments();
        }

        private void InitializeDataGridView()
        {
            // 设置表格属性
            dataGridViewDepartments.MultiSelect = true;
            dataGridViewDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDepartments.AutoGenerateColumns = false;

            // 添加列
            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 60,
                ReadOnly = true
            });

            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "部门名称",
                DataPropertyName = "Name",
                Width = 150
            });

            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "部门描述",
                DataPropertyName = "Description",
                Width = 250
            });

            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedAt",
                HeaderText = "创建时间",
                DataPropertyName = "CreatedAt",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dataGridViewDepartments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UpdatedAt",
                HeaderText = "更新时间",
                DataPropertyName = "UpdatedAt",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });
        }

        private void LoadData()
        {
            InitializeData();
            dataGridViewDepartments.DataSource = null;
            dataGridViewDepartments.DataSource = _departments;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new DepartmentAddEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newDepartment = new Department
                    {
                        Name = addForm.DepartmentName,
                        Description = addForm.DepartmentDescription,
                    };
                    _departmentFunc.CreateDepartment(newDepartment);
                    LoadData();
                    MessageBox.Show("部门添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string errorMessage = GetUserFriendlyErrorMessage(ex.Message);
                    MessageBox.Show($"添加部门失败：{errorMessage}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的部门！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridViewDepartments.SelectedRows.Count > 1)
            {
                MessageBox.Show("只能选择一个部门进行编辑！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedDepartment = (Department)dataGridViewDepartments.SelectedRows[0].DataBoundItem;
            var editForm = new DepartmentAddEditForm(selectedDepartment);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("部门编辑成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的部门！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"确定要删除选中的 {dataGridViewDepartments.SelectedRows.Count} 个部门吗？", 
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    var selectedDepartments = dataGridViewDepartments.SelectedRows.Cast<DataGridViewRow>()
                        .Select(row => (Department)row.DataBoundItem).ToList();
                    
                    foreach (var dept in selectedDepartments)
                    {
                        _departmentFunc.DeleteDepartment(dept.Id);
                    }
                    
                    LoadData();
                    MessageBox.Show("部门删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string errorMessage = GetUserFriendlyErrorMessage(ex.Message);
                    MessageBox.Show($"删除部门失败：{errorMessage}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("数据刷新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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