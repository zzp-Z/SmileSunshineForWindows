using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp
{
    partial class UserManagementForm
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
            
            // 上半部分 - 表单控件
            this.panelTop = new Panel();
            this.lblDepartment = new Label();
            this.cmbDepartment = new ComboBox();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblGender = new Label();
            this.cmbGender = new ComboBox();
            this.lblRole = new Label();
            this.cmbRole = new ComboBox();
            this.lblRemark = new Label();
            this.txtRemark = new TextBox();
            this.btnReset = new Button();
            this.btnSubmit = new Button();
            
            // 下半部分 - 数据表格
            this.panelBottom = new Panel();
            this.dgvEmployees = new DataGridView();
            this.colUserId = new DataGridViewTextBoxColumn();
            this.colName = new DataGridViewTextBoxColumn();
            this.colGender = new DataGridViewTextBoxColumn();
            this.colRole = new DataGridViewTextBoxColumn();
            this.colRemark = new DataGridViewTextBoxColumn();
            this.bindingNavigator = new BindingNavigator(this.components);
            this.bindingSource = new BindingSource(this.components);
            
            // 设置面板
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            ((ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            
            // panelTop
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(800, 200);
            this.panelTop.TabIndex = 0;
            this.panelTop.Padding = new Padding(10);
            
            // lblDepartment
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new Point(20, 20);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new Size(80, 17);
            this.lblDepartment.TabIndex = 0;
            this.lblDepartment.Text = "选择部门：";
            
            // cmbDepartment
            this.cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new Point(110, 17);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new Size(200, 25);
            this.cmbDepartment.TabIndex = 1;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            
            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(20, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(80, 17);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "姓名：";
            
            // txtName
            this.txtName.Location = new Point(110, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(200, 25);
            this.txtName.TabIndex = 3;
            
            // lblGender
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new Point(350, 60);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new Size(80, 17);
            this.lblGender.TabIndex = 4;
            this.lblGender.Text = "性别：";
            
            // cmbGender
            this.cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] { "M", "F" });
            this.cmbGender.Location = new Point(440, 57);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new Size(100, 25);
            this.cmbGender.TabIndex = 5;
            
            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new Point(20, 100);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new Size(80, 17);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "角色：";
            
            // cmbRole
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new Point(110, 97);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new Size(200, 25);
            this.cmbRole.TabIndex = 7;
            
            // lblRemark
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new Point(350, 100);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new Size(80, 17);
            this.lblRemark.TabIndex = 8;
            this.lblRemark.Text = "备注：";
            
            // txtRemark
            this.txtRemark.Location = new Point(440, 97);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new Size(200, 25);
            this.txtRemark.TabIndex = 9;
            
            // btnReset
            this.btnReset.Location = new Point(230, 150);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new Size(100, 30);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            
            // btnSubmit
            this.btnSubmit.Location = new Point(440, 150);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new Size(100, 30);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            
            // panelBottom
            this.panelBottom.Dock = DockStyle.Fill;
            this.panelBottom.Location = new Point(0, 200);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new Size(800, 250);
            this.panelBottom.TabIndex = 1;
            this.panelBottom.Padding = new Padding(10);
            
            // dgvEmployees
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AutoGenerateColumns = false;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new DataGridViewColumn[] {
                this.colUserId,
                this.colName,
                this.colGender,
                this.colRole,
                this.colRemark
            });
            this.dgvEmployees.DataSource = this.bindingSource;
            this.dgvEmployees.Dock = DockStyle.Fill;
            this.dgvEmployees.Location = new Point(10, 10);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.RowTemplate.Height = 24;
            this.dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new Size(780, 205);
            this.dgvEmployees.TabIndex = 0;
            
            // colUserId
            this.colUserId.DataPropertyName = "Id";
            this.colUserId.HeaderText = "用户ID";
            this.colUserId.MinimumWidth = 6;
            this.colUserId.Name = "colUserId";
            this.colUserId.ReadOnly = true;
            this.colUserId.Width = 80;
            
            // colName
            this.colName.DataPropertyName = "Username";
            this.colName.HeaderText = "姓名";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 120;
            
            // colGender
            this.colGender.DataPropertyName = "Gender";
            this.colGender.HeaderText = "性别";
            this.colGender.MinimumWidth = 6;
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            this.colGender.Width = 80;
            
            // colRole
            this.colRole.DataPropertyName = "Role";
            this.colRole.HeaderText = "角色";
            this.colRole.MinimumWidth = 6;
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            this.colRole.Width = 120;
            
            // colRemark
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "备注";
            this.colRemark.MinimumWidth = 6;
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 200;
            
            // bindingNavigator
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.BindingSource = this.bindingSource;
            this.bindingNavigator.CountItem = new ToolStripLabel("共 {0} 项");
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.Dock = DockStyle.Bottom;
            this.bindingNavigator.ImageScalingSize = new Size(20, 20);
            this.bindingNavigator.Items.AddRange(new ToolStripItem[] {
                new ToolStripButton("首页", null, null) { DisplayStyle = ToolStripItemDisplayStyle.Text },
                new ToolStripButton("上一页", null, null) { DisplayStyle = ToolStripItemDisplayStyle.Text },
                new ToolStripSeparator(),
                new ToolStripLabel("第"),
                new ToolStripTextBox() { AutoSize = false, Width = 50 },
                new ToolStripLabel("页，共"),
                this.bindingNavigator.CountItem,
                new ToolStripSeparator(),
                new ToolStripButton("下一页", null, null) { DisplayStyle = ToolStripItemDisplayStyle.Text },
                new ToolStripButton("末页", null, null) { DisplayStyle = ToolStripItemDisplayStyle.Text }
            });
            this.bindingNavigator.Location = new Point(10, 215);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigator.Items[0];
            this.bindingNavigator.MoveLastItem = this.bindingNavigator.Items[9];
            this.bindingNavigator.MoveNextItem = this.bindingNavigator.Items[8];
            this.bindingNavigator.MovePreviousItem = this.bindingNavigator.Items[1];
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = (ToolStripTextBox)this.bindingNavigator.Items[4];
            this.bindingNavigator.Size = new Size(780, 25);
            this.bindingNavigator.TabIndex = 1;
            this.bindingNavigator.Text = "bindingNavigator1";
            
            // UserManagementForm
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "UserManagementForm";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserManagementForm_Load);
            
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            ((ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            
            // 添加控件到面板
            this.panelTop.Controls.Add(this.lblDepartment);
            this.panelTop.Controls.Add(this.cmbDepartment);
            this.panelTop.Controls.Add(this.lblName);
            this.panelTop.Controls.Add(this.txtName);
            this.panelTop.Controls.Add(this.lblGender);
            this.panelTop.Controls.Add(this.cmbGender);
            this.panelTop.Controls.Add(this.lblRole);
            this.panelTop.Controls.Add(this.cmbRole);
            this.panelTop.Controls.Add(this.lblRemark);
            this.panelTop.Controls.Add(this.txtRemark);
            this.panelTop.Controls.Add(this.btnReset);
            this.panelTop.Controls.Add(this.btnSubmit);
            
            this.panelBottom.Controls.Add(this.dgvEmployees);
            this.panelBottom.Controls.Add(this.bindingNavigator);
        }

        #endregion
        
        private Panel panelTop;
        private Label lblDepartment;
        private ComboBox cmbDepartment;
        private Label lblName;
        private TextBox txtName;
        private Label lblGender;
        private ComboBox cmbGender;
        private Label lblRole;
        private ComboBox cmbRole;
        private Label lblRemark;
        private TextBox txtRemark;
        private Button btnReset;
        private Button btnSubmit;
        
        private Panel panelBottom;
        private DataGridView dgvEmployees;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colGender;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colRemark;
        private BindingNavigator bindingNavigator;
        private BindingSource bindingSource;
    }
}