using System.ComponentModel;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.SystemManage.RoleManage
{
    partial class RoleManagePageControl
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
            components = new Container();
            this.btnAdd = new System.Windows.Forms.Button();
             this.btnUpdate = new System.Windows.Forms.Button();
             this.btnDelete = new System.Windows.Forms.Button();
             this.cmbDepartment = new System.Windows.Forms.ComboBox();
             this.dgvRoles = new System.Windows.Forms.DataGridView();
             ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
             this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(101, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(182, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(300, 22);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(200, 21);
            this.cmbDepartment.TabIndex = 3;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
             // 
             // dgvRoles
             // 
             this.dgvRoles.AllowUserToAddRows = false;
             this.dgvRoles.AllowUserToDeleteRows = false;
             this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
             this.dgvRoles.Location = new System.Drawing.Point(20, 60);
             this.dgvRoles.Name = "dgvRoles";
             this.dgvRoles.ReadOnly = true;
             this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
             this.dgvRoles.Size = new System.Drawing.Size(760, 400);
             this.dgvRoles.TabIndex = 4;
             // 
             // RoleManagePageControl
             // 
             this.Controls.Add(this.dgvRoles);
             this.Controls.Add(this.cmbDepartment);
             this.Controls.Add(this.btnDelete);
             this.Controls.Add(this.btnUpdate);
             this.Controls.Add(this.btnAdd);
             this.AutoScaleMode = AutoScaleMode.Font;
             this.Size = new System.Drawing.Size(800, 480);
             ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
             this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
         private System.Windows.Forms.Button btnUpdate;
         private System.Windows.Forms.Button btnDelete;
         private System.Windows.Forms.ComboBox cmbDepartment;
         private System.Windows.Forms.DataGridView dgvRoles;
    }
}