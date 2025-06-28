using System.ComponentModel;
using System.Windows.Forms;

namespace DesktopApp.Control.Page
{
    partial class AfterSalesService
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
            this.tabControl1 = new TabControl();
            this.tabPageCustomerService = new TabPage();
            this.tabPageTechnicalSupport = new TabPage();
            this.tabPageWarranty = new TabPage();
            this.tabPageRefundReturn = new TabPage();
            this.dataGridViewCustomerService = new DataGridView();
            this.dataGridViewTechnicalSupport = new DataGridView();
            this.dataGridViewWarranty = new DataGridView();
            this.dataGridViewRefundReturn = new DataGridView();
            this.panelCustomerServiceButtons = new Panel();
            this.panelTechnicalSupportButtons = new Panel();
            this.panelWarrantyButtons = new Panel();
            this.panelRefundReturnButtons = new Panel();
            this.btnAddCustomerService = new Button();
            this.btnEditCustomerService = new Button();
            this.btnDeleteCustomerService = new Button();
            this.btnAddTechnicalSupport = new Button();
            this.btnEditTechnicalSupport = new Button();
            this.btnDeleteTechnicalSupport = new Button();
            this.btnAddWarranty = new Button();
            this.btnEditWarranty = new Button();
            this.btnDeleteWarranty = new Button();
            this.btnAddRefundReturn = new Button();
            this.btnEditRefundReturn = new Button();
            this.btnDeleteRefundReturn = new Button();
            this.tabControl1.SuspendLayout();
            this.tabPageCustomerService.SuspendLayout();
            this.tabPageTechnicalSupport.SuspendLayout();
            this.tabPageWarranty.SuspendLayout();
            this.tabPageRefundReturn.SuspendLayout();
            ((ISupportInitialize)(this.dataGridViewCustomerService)).BeginInit();
            ((ISupportInitialize)(this.dataGridViewTechnicalSupport)).BeginInit();
            ((ISupportInitialize)(this.dataGridViewWarranty)).BeginInit();
            ((ISupportInitialize)(this.dataGridViewRefundReturn)).BeginInit();
            this.panelCustomerServiceButtons.SuspendLayout();
            this.panelTechnicalSupportButtons.SuspendLayout();
            this.panelWarrantyButtons.SuspendLayout();
            this.panelRefundReturnButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCustomerService);
            this.tabControl1.Controls.Add(this.tabPageTechnicalSupport);
            this.tabControl1.Controls.Add(this.tabPageWarranty);
            this.tabControl1.Controls.Add(this.tabPageRefundReturn);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 600);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageCustomerService
            // 
            this.tabPageCustomerService.Controls.Add(this.dataGridViewCustomerService);
            this.tabPageCustomerService.Controls.Add(this.panelCustomerServiceButtons);
            this.tabPageCustomerService.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustomerService.Name = "tabPageCustomerService";
            this.tabPageCustomerService.Padding = new Padding(3);
            this.tabPageCustomerService.Size = new System.Drawing.Size(792, 574);
            this.tabPageCustomerService.TabIndex = 0;
            this.tabPageCustomerService.Text = "Customer Service Requests";
            this.tabPageCustomerService.UseVisualStyleBackColor = true;
            // 
            // tabPageTechnicalSupport
            // 
            this.tabPageTechnicalSupport.Controls.Add(this.dataGridViewTechnicalSupport);
            this.tabPageTechnicalSupport.Controls.Add(this.panelTechnicalSupportButtons);
            this.tabPageTechnicalSupport.Location = new System.Drawing.Point(4, 22);
            this.tabPageTechnicalSupport.Name = "tabPageTechnicalSupport";
            this.tabPageTechnicalSupport.Padding = new Padding(3);
            this.tabPageTechnicalSupport.Size = new System.Drawing.Size(792, 574);
            this.tabPageTechnicalSupport.TabIndex = 1;
            this.tabPageTechnicalSupport.Text = "Technical Support";
            this.tabPageTechnicalSupport.UseVisualStyleBackColor = true;
            // 
            // tabPageWarranty
            // 
            this.tabPageWarranty.Controls.Add(this.dataGridViewWarranty);
            this.tabPageWarranty.Controls.Add(this.panelWarrantyButtons);
            this.tabPageWarranty.Location = new System.Drawing.Point(4, 22);
            this.tabPageWarranty.Name = "tabPageWarranty";
            this.tabPageWarranty.Padding = new Padding(3);
            this.tabPageWarranty.Size = new System.Drawing.Size(792, 574);
            this.tabPageWarranty.TabIndex = 2;
            this.tabPageWarranty.Text = "Warranty Claims";
            this.tabPageWarranty.UseVisualStyleBackColor = true;
            // 
            // tabPageRefundReturn
            // 
            this.tabPageRefundReturn.Controls.Add(this.dataGridViewRefundReturn);
            this.tabPageRefundReturn.Controls.Add(this.panelRefundReturnButtons);
            this.tabPageRefundReturn.Location = new System.Drawing.Point(4, 22);
            this.tabPageRefundReturn.Name = "tabPageRefundReturn";
            this.tabPageRefundReturn.Padding = new Padding(3);
            this.tabPageRefundReturn.Size = new System.Drawing.Size(792, 574);
            this.tabPageRefundReturn.TabIndex = 3;
            this.tabPageRefundReturn.Text = "Refund Return Requests";
            this.tabPageRefundReturn.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCustomerService
            // 
            this.dataGridViewCustomerService.AllowUserToAddRows = false;
            this.dataGridViewCustomerService.AllowUserToDeleteRows = false;
            this.dataGridViewCustomerService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomerService.Dock = DockStyle.Fill;
            this.dataGridViewCustomerService.Location = new System.Drawing.Point(3, 43);
            this.dataGridViewCustomerService.Name = "dataGridViewCustomerService";
            this.dataGridViewCustomerService.ReadOnly = true;
            this.dataGridViewCustomerService.Size = new System.Drawing.Size(786, 528);
            this.dataGridViewCustomerService.TabIndex = 1;
            // 
            // dataGridViewTechnicalSupport
            // 
            this.dataGridViewTechnicalSupport.AllowUserToAddRows = false;
            this.dataGridViewTechnicalSupport.AllowUserToDeleteRows = false;
            this.dataGridViewTechnicalSupport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTechnicalSupport.Dock = DockStyle.Fill;
            this.dataGridViewTechnicalSupport.Location = new System.Drawing.Point(3, 43);
            this.dataGridViewTechnicalSupport.Name = "dataGridViewTechnicalSupport";
            this.dataGridViewTechnicalSupport.ReadOnly = true;
            this.dataGridViewTechnicalSupport.Size = new System.Drawing.Size(786, 528);
            this.dataGridViewTechnicalSupport.TabIndex = 1;
            // 
            // dataGridViewWarranty
            // 
            this.dataGridViewWarranty.AllowUserToAddRows = false;
            this.dataGridViewWarranty.AllowUserToDeleteRows = false;
            this.dataGridViewWarranty.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarranty.Dock = DockStyle.Fill;
            this.dataGridViewWarranty.Location = new System.Drawing.Point(3, 43);
            this.dataGridViewWarranty.Name = "dataGridViewWarranty";
            this.dataGridViewWarranty.ReadOnly = true;
            this.dataGridViewWarranty.Size = new System.Drawing.Size(786, 528);
            this.dataGridViewWarranty.TabIndex = 1;
            // 
            // dataGridViewRefundReturn
            // 
            this.dataGridViewRefundReturn.AllowUserToAddRows = false;
            this.dataGridViewRefundReturn.AllowUserToDeleteRows = false;
            this.dataGridViewRefundReturn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRefundReturn.Dock = DockStyle.Fill;
            this.dataGridViewRefundReturn.Location = new System.Drawing.Point(3, 43);
            this.dataGridViewRefundReturn.Name = "dataGridViewRefundReturn";
            this.dataGridViewRefundReturn.ReadOnly = true;
            this.dataGridViewRefundReturn.Size = new System.Drawing.Size(786, 528);
            this.dataGridViewRefundReturn.TabIndex = 1;
            // 
            // panelCustomerServiceButtons
            // 
            this.panelCustomerServiceButtons.Controls.Add(this.btnDeleteCustomerService);
            this.panelCustomerServiceButtons.Controls.Add(this.btnEditCustomerService);
            this.panelCustomerServiceButtons.Controls.Add(this.btnAddCustomerService);
            this.panelCustomerServiceButtons.Dock = DockStyle.Top;
            this.panelCustomerServiceButtons.Location = new System.Drawing.Point(3, 3);
            this.panelCustomerServiceButtons.Name = "panelCustomerServiceButtons";
            this.panelCustomerServiceButtons.Size = new System.Drawing.Size(786, 40);
            this.panelCustomerServiceButtons.TabIndex = 0;
            // 
            // panelTechnicalSupportButtons
            // 
            this.panelTechnicalSupportButtons.Controls.Add(this.btnDeleteTechnicalSupport);
            this.panelTechnicalSupportButtons.Controls.Add(this.btnEditTechnicalSupport);
            this.panelTechnicalSupportButtons.Controls.Add(this.btnAddTechnicalSupport);
            this.panelTechnicalSupportButtons.Dock = DockStyle.Top;
            this.panelTechnicalSupportButtons.Location = new System.Drawing.Point(3, 3);
            this.panelTechnicalSupportButtons.Name = "panelTechnicalSupportButtons";
            this.panelTechnicalSupportButtons.Size = new System.Drawing.Size(786, 40);
            this.panelTechnicalSupportButtons.TabIndex = 0;
            // 
            // panelWarrantyButtons
            // 
            this.panelWarrantyButtons.Controls.Add(this.btnDeleteWarranty);
            this.panelWarrantyButtons.Controls.Add(this.btnEditWarranty);
            this.panelWarrantyButtons.Controls.Add(this.btnAddWarranty);
            this.panelWarrantyButtons.Dock = DockStyle.Top;
            this.panelWarrantyButtons.Location = new System.Drawing.Point(3, 3);
            this.panelWarrantyButtons.Name = "panelWarrantyButtons";
            this.panelWarrantyButtons.Size = new System.Drawing.Size(786, 40);
            this.panelWarrantyButtons.TabIndex = 0;
            // 
            // panelRefundReturnButtons
            // 
            this.panelRefundReturnButtons.Controls.Add(this.btnDeleteRefundReturn);
            this.panelRefundReturnButtons.Controls.Add(this.btnEditRefundReturn);
            this.panelRefundReturnButtons.Controls.Add(this.btnAddRefundReturn);
            this.panelRefundReturnButtons.Dock = DockStyle.Top;
            this.panelRefundReturnButtons.Location = new System.Drawing.Point(3, 3);
            this.panelRefundReturnButtons.Name = "panelRefundReturnButtons";
            this.panelRefundReturnButtons.Size = new System.Drawing.Size(786, 40);
            this.panelRefundReturnButtons.TabIndex = 0;
            // 
            // btnAddCustomerService
            // 
            this.btnAddCustomerService.Location = new System.Drawing.Point(10, 10);
            this.btnAddCustomerService.Name = "btnAddCustomerService";
            this.btnAddCustomerService.Size = new System.Drawing.Size(75, 23);
            this.btnAddCustomerService.TabIndex = 0;
            this.btnAddCustomerService.Text = "Add";
            this.btnAddCustomerService.UseVisualStyleBackColor = true;
            // 
            // btnEditCustomerService
            // 
            this.btnEditCustomerService.Location = new System.Drawing.Point(95, 10);
            this.btnEditCustomerService.Name = "btnEditCustomerService";
            this.btnEditCustomerService.Size = new System.Drawing.Size(75, 23);
            this.btnEditCustomerService.TabIndex = 1;
            this.btnEditCustomerService.Text = "Edit";
            this.btnEditCustomerService.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCustomerService
            // 
            this.btnDeleteCustomerService.Location = new System.Drawing.Point(180, 10);
            this.btnDeleteCustomerService.Name = "btnDeleteCustomerService";
            this.btnDeleteCustomerService.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCustomerService.TabIndex = 2;
            this.btnDeleteCustomerService.Text = "Delete";
            this.btnDeleteCustomerService.UseVisualStyleBackColor = true;
            // 
            // btnAddTechnicalSupport
            // 
            this.btnAddTechnicalSupport.Location = new System.Drawing.Point(10, 10);
            this.btnAddTechnicalSupport.Name = "btnAddTechnicalSupport";
            this.btnAddTechnicalSupport.Size = new System.Drawing.Size(75, 23);
            this.btnAddTechnicalSupport.TabIndex = 0;
            this.btnAddTechnicalSupport.Text = "Add";
            this.btnAddTechnicalSupport.UseVisualStyleBackColor = true;
            // 
            // btnEditTechnicalSupport
            // 
            this.btnEditTechnicalSupport.Location = new System.Drawing.Point(95, 10);
            this.btnEditTechnicalSupport.Name = "btnEditTechnicalSupport";
            this.btnEditTechnicalSupport.Size = new System.Drawing.Size(75, 23);
            this.btnEditTechnicalSupport.TabIndex = 1;
            this.btnEditTechnicalSupport.Text = "Edit";
            this.btnEditTechnicalSupport.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTechnicalSupport
            // 
            this.btnDeleteTechnicalSupport.Location = new System.Drawing.Point(180, 10);
            this.btnDeleteTechnicalSupport.Name = "btnDeleteTechnicalSupport";
            this.btnDeleteTechnicalSupport.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTechnicalSupport.TabIndex = 2;
            this.btnDeleteTechnicalSupport.Text = "Delete";
            this.btnDeleteTechnicalSupport.UseVisualStyleBackColor = true;
            // 
            // btnAddWarranty
            // 
            this.btnAddWarranty.Location = new System.Drawing.Point(10, 10);
            this.btnAddWarranty.Name = "btnAddWarranty";
            this.btnAddWarranty.Size = new System.Drawing.Size(75, 23);
            this.btnAddWarranty.TabIndex = 0;
            this.btnAddWarranty.Text = "Add";
            this.btnAddWarranty.UseVisualStyleBackColor = true;
            // 
            // btnEditWarranty
            // 
            this.btnEditWarranty.Location = new System.Drawing.Point(95, 10);
            this.btnEditWarranty.Name = "btnEditWarranty";
            this.btnEditWarranty.Size = new System.Drawing.Size(75, 23);
            this.btnEditWarranty.TabIndex = 1;
            this.btnEditWarranty.Text = "Edit";
            this.btnEditWarranty.UseVisualStyleBackColor = true;
            // 
            // btnDeleteWarranty
            // 
            this.btnDeleteWarranty.Location = new System.Drawing.Point(180, 10);
            this.btnDeleteWarranty.Name = "btnDeleteWarranty";
            this.btnDeleteWarranty.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteWarranty.TabIndex = 2;
            this.btnDeleteWarranty.Text = "Delete";
            this.btnDeleteWarranty.UseVisualStyleBackColor = true;
            // 
            // btnAddRefundReturn
            // 
            this.btnAddRefundReturn.Location = new System.Drawing.Point(10, 10);
            this.btnAddRefundReturn.Name = "btnAddRefundReturn";
            this.btnAddRefundReturn.Size = new System.Drawing.Size(75, 23);
            this.btnAddRefundReturn.TabIndex = 0;
            this.btnAddRefundReturn.Text = "Add";
            this.btnAddRefundReturn.UseVisualStyleBackColor = true;
            // 
            // btnEditRefundReturn
            // 
            this.btnEditRefundReturn.Location = new System.Drawing.Point(95, 10);
            this.btnEditRefundReturn.Name = "btnEditRefundReturn";
            this.btnEditRefundReturn.Size = new System.Drawing.Size(75, 23);
            this.btnEditRefundReturn.TabIndex = 1;
            this.btnEditRefundReturn.Text = "Edit";
            this.btnEditRefundReturn.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRefundReturn
            // 
            this.btnDeleteRefundReturn.Location = new System.Drawing.Point(180, 10);
            this.btnDeleteRefundReturn.Name = "btnDeleteRefundReturn";
            this.btnDeleteRefundReturn.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRefundReturn.TabIndex = 2;
            this.btnDeleteRefundReturn.Text = "Delete";
            this.btnDeleteRefundReturn.UseVisualStyleBackColor = true;
            // 
            // AfterSalesService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "AfterSalesService";
            this.Size = new System.Drawing.Size(800, 600);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCustomerService.ResumeLayout(false);
            this.tabPageTechnicalSupport.ResumeLayout(false);
            this.tabPageWarranty.ResumeLayout(false);
            this.tabPageRefundReturn.ResumeLayout(false);
            ((ISupportInitialize)(this.dataGridViewCustomerService)).EndInit();
            ((ISupportInitialize)(this.dataGridViewTechnicalSupport)).EndInit();
            ((ISupportInitialize)(this.dataGridViewWarranty)).EndInit();
            ((ISupportInitialize)(this.dataGridViewRefundReturn)).EndInit();
            this.panelCustomerServiceButtons.ResumeLayout(false);
            this.panelTechnicalSupportButtons.ResumeLayout(false);
            this.panelWarrantyButtons.ResumeLayout(false);
            this.panelRefundReturnButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageCustomerService;
        private TabPage tabPageTechnicalSupport;
        private TabPage tabPageWarranty;
        private TabPage tabPageRefundReturn;
        private DataGridView dataGridViewCustomerService;
        private DataGridView dataGridViewTechnicalSupport;
        private DataGridView dataGridViewWarranty;
        private DataGridView dataGridViewRefundReturn;
        private Panel panelCustomerServiceButtons;
        private Panel panelTechnicalSupportButtons;
        private Panel panelWarrantyButtons;
        private Panel panelRefundReturnButtons;
        private Button btnAddCustomerService;
        private Button btnEditCustomerService;
        private Button btnDeleteCustomerService;
        private Button btnAddTechnicalSupport;
        private Button btnEditTechnicalSupport;
        private Button btnDeleteTechnicalSupport;
        private Button btnAddWarranty;
        private Button btnEditWarranty;
        private Button btnDeleteWarranty;
        private Button btnAddRefundReturn;
        private Button btnEditRefundReturn;
        private Button btnDeleteRefundReturn;
    }
}