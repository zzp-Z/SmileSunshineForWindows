using System.ComponentModel;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.SystemManage.UserManage
{
    partial class UserManagePageControl
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
            this.departmentComboBox = new ComboBox();
            this.addButton = new Button();
            this.editButton = new Button();
            this.deleteButton = new Button();
            this.resetPasswordButton = new Button();
            this.usersDataGridView = new DataGridView();
            this.departmentLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(12, 15);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(41, 12);
            this.departmentLabel.TabIndex = 0;
            this.departmentLabel.Text = "Department:";
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(59, 12);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(150, 20);
            this.departmentComboBox.TabIndex = 1;
            this.departmentComboBox.SelectedIndexChanged += new System.EventHandler(this.departmentComboBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(250, 10);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(331, 10);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(412, 10);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // resetPasswordButton
            // 
            this.resetPasswordButton.Location = new System.Drawing.Point(493, 10);
            this.resetPasswordButton.Name = "resetPasswordButton";
            this.resetPasswordButton.Size = new System.Drawing.Size(75, 23);
            this.resetPasswordButton.TabIndex = 5;
            this.resetPasswordButton.Text = "Reset password";
            this.resetPasswordButton.UseVisualStyleBackColor = true;
            this.resetPasswordButton.Click += new System.EventHandler(this.resetPasswordButton_Click);
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.AllowUserToAddRows = false;
            this.usersDataGridView.AllowUserToDeleteRows = false;
            this.usersDataGridView.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.usersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Location = new System.Drawing.Point(12, 45);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.ReadOnly = true;
            this.usersDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.usersDataGridView.Size = new System.Drawing.Size(776, 403);
            this.usersDataGridView.TabIndex = 5;
            // 
            // UserManagePageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.usersDataGridView);
            this.Controls.Add(this.resetPasswordButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.departmentComboBox);
            this.Controls.Add(this.departmentLabel);
            this.Name = "UserManagePageControl";
            this.Size = new System.Drawing.Size(800, 460);
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private ComboBox departmentComboBox;
        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private Button resetPasswordButton;
        private DataGridView usersDataGridView;
        private Label departmentLabel;
    }
}