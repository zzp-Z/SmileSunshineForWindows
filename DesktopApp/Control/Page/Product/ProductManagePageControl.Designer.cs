using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.Product
{
    partial class ProductManagePageControl
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
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.btnMigrateImages = new Button();
            this.btnImageSettings = new Button();
            this.flowLayoutPanelProducts = new FlowLayoutPanel();
            this.panelTop = new Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnImageSettings);
            this.panelTop.Controls.Add(this.btnMigrateImages);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnEdit);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(800, 60);
            this.panelTop.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new Point(20, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(80, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new Point(120, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(80, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new Point(220, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(80, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new Point(320, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(80, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            // 
            // btnMigrateImages
            // 
            this.btnMigrateImages.Location = new Point(420, 15);
            this.btnMigrateImages.Name = "btnMigrateImages";
            this.btnMigrateImages.Size = new Size(100, 30);
            this.btnMigrateImages.TabIndex = 4;
            this.btnMigrateImages.Text = "Migrate Images";
            this.btnMigrateImages.UseVisualStyleBackColor = true;
            this.btnMigrateImages.Click += new EventHandler(this.btnMigrateImages_Click);
            // 
            // btnImageSettings
            // 
            this.btnImageSettings.Location = new Point(540, 15);
            this.btnImageSettings.Name = "btnImageSettings";
            this.btnImageSettings.Size = new Size(100, 30);
            this.btnImageSettings.TabIndex = 5;
            this.btnImageSettings.Text = "Image Settings";
            this.btnImageSettings.UseVisualStyleBackColor = true;
            this.btnImageSettings.Click += new EventHandler(this.btnImageSettings_Click);
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.AutoScroll = true;
            this.flowLayoutPanelProducts.BackColor = Color.FromArgb(250, 250, 250);
            this.flowLayoutPanelProducts.Dock = DockStyle.Fill;
            this.flowLayoutPanelProducts.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanelProducts.Location = new Point(0, 60);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Padding = new Padding(10);
            this.flowLayoutPanelProducts.Size = new Size(800, 390);
            this.flowLayoutPanelProducts.TabIndex = 1;
            this.flowLayoutPanelProducts.WrapContents = false;
            // 
            // ProductManagePageControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelProducts);
            this.Controls.Add(this.panelTop);
            this.Name = "ProductManagePageControl";
            this.Size = new Size(800, 450);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnMigrateImages;
        private Button btnImageSettings;
        private FlowLayoutPanel flowLayoutPanelProducts;
        private Panel panelTop;
    }
}