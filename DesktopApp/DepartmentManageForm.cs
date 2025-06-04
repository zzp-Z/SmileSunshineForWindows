using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DesktopApp.Database;

namespace DesktopApp
{
    public partial class DepartmentManageForm : Form
    {
        private readonly Database.Func.DepartmentFunc _departmentFunc;
        

        // 模拟部门数据列表
        private List<Department> _departments;
        

        public DepartmentManageForm(Database.Func.DepartmentFunc departmentFunc)
        {
            _departmentFunc = departmentFunc;
            InitializeComponent();
            InitializeDepartmentData();
            InitializeDepartmentGrid();
        }
        

        /// <summary>
        /// 初始化模拟部门数据
        /// </summary>
        private void InitializeDepartmentData()
        {
            _departments = _departmentFunc.GetAllDepartments();
        }
        
        /// <summary>
        /// 初始化部门数据表格
        /// </summary>
        private void InitializeDepartmentGrid()
        {
            // 清空表格
            dgvDepartments.Columns.Clear();
            
            // 添加列
            dgvDepartments.Columns.Add("Id", "ID");
            dgvDepartments.Columns.Add("Name", "部门名称");
            dgvDepartments.Columns.Add("Description", "部门描述");
            dgvDepartments.Columns.Add("CreatedAt", "创建时间");
            
            // 添加编辑按钮列
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "编辑";
            editButtonColumn.Text = "编辑";
            editButtonColumn.UseColumnTextForButtonValue = true;
            dgvDepartments.Columns.Add(editButtonColumn);
            
            // 添加删除按钮列
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "删除";
            deleteButtonColumn.Text = "删除";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvDepartments.Columns.Add(deleteButtonColumn);
            
            // 设置列宽度
            dgvDepartments.Columns["Id"].Width = 50;
            dgvDepartments.Columns["Name"].Width = 150;
            dgvDepartments.Columns["Description"].Width = 300;
            dgvDepartments.Columns["CreatedAt"].Width = 150;
            
            // 绑定数据
            RefreshDepartmentGrid();
            
            // 添加单元格点击事件
            dgvDepartments.CellClick += DgvDepartments_CellClick;
        }
        
        /// <summary>
        /// 刷新部门数据表格
        /// </summary>
        private void RefreshDepartmentGrid()
        {
            dgvDepartments.Rows.Clear();
            
            foreach (var department in _departments)
            {
                dgvDepartments.Rows.Add(
                    department.Id,
                    department.Name,
                    department.Description,
                    department.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
                );
            }
        }
        
        /// <summary>
        /// 表格单元格点击事件
        /// </summary>
        private void DgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int departmentId = Convert.ToInt32(dgvDepartments.Rows[e.RowIndex].Cells["Id"].Value);
            string departmentName = dgvDepartments.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            string departmentDescription = dgvDepartments.Rows[e.RowIndex].Cells["Description"].Value.ToString();


            // 编辑按钮
            if (e.ColumnIndex == dgvDepartments.Columns.Count - 2)
            {
                // 创建编辑表单
                using (Form editForm = new Form())
                {
                    editForm.Text = "编辑部门";
                    editForm.Size = new System.Drawing.Size(400, 300);
                    editForm.StartPosition = FormStartPosition.CenterParent;

                    Label nameLabel = new Label() { Text = "部门名称:", Left = 20, Top = 20 };
                    TextBox nameTextBox = new TextBox() { Text = departmentName, Left = 20, Top = 40, Width = 340 };

                    Label descLabel = new Label() { Text = "部门描述:", Left = 20, Top = 80 };
                    TextBox descTextBox = new TextBox() { Text = departmentDescription, Left = 20, Top = 100, Width = 340, Height = 100, Multiline = true };

                    Button saveButton = new Button() { Text = "保存", Left = 150, Top = 220 };
                    saveButton.Click += (s, args) =>
                    {
                        string newName = nameTextBox.Text.Trim();
                        string newDesc = descTextBox.Text.Trim();

                        if (string.IsNullOrEmpty(newName))
                        {
                            MessageBox.Show("请输入部门名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        Department updatedDepartment = new Department
                        {
                            Id = departmentId,
                            Name = newName,
                            Description = newDesc,
                            UpdatedAt = DateTime.Now
                        };

                        if (_departmentFunc.UpdateDepartment(updatedDepartment))
                        {
                            MessageBox.Show("部门更新成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            InitializeDepartmentData();
                            RefreshDepartmentGrid();
                            editForm.Close();
                        }
                        else
                        {
                            MessageBox.Show("部门更新失败，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    editForm.Controls.AddRange(new Control[] { nameLabel, nameTextBox, descLabel, descTextBox, saveButton });
                    editForm.ShowDialog();
                }
            }
            // 删除按钮
            else if (e.ColumnIndex == dgvDepartments.Columns.Count - 1)
            {
                if (MessageBox.Show($"确定要删除部门 \"{departmentName}\" 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_departmentFunc.DeleteDepartment(departmentId))
                    {
                        MessageBox.Show("部门删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitializeDepartmentData();
                        RefreshDepartmentGrid();
                    }
                    else
                    {
                        MessageBox.Show("部门删除失败，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        /// <summary>
        /// 添加部门按钮点击事件
        /// </summary>
        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            string name = txtDepartmentName.Text.Trim();
            string description = txtDepartmentDescription.Text.Trim();
            
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入部门名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            Department newDepartment = new Department
            {
                Name = name,
                Description = description,
            };
            
            // 调用数据库方法创建部门
            if (_departmentFunc.CreateDepartment(newDepartment))
            {
                // 重新加载数据
                InitializeDepartmentData();
                RefreshDepartmentGrid();
                
                // 清空输入框
                txtDepartmentName.Text = "";
                txtDepartmentDescription.Text = "";
                
                MessageBox.Show("部门添加成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("部门添加失败，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}