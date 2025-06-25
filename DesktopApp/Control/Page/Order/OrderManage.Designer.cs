using System.ComponentModel;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.Order
{
    partial class OrderManage
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
            this.btnEdit = new Button();
            this.btnExportPdf = new Button();
            this.dgvOrders = new DataGridView();
            this.flpOrderItems = new FlowLayoutPanel();
            this.lblOrders = new Label();
            this.lblOrderItems = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Location = new System.Drawing.Point(100, 12);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(85, 23);
            this.btnExportPdf.TabIndex = 5;
            this.btnExportPdf.Text = "Export PDF";
            this.btnExportPdf.UseVisualStyleBackColor = true;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 70);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(776, 200);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // flpOrderItems
            // 
            this.flpOrderItems.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.flpOrderItems.AutoScroll = true;
            this.flpOrderItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.flpOrderItems.FlowDirection = FlowDirection.TopDown;
            this.flpOrderItems.Location = new System.Drawing.Point(12, 310);
            this.flpOrderItems.Name = "flpOrderItems";
            this.flpOrderItems.Padding = new Padding(5);
            this.flpOrderItems.Size = new System.Drawing.Size(776, 180);
            this.flpOrderItems.TabIndex = 2;
            this.flpOrderItems.WrapContents = false;
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.Location = new System.Drawing.Point(12, 50);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(67, 15);
            this.lblOrders.TabIndex = 3;
            this.lblOrders.Text = "Order List";
            // 
            // lblOrderItems
            // 
            this.lblOrderItems.AutoSize = true;
            this.lblOrderItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderItems.Location = new System.Drawing.Point(12, 290);
            this.lblOrderItems.Name = "lblOrderItems";
            this.lblOrderItems.Size = new System.Drawing.Size(67, 15);
            this.lblOrderItems.TabIndex = 4;
            this.lblOrderItems.Text = "Order Item";
            // 
            // OrderManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.lblOrderItems);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.flpOrderItems);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnExportPdf);
            this.Controls.Add(this.btnEdit);
            this.Name = "OrderManage";
            this.Size = new System.Drawing.Size(800, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Button btnEdit;
        private Button btnExportPdf;
        private DataGridView dgvOrders;
        private FlowLayoutPanel flpOrderItems;
        private Label lblOrders;
        private Label lblOrderItems;
    }
}