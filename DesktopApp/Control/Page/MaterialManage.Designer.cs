using System.ComponentModel;
using System.Windows.Forms;

namespace SmileSunshine.DesktopApp.Control.Page
{
    partial class MaterialManage
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
            this.tabPageMaterials = new TabPage();
            this.tabPageSuppliers = new TabPage();
            this.tabPageProcurement = new TabPage();
            this.tabPageInventory = new TabPage();
            this.dataGridViewMaterials = new DataGridView();
            this.dataGridViewSuppliers = new DataGridView();
            this.dataGridViewProcurement = new DataGridView();
            this.dataGridViewInventory = new DataGridView();
            this.panelMaterialButtons = new Panel();
            this.panelSupplierButtons = new Panel();
            this.panelProcurementButtons = new Panel();
            this.panelInventoryButtons = new Panel();
            this.btnAddMaterial = new Button();
            this.btnEditMaterial = new Button();
            this.btnDeleteMaterial = new Button();
            this.btnAddSupplier = new Button();
            this.btnEditSupplier = new Button();
            this.btnDeleteSupplier = new Button();
            this.btnAddProcurement = new Button();
            this.btnEditProcurement = new Button();
            this.btnDeleteProcurement = new Button();
            this.btnAddInventory = new Button();
            this.btnEditInventory = new Button();
            this.btnDeleteInventory = new Button();
            this.tabControl1.SuspendLayout();
            this.tabPageMaterials.SuspendLayout();
            this.tabPageSuppliers.SuspendLayout();
            this.tabPageProcurement.SuspendLayout();
            this.tabPageInventory.SuspendLayout();
            ((ISupportInitialize)(this.dataGridViewMaterials)).BeginInit();
            ((ISupportInitialize)(this.dataGridViewSuppliers)).BeginInit();
            ((ISupportInitialize)(this.dataGridViewProcurement)).BeginInit();
            ((ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.panelMaterialButtons.SuspendLayout();
            this.panelSupplierButtons.SuspendLayout();
            this.panelProcurementButtons.SuspendLayout();
            this.panelInventoryButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMaterials);
            this.tabControl1.Controls.Add(this.tabPageSuppliers);
            this.tabControl1.Controls.Add(this.tabPageProcurement);
            this.tabControl1.Controls.Add(this.tabPageInventory);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 600);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageMaterials
            // 
            this.tabPageMaterials.Controls.Add(this.dataGridViewMaterials);
            this.tabPageMaterials.Controls.Add(this.panelMaterialButtons);
            this.tabPageMaterials.Location = new System.Drawing.Point(4, 22);
            this.tabPageMaterials.Name = "tabPageMaterials";
            this.tabPageMaterials.Padding = new Padding(3);
            this.tabPageMaterials.Size = new System.Drawing.Size(792, 574);
            this.tabPageMaterials.TabIndex = 0;
            this.tabPageMaterials.Text = "Material Management";
            this.tabPageMaterials.UseVisualStyleBackColor = true;
            // 
            // tabPageSuppliers
            // 
            this.tabPageSuppliers.Controls.Add(this.dataGridViewSuppliers);
            this.tabPageSuppliers.Controls.Add(this.panelSupplierButtons);
            this.tabPageSuppliers.Location = new System.Drawing.Point(4, 22);
            this.tabPageSuppliers.Name = "tabPageSuppliers";
            this.tabPageSuppliers.Padding = new Padding(3);
            this.tabPageSuppliers.Size = new System.Drawing.Size(792, 574);
            this.tabPageSuppliers.TabIndex = 1;
            this.tabPageSuppliers.Text = "Supplier Management";
            this.tabPageSuppliers.UseVisualStyleBackColor = true;
            // 
            // tabPageProcurement
            // 
            this.tabPageProcurement.Controls.Add(this.dataGridViewProcurement);
            this.tabPageProcurement.Controls.Add(this.panelProcurementButtons);
            this.tabPageProcurement.Location = new System.Drawing.Point(4, 22);
            this.tabPageProcurement.Name = "tabPageProcurement";
            this.tabPageProcurement.Padding = new Padding(3);
            this.tabPageProcurement.Size = new System.Drawing.Size(792, 574);
            this.tabPageProcurement.TabIndex = 2;
            this.tabPageProcurement.Text = "Procurement Orders";
            this.tabPageProcurement.UseVisualStyleBackColor = true;
            // 
            // tabPageInventory
            // 
            this.tabPageInventory.Controls.Add(this.dataGridViewInventory);
            this.tabPageInventory.Controls.Add(this.panelInventoryButtons);
            this.tabPageInventory.Location = new System.Drawing.Point(4, 22);
            this.tabPageInventory.Name = "tabPageInventory";
            this.tabPageInventory.Padding = new Padding(3);
            this.tabPageInventory.Size = new System.Drawing.Size(792, 574);
            this.tabPageInventory.TabIndex = 3;
            this.tabPageInventory.Text = "Inventory Records";
            this.tabPageInventory.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMaterials
            // 
            this.dataGridViewMaterials.AllowUserToAddRows = false;
            this.dataGridViewMaterials.AllowUserToDeleteRows = false;
            this.dataGridViewMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaterials.Dock = DockStyle.Fill;
            this.dataGridViewMaterials.Location = new System.Drawing.Point(3, 43);
            this.dataGridViewMaterials.Name = "dataGridViewMaterials";
            this.dataGridViewMaterials.ReadOnly = true;
            this.dataGridViewMaterials.Size = new System.Drawing.Size(786, 528);
            this.dataGridViewMaterials.TabIndex = 1;
            // 
            // dataGridViewSuppliers
            // 
            this.dataGridViewSuppliers.AllowUserToAddRows = false;
            this.dataGridViewSuppliers.AllowUserToDeleteRows = false;
            this.dataGridViewSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSuppliers.Dock = DockStyle.Fill;
            this.dataGridViewSuppliers.Location = new System.Drawing.Point(3, 43);
            this.dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            this.dataGridViewSuppliers.ReadOnly = true;
            this.dataGridViewSuppliers.Size = new System.Drawing.Size(786, 528);
            this.dataGridViewSuppliers.TabIndex = 1;
            // 
            // dataGridViewProcurement
            // 
            this.dataGridViewProcurement.AllowUserToAddRows = false;
            this.dataGridViewProcurement.AllowUserToDeleteRows = false;
            this.dataGridViewProcurement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcurement.Dock = DockStyle.Fill;
            this.dataGridViewProcurement.Location = new System.Drawing.Point(3, 43);
            this.dataGridViewProcurement.Name = "dataGridViewProcurement";
            this.dataGridViewProcurement.ReadOnly = true;
            this.dataGridViewProcurement.Size = new System.Drawing.Size(786, 528);
            this.dataGridViewProcurement.TabIndex = 1;
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.AllowUserToAddRows = false;
            this.dataGridViewInventory.AllowUserToDeleteRows = false;
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Dock = DockStyle.Fill;
            this.dataGridViewInventory.Location = new System.Drawing.Point(3, 43);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.ReadOnly = true;
            this.dataGridViewInventory.Size = new System.Drawing.Size(786, 528);
            this.dataGridViewInventory.TabIndex = 1;
            // 
            // panelMaterialButtons
            // 
            this.panelMaterialButtons.Controls.Add(this.btnDeleteMaterial);
            this.panelMaterialButtons.Controls.Add(this.btnEditMaterial);
            this.panelMaterialButtons.Controls.Add(this.btnAddMaterial);
            this.panelMaterialButtons.Dock = DockStyle.Top;
            this.panelMaterialButtons.Location = new System.Drawing.Point(3, 3);
            this.panelMaterialButtons.Name = "panelMaterialButtons";
            this.panelMaterialButtons.Size = new System.Drawing.Size(786, 40);
            this.panelMaterialButtons.TabIndex = 0;
            // 
            // panelSupplierButtons
            // 
            this.panelSupplierButtons.Controls.Add(this.btnDeleteSupplier);
            this.panelSupplierButtons.Controls.Add(this.btnEditSupplier);
            this.panelSupplierButtons.Controls.Add(this.btnAddSupplier);
            this.panelSupplierButtons.Dock = DockStyle.Top;
            this.panelSupplierButtons.Location = new System.Drawing.Point(3, 3);
            this.panelSupplierButtons.Name = "panelSupplierButtons";
            this.panelSupplierButtons.Size = new System.Drawing.Size(786, 40);
            this.panelSupplierButtons.TabIndex = 0;
            // 
            // panelProcurementButtons
            // 
            this.panelProcurementButtons.Controls.Add(this.btnDeleteProcurement);
            this.panelProcurementButtons.Controls.Add(this.btnEditProcurement);
            this.panelProcurementButtons.Controls.Add(this.btnAddProcurement);
            this.panelProcurementButtons.Dock = DockStyle.Top;
            this.panelProcurementButtons.Location = new System.Drawing.Point(3, 3);
            this.panelProcurementButtons.Name = "panelProcurementButtons";
            this.panelProcurementButtons.Size = new System.Drawing.Size(786, 40);
            this.panelProcurementButtons.TabIndex = 0;
            // 
            // panelInventoryButtons
            // 
            this.panelInventoryButtons.Controls.Add(this.btnDeleteInventory);
            this.panelInventoryButtons.Controls.Add(this.btnEditInventory);
            this.panelInventoryButtons.Controls.Add(this.btnAddInventory);
            this.panelInventoryButtons.Dock = DockStyle.Top;
            this.panelInventoryButtons.Location = new System.Drawing.Point(3, 3);
            this.panelInventoryButtons.Name = "panelInventoryButtons";
            this.panelInventoryButtons.Size = new System.Drawing.Size(786, 40);
            this.panelInventoryButtons.TabIndex = 0;
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(10, 10);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnAddMaterial.TabIndex = 0;
            this.btnAddMaterial.Text = "Add";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            // 
            // btnEditMaterial
            // 
            this.btnEditMaterial.Location = new System.Drawing.Point(95, 10);
            this.btnEditMaterial.Name = "btnEditMaterial";
            this.btnEditMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnEditMaterial.TabIndex = 1;
            this.btnEditMaterial.Text = "Edit";
            this.btnEditMaterial.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.Location = new System.Drawing.Point(180, 10);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMaterial.TabIndex = 2;
            this.btnDeleteMaterial.Text = "Delete";
            this.btnDeleteMaterial.UseVisualStyleBackColor = true;
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(10, 10);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnAddSupplier.TabIndex = 0;
            this.btnAddSupplier.Text = "Add";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            // 
            // btnEditSupplier
            // 
            this.btnEditSupplier.Location = new System.Drawing.Point(95, 10);
            this.btnEditSupplier.Name = "btnEditSupplier";
            this.btnEditSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnEditSupplier.TabIndex = 1;
            this.btnEditSupplier.Text = "Edit";
            this.btnEditSupplier.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.Location = new System.Drawing.Point(180, 10);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSupplier.TabIndex = 2;
            this.btnDeleteSupplier.Text = "Delete";
            this.btnDeleteSupplier.UseVisualStyleBackColor = true;
            // 
            // btnAddProcurement
            // 
            this.btnAddProcurement.Location = new System.Drawing.Point(10, 10);
            this.btnAddProcurement.Name = "btnAddProcurement";
            this.btnAddProcurement.Size = new System.Drawing.Size(75, 23);
            this.btnAddProcurement.TabIndex = 0;
            this.btnAddProcurement.Text = "Add";
            this.btnAddProcurement.UseVisualStyleBackColor = true;
            // 
            // btnEditProcurement
            // 
            this.btnEditProcurement.Location = new System.Drawing.Point(95, 10);
            this.btnEditProcurement.Name = "btnEditProcurement";
            this.btnEditProcurement.Size = new System.Drawing.Size(75, 23);
            this.btnEditProcurement.TabIndex = 1;
            this.btnEditProcurement.Text = "Edit";
            this.btnEditProcurement.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProcurement
            // 
            this.btnDeleteProcurement.Location = new System.Drawing.Point(180, 10);
            this.btnDeleteProcurement.Name = "btnDeleteProcurement";
            this.btnDeleteProcurement.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteProcurement.TabIndex = 2;
            this.btnDeleteProcurement.Text = "Delete";
            this.btnDeleteProcurement.UseVisualStyleBackColor = true;
            // 
            // btnAddInventory
            // 
            this.btnAddInventory.Location = new System.Drawing.Point(10, 10);
            this.btnAddInventory.Name = "btnAddInventory";
            this.btnAddInventory.Size = new System.Drawing.Size(75, 23);
            this.btnAddInventory.TabIndex = 0;
            this.btnAddInventory.Text = "Add";
            this.btnAddInventory.UseVisualStyleBackColor = true;
            // 
            // btnEditInventory
            // 
            this.btnEditInventory.Location = new System.Drawing.Point(95, 10);
            this.btnEditInventory.Name = "btnEditInventory";
            this.btnEditInventory.Size = new System.Drawing.Size(75, 23);
            this.btnEditInventory.TabIndex = 1;
            this.btnEditInventory.Text = "Edit";
            this.btnEditInventory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteInventory
            // 
            this.btnDeleteInventory.Location = new System.Drawing.Point(180, 10);
            this.btnDeleteInventory.Name = "btnDeleteInventory";
            this.btnDeleteInventory.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteInventory.TabIndex = 2;
            this.btnDeleteInventory.Text = "Delete";
            this.btnDeleteInventory.UseVisualStyleBackColor = true;
            // 
            // MaterialManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Material";
            this.Size = new System.Drawing.Size(800, 600);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMaterials.ResumeLayout(false);
            this.tabPageSuppliers.ResumeLayout(false);
            this.tabPageProcurement.ResumeLayout(false);
            this.tabPageInventory.ResumeLayout(false);
            ((ISupportInitialize)(this.dataGridViewMaterials)).EndInit();
            ((ISupportInitialize)(this.dataGridViewSuppliers)).EndInit();
            ((ISupportInitialize)(this.dataGridViewProcurement)).EndInit();
            ((ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.panelMaterialButtons.ResumeLayout(false);
            this.panelSupplierButtons.ResumeLayout(false);
            this.panelProcurementButtons.ResumeLayout(false);
            this.panelInventoryButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageMaterials;
        private TabPage tabPageSuppliers;
        private TabPage tabPageProcurement;
        private TabPage tabPageInventory;
        private DataGridView dataGridViewMaterials;
        private DataGridView dataGridViewSuppliers;
        private DataGridView dataGridViewProcurement;
        private DataGridView dataGridViewInventory;
        private Panel panelMaterialButtons;
        private Panel panelSupplierButtons;
        private Panel panelProcurementButtons;
        private Panel panelInventoryButtons;
        private Button btnAddMaterial;
        private Button btnEditMaterial;
        private Button btnDeleteMaterial;
        private Button btnAddSupplier;
        private Button btnEditSupplier;
        private Button btnDeleteSupplier;
        private Button btnAddProcurement;
        private Button btnEditProcurement;
        private Button btnDeleteProcurement;
        private Button btnAddInventory;
        private Button btnEditInventory;
        private Button btnDeleteInventory;
    }
}