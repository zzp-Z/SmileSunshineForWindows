using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp
{
    partial class DepartmentManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Text = "部门管理";
            
            // 添加部门区域
            this.panelAddDepartment = new Panel();
            this.panelAddDepartment.Location = new Point(12, 12);
            this.panelAddDepartment.Size = new Size(776, 200);
            this.panelAddDepartment.BorderStyle = BorderStyle.FixedSingle;
            
            // 添加部门标题
            this.lblAddDepartmentTitle = new Label();
            this.lblAddDepartmentTitle.Location = new Point(10, 10);
            this.lblAddDepartmentTitle.Size = new Size(200, 25);
            this.lblAddDepartmentTitle.Text = "添加部门";
            this.lblAddDepartmentTitle.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold);
            
            // 部门名称标签
            this.lblDepartmentName = new Label();
            this.lblDepartmentName.Location = new Point(10, 50);
            this.lblDepartmentName.Size = new Size(80, 25);
            this.lblDepartmentName.Text = "部门名称:";
            
            // 部门名称输入框
            this.txtDepartmentName = new TextBox();
            this.txtDepartmentName.Location = new Point(100, 50);
            this.txtDepartmentName.Size = new Size(200, 25);
            
            // 部门描述标签
            this.lblDepartmentDescription = new Label();
            this.lblDepartmentDescription.Location = new Point(10, 90);
            this.lblDepartmentDescription.Size = new Size(80, 25);
            this.lblDepartmentDescription.Text = "部门描述:";
            
            // 部门描述输入框
            this.txtDepartmentDescription = new TextBox();
            this.txtDepartmentDescription.Location = new Point(100, 90);
            this.txtDepartmentDescription.Size = new Size(400, 25);
            this.txtDepartmentDescription.Multiline = true;
            this.txtDepartmentDescription.Height = 60;
            
            // 添加按钮
            this.btnAddDepartment = new Button();
            this.btnAddDepartment.Location = new Point(100, 160);
            this.btnAddDepartment.Size = new Size(100, 30);
            this.btnAddDepartment.Text = "添加";
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
            
            // 部门列表区域
            this.panelDepartmentList = new Panel();
            this.panelDepartmentList.Location = new Point(12, 224);
            this.panelDepartmentList.Size = new Size(776, 350);
            this.panelDepartmentList.BorderStyle = BorderStyle.FixedSingle;
            
            // 部门列表标题
            this.lblDepartmentListTitle = new Label();
            this.lblDepartmentListTitle.Location = new Point(10, 10);
            this.lblDepartmentListTitle.Size = new Size(200, 25);
            this.lblDepartmentListTitle.Text = "部门列表";
            this.lblDepartmentListTitle.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold);
            
            // 部门数据表格
            this.dgvDepartments = new DataGridView();
            this.dgvDepartments.Location = new Point(10, 45);
            this.dgvDepartments.Size = new Size(756, 295);
            this.dgvDepartments.AllowUserToAddRows = false;
            this.dgvDepartments.AllowUserToDeleteRows = false;
            this.dgvDepartments.ReadOnly = true;
            this.dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartments.RowHeadersVisible = false;
            this.dgvDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            // 添加控件到面板
            this.panelAddDepartment.Controls.Add(this.lblAddDepartmentTitle);
            this.panelAddDepartment.Controls.Add(this.lblDepartmentName);
            this.panelAddDepartment.Controls.Add(this.txtDepartmentName);
            this.panelAddDepartment.Controls.Add(this.lblDepartmentDescription);
            this.panelAddDepartment.Controls.Add(this.txtDepartmentDescription);
            this.panelAddDepartment.Controls.Add(this.btnAddDepartment);
            
            this.panelDepartmentList.Controls.Add(this.lblDepartmentListTitle);
            this.panelDepartmentList.Controls.Add(this.dgvDepartments);
            
            // 添加面板到窗体
            this.Controls.Add(this.panelAddDepartment);
            this.Controls.Add(this.panelDepartmentList);
            
            this.ResumeLayout(false);
        }

        #endregion
        
        private Panel panelAddDepartment;
        private Label lblAddDepartmentTitle;
        private Label lblDepartmentName;
        private TextBox txtDepartmentName;
        private Label lblDepartmentDescription;
        private TextBox txtDepartmentDescription;
        private Button btnAddDepartment;
        
        private Panel panelDepartmentList;
        private Label lblDepartmentListTitle;
        private DataGridView dgvDepartments;
    }
}