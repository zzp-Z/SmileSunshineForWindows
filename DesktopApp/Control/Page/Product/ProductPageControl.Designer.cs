using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.Product
{
    partial class ProductPageControl
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
            this.btnCreateOrder = new Button();
            this.btnRefresh = new Button();
            this.flowLayoutPanelProducts = new FlowLayoutPanel();
            this.panelTop = new Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnCreateOrder);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(800, 60);
            this.panelTop.TabIndex = 0;
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new Point(20, 15);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new Size(100, 30);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new EventHandler(this.btnCreateOrder_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new Point(140, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(80, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
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
            // ProductPageControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelProducts);
            this.Controls.Add(this.panelTop);
            this.Name = "ProductPageControl";
            this.Size = new Size(800, 450);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        
        private Button btnCreateOrder;
        private Button btnRefresh;
        private FlowLayoutPanel flowLayoutPanelProducts;
        private Panel panelTop;
    }
}