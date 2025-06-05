using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.SystemManage.DepartmentManage
{
    partial class DepartmentManagePageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new Panel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.dataGridViewDepartments = new DataGridView();
            this.panelTop.SuspendLayout();
            ((ISupportInitialize)(this.dataGridViewDepartments)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnEdit);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(800, 50);
            this.panelTop.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new Point(10, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(75, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new Point(95, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(75, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new Point(180, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(75, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new Point(265, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(75, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            // 
            // dataGridViewDepartments
            // 
            this.dataGridViewDepartments.AllowUserToAddRows = false;
            this.dataGridViewDepartments.AllowUserToDeleteRows = false;
            this.dataGridViewDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepartments.Dock = DockStyle.Fill;
            this.dataGridViewDepartments.Location = new Point(0, 50);
            this.dataGridViewDepartments.Name = "dataGridViewDepartments";
            this.dataGridViewDepartments.ReadOnly = true;
            this.dataGridViewDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDepartments.Size = new Size(800, 550);
            this.dataGridViewDepartments.TabIndex = 1;
            // 
            // DepartmentManagePageControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewDepartments);
            this.Controls.Add(this.panelTop);
            this.Name = "DepartmentManagePageControl";
            this.Size = new Size(800, 600);
            this.panelTop.ResumeLayout(false);
            ((ISupportInitialize)(this.dataGridViewDepartments)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private DataGridView dataGridViewDepartments;
    }
}