using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.Product
{
    partial class CreateOrderForm
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
            this.groupBoxCustomer = new System.Windows.Forms.GroupBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.groupBoxOrderInfo = new System.Windows.Forms.GroupBox();
            this.txtSpecialRequirements = new System.Windows.Forms.TextBox();
            this.lblSpecialRequirements = new System.Windows.Forms.Label();
            this.chkIsCustomized = new System.Windows.Forms.CheckBox();
            this.chkDownPaymentPaid = new System.Windows.Forms.CheckBox();
            this.numDownPaymentPercent = new System.Windows.Forms.NumericUpDown();
            this.lblDownPaymentPercent = new System.Windows.Forms.Label();
            this.txtPaymentTerms = new System.Windows.Forms.TextBox();
            this.lblPaymentTerms = new System.Windows.Forms.Label();
            this.txtShippingAddress = new System.Windows.Forms.TextBox();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.groupBoxOrderItems = new System.Windows.Forms.GroupBox();
            this.listViewOrderItems = new System.Windows.Forms.ListView();
            this.columnHeaderProduct = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderQuantity = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTotalPrice = new System.Windows.Forms.ColumnHeader();
            this.groupBoxTotals = new System.Windows.Forms.GroupBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountLabel = new System.Windows.Forms.Label();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.lblTaxAmountLabel = new System.Windows.Forms.Label();
            this.numShippingCost = new System.Windows.Forms.NumericUpDown();
            this.lblShippingCost = new System.Windows.Forms.Label();
            this.lblProductAmount = new System.Windows.Forms.Label();
            this.lblProductAmountLabel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxCustomer.SuspendLayout();
            this.groupBoxOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDownPaymentPercent)).BeginInit();
            this.groupBoxOrderItems.SuspendLayout();
            this.groupBoxTotals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShippingCost)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Controls.Add(this.btnAddCustomer);
            this.groupBoxCustomer.Controls.Add(this.cmbCustomer);
            this.groupBoxCustomer.Controls.Add(this.lblCustomer);
            this.groupBoxCustomer.Location = new System.Drawing.Point(24, 24);
            this.groupBoxCustomer.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxCustomer.Size = new System.Drawing.Size(1520, 120);
            this.groupBoxCustomer.TabIndex = 0;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "Customer Information";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(562, 44);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(160, 36);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(148, 44);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(6);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(372, 32);
            this.cmbCustomer.TabIndex = 1;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(30, 50);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(118, 24);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer:";
            // 
            // groupBoxOrderInfo
            // 
            this.groupBoxOrderInfo.Controls.Add(this.txtSpecialRequirements);
            this.groupBoxOrderInfo.Controls.Add(this.lblSpecialRequirements);
            this.groupBoxOrderInfo.Controls.Add(this.chkIsCustomized);
            this.groupBoxOrderInfo.Controls.Add(this.chkDownPaymentPaid);
            this.groupBoxOrderInfo.Controls.Add(this.numDownPaymentPercent);
            this.groupBoxOrderInfo.Controls.Add(this.lblDownPaymentPercent);
            this.groupBoxOrderInfo.Controls.Add(this.txtPaymentTerms);
            this.groupBoxOrderInfo.Controls.Add(this.lblPaymentTerms);
            this.groupBoxOrderInfo.Controls.Add(this.txtShippingAddress);
            this.groupBoxOrderInfo.Controls.Add(this.lblShippingAddress);
            this.groupBoxOrderInfo.Controls.Add(this.cmbStatus);
            this.groupBoxOrderInfo.Controls.Add(this.lblStatus);
            this.groupBoxOrderInfo.Controls.Add(this.dtpDeliveryDate);
            this.groupBoxOrderInfo.Controls.Add(this.lblDeliveryDate);
            this.groupBoxOrderInfo.Controls.Add(this.dtpOrderDate);
            this.groupBoxOrderInfo.Controls.Add(this.lblOrderDate);
            this.groupBoxOrderInfo.Controls.Add(this.cmbPaymentMethod);
            this.groupBoxOrderInfo.Controls.Add(this.lblPaymentMethod);
            this.groupBoxOrderInfo.Controls.Add(this.txtOrderNumber);
            this.groupBoxOrderInfo.Controls.Add(this.lblOrderNumber);
            this.groupBoxOrderInfo.Location = new System.Drawing.Point(24, 156);
            this.groupBoxOrderInfo.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxOrderInfo.Name = "groupBoxOrderInfo";
            this.groupBoxOrderInfo.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxOrderInfo.Size = new System.Drawing.Size(1520, 360);
            this.groupBoxOrderInfo.TabIndex = 1;
            this.groupBoxOrderInfo.TabStop = false;
            this.groupBoxOrderInfo.Text = "Order Information";
            // 
            // txtSpecialRequirements
            // 
            this.txtSpecialRequirements.Location = new System.Drawing.Point(304, 304);
            this.txtSpecialRequirements.Margin = new System.Windows.Forms.Padding(6);
            this.txtSpecialRequirements.Name = "txtSpecialRequirements";
            this.txtSpecialRequirements.Size = new System.Drawing.Size(1174, 35);
            this.txtSpecialRequirements.TabIndex = 19;
            // 
            // lblSpecialRequirements
            // 
            this.lblSpecialRequirements.AutoSize = true;
            this.lblSpecialRequirements.Location = new System.Drawing.Point(30, 310);
            this.lblSpecialRequirements.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSpecialRequirements.Name = "lblSpecialRequirements";
            this.lblSpecialRequirements.Size = new System.Drawing.Size(262, 24);
            this.lblSpecialRequirements.TabIndex = 18;
            this.lblSpecialRequirements.Text = "Special Requirements:";
            // 
            // chkIsCustomized
            // 
            this.chkIsCustomized.AutoSize = true;
            this.chkIsCustomized.Location = new System.Drawing.Point(757, 270);
            this.chkIsCustomized.Margin = new System.Windows.Forms.Padding(6);
            this.chkIsCustomized.Name = "chkIsCustomized";
            this.chkIsCustomized.Size = new System.Drawing.Size(186, 28);
            this.chkIsCustomized.TabIndex = 17;
            this.chkIsCustomized.Text = "Custom Order";
            this.chkIsCustomized.UseVisualStyleBackColor = true;
            // 
            // chkDownPaymentPaid
            // 
            this.chkDownPaymentPaid.AutoSize = true;
            this.chkDownPaymentPaid.Location = new System.Drawing.Point(440, 270);
            this.chkDownPaymentPaid.Margin = new System.Windows.Forms.Padding(6);
            this.chkDownPaymentPaid.Name = "chkDownPaymentPaid";
            this.chkDownPaymentPaid.Size = new System.Drawing.Size(282, 28);
            this.chkDownPaymentPaid.TabIndex = 16;
            this.chkDownPaymentPaid.Text = "Advance Payment Paid";
            this.chkDownPaymentPaid.UseVisualStyleBackColor = true;
            // 
            // numDownPaymentPercent
            // 
            this.numDownPaymentPercent.Location = new System.Drawing.Point(220, 266);
            this.numDownPaymentPercent.Margin = new System.Windows.Forms.Padding(6);
            this.numDownPaymentPercent.Name = "numDownPaymentPercent";
            this.numDownPaymentPercent.Size = new System.Drawing.Size(160, 35);
            this.numDownPaymentPercent.TabIndex = 15;
            // 
            // lblDownPaymentPercent
            // 
            this.lblDownPaymentPercent.AutoSize = true;
            this.lblDownPaymentPercent.Location = new System.Drawing.Point(30, 270);
            this.lblDownPaymentPercent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDownPaymentPercent.Name = "lblDownPaymentPercent";
            this.lblDownPaymentPercent.Size = new System.Drawing.Size(322, 24);
            this.lblDownPaymentPercent.TabIndex = 14;
            this.lblDownPaymentPercent.Text = "Advance Payment Ratio (%):";
            // 
            // txtPaymentTerms
            // 
            this.txtPaymentTerms.Location = new System.Drawing.Point(1113, 164);
            this.txtPaymentTerms.Margin = new System.Windows.Forms.Padding(6);
            this.txtPaymentTerms.Multiline = true;
            this.txtPaymentTerms.Name = "txtPaymentTerms";
            this.txtPaymentTerms.Size = new System.Drawing.Size(365, 76);
            this.txtPaymentTerms.TabIndex = 13;
            // 
            // lblPaymentTerms
            // 
            this.lblPaymentTerms.AutoSize = true;
            this.lblPaymentTerms.Location = new System.Drawing.Point(940, 170);
            this.lblPaymentTerms.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPaymentTerms.Name = "lblPaymentTerms";
            this.lblPaymentTerms.Size = new System.Drawing.Size(178, 24);
            this.lblPaymentTerms.TabIndex = 12;
            this.lblPaymentTerms.Text = "Payment Terms:";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Location = new System.Drawing.Point(238, 164);
            this.txtShippingAddress.Margin = new System.Windows.Forms.Padding(6);
            this.txtShippingAddress.Multiline = true;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new System.Drawing.Size(640, 76);
            this.txtShippingAddress.TabIndex = 11;
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Location = new System.Drawing.Point(30, 170);
            this.lblShippingAddress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(214, 24);
            this.lblShippingAddress.TabIndex = 10;
            this.lblShippingAddress.Text = "Delivery Address:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "Completed", "Cancelled" });
            this.cmbStatus.Location = new System.Drawing.Point(1034, 44);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(6);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(196, 32);
            this.cmbStatus.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(940, 50);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(94, 24);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(700, 104);
            this.dtpDeliveryDate.Margin = new System.Windows.Forms.Padding(6);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(226, 35);
            this.dtpDeliveryDate.TabIndex = 7;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Location = new System.Drawing.Point(500, 110);
            this.lblDeliveryDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(178, 24);
            this.lblDeliveryDate.TabIndex = 6;
            this.lblDeliveryDate.Text = "Delivery Date:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(193, 104);
            this.dtpOrderDate.Margin = new System.Windows.Forms.Padding(6);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(236, 35);
            this.dtpOrderDate.TabIndex = 5;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(30, 110);
            this.lblOrderDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(142, 24);
            this.lblOrderDate.TabIndex = 4;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Bank Transfer" });
            this.cmbPaymentMethod.Location = new System.Drawing.Point(700, 44);
            this.cmbPaymentMethod.Margin = new System.Windows.Forms.Padding(6);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(228, 32);
            this.cmbPaymentMethod.TabIndex = 3;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(500, 50);
            this.lblPaymentMethod.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(202, 24);
            this.lblPaymentMethod.TabIndex = 2;
            this.lblPaymentMethod.Text = "Payment Methods:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(193, 44);
            this.txtOrderNumber.Margin = new System.Windows.Forms.Padding(6);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(251, 35);
            this.txtOrderNumber.TabIndex = 1;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(30, 50);
            this.lblOrderNumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(166, 24);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Order Number:";
            // 
            // groupBoxOrderItems
            // 
            this.groupBoxOrderItems.Controls.Add(this.listViewOrderItems);
            this.groupBoxOrderItems.Location = new System.Drawing.Point(24, 528);
            this.groupBoxOrderItems.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxOrderItems.Name = "groupBoxOrderItems";
            this.groupBoxOrderItems.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxOrderItems.Size = new System.Drawing.Size(1000, 400);
            this.groupBoxOrderItems.TabIndex = 2;
            this.groupBoxOrderItems.TabStop = false;
            this.groupBoxOrderItems.Text = "Order Items";
            // 
            // listViewOrderItems
            // 
            this.listViewOrderItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeaderProduct, this.columnHeaderQuantity, this.columnHeaderUnitPrice, this.columnHeaderTotalPrice });
            this.listViewOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOrderItems.FullRowSelect = true;
            this.listViewOrderItems.GridLines = true;
            this.listViewOrderItems.HideSelection = false;
            this.listViewOrderItems.Location = new System.Drawing.Point(6, 34);
            this.listViewOrderItems.Margin = new System.Windows.Forms.Padding(6);
            this.listViewOrderItems.Name = "listViewOrderItems";
            this.listViewOrderItems.Size = new System.Drawing.Size(988, 360);
            this.listViewOrderItems.TabIndex = 0;
            this.listViewOrderItems.UseCompatibleStateImageBehavior = false;
            this.listViewOrderItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderProduct
            // 
            this.columnHeaderProduct.Text = "Product Name";
            this.columnHeaderProduct.Width = 206;
            // 
            // columnHeaderQuantity
            // 
            this.columnHeaderQuantity.Text = "Quantity";
            this.columnHeaderQuantity.Width = 158;
            // 
            // columnHeaderUnitPrice
            // 
            this.columnHeaderUnitPrice.Text = "Unit Price";
            this.columnHeaderUnitPrice.Width = 166;
            // 
            // columnHeaderTotalPrice
            // 
            this.columnHeaderTotalPrice.Text = "Subtotal";
            this.columnHeaderTotalPrice.Width = 205;
            // 
            // groupBoxTotals
            // 
            this.groupBoxTotals.Controls.Add(this.lblTotalAmount);
            this.groupBoxTotals.Controls.Add(this.lblTotalAmountLabel);
            this.groupBoxTotals.Controls.Add(this.lblTaxAmount);
            this.groupBoxTotals.Controls.Add(this.lblTaxAmountLabel);
            this.groupBoxTotals.Controls.Add(this.numShippingCost);
            this.groupBoxTotals.Controls.Add(this.lblShippingCost);
            this.groupBoxTotals.Controls.Add(this.lblProductAmount);
            this.groupBoxTotals.Controls.Add(this.lblProductAmountLabel);
            this.groupBoxTotals.Location = new System.Drawing.Point(1036, 528);
            this.groupBoxTotals.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxTotals.Name = "groupBoxTotals";
            this.groupBoxTotals.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxTotals.Size = new System.Drawing.Size(508, 400);
            this.groupBoxTotals.TabIndex = 3;
            this.groupBoxTotals.TabStop = false;
            this.groupBoxTotals.Text = "Expense Details";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalAmount.Location = new System.Drawing.Point(274, 235);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(107, 42);
            this.lblTotalAmount.TabIndex = 7;
            this.lblTotalAmount.Text = "$0.00";
            // 
            // lblTotalAmountLabel
            // 
            this.lblTotalAmountLabel.AutoSize = true;
            this.lblTotalAmountLabel.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmountLabel.Location = new System.Drawing.Point(30, 240);
            this.lblTotalAmountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotalAmountLabel.Name = "lblTotalAmountLabel";
            this.lblTotalAmountLabel.Size = new System.Drawing.Size(213, 36);
            this.lblTotalAmountLabel.TabIndex = 6;
            this.lblTotalAmountLabel.Text = "Total Amount:";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Location = new System.Drawing.Point(274, 180);
            this.lblTaxAmount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(70, 24);
            this.lblTaxAmount.TabIndex = 5;
            this.lblTaxAmount.Text = "$0.00";
            // 
            // lblTaxAmountLabel
            // 
            this.lblTaxAmountLabel.AutoSize = true;
            this.lblTaxAmountLabel.Location = new System.Drawing.Point(30, 180);
            this.lblTaxAmountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaxAmountLabel.Name = "lblTaxAmountLabel";
            this.lblTaxAmountLabel.Size = new System.Drawing.Size(82, 24);
            this.lblTaxAmountLabel.TabIndex = 4;
            this.lblTaxAmountLabel.Text = "Taxes:";
            // 
            // numShippingCost
            // 
            this.numShippingCost.DecimalPlaces = 2;
            this.numShippingCost.Location = new System.Drawing.Point(274, 109);
            this.numShippingCost.Margin = new System.Windows.Forms.Padding(6);
            this.numShippingCost.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numShippingCost.Name = "numShippingCost";
            this.numShippingCost.Size = new System.Drawing.Size(200, 35);
            this.numShippingCost.TabIndex = 3;
            this.numShippingCost.ValueChanged += new System.EventHandler(this.numShippingCost_ValueChanged);
            // 
            // lblShippingCost
            // 
            this.lblShippingCost.AutoSize = true;
            this.lblShippingCost.Location = new System.Drawing.Point(30, 120);
            this.lblShippingCost.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblShippingCost.Name = "lblShippingCost";
            this.lblShippingCost.Size = new System.Drawing.Size(106, 24);
            this.lblShippingCost.TabIndex = 2;
            this.lblShippingCost.Text = "Freight:";
            // 
            // lblProductAmount
            // 
            this.lblProductAmount.AutoSize = true;
            this.lblProductAmount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductAmount.ForeColor = System.Drawing.Color.Red;
            this.lblProductAmount.Location = new System.Drawing.Point(274, 53);
            this.lblProductAmount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblProductAmount.Name = "lblProductAmount";
            this.lblProductAmount.Size = new System.Drawing.Size(81, 31);
            this.lblProductAmount.TabIndex = 1;
            this.lblProductAmount.Text = "$0.00";
            // 
            // lblProductAmountLabel
            // 
            this.lblProductAmountLabel.AutoSize = true;
            this.lblProductAmountLabel.Location = new System.Drawing.Point(30, 60);
            this.lblProductAmountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblProductAmountLabel.Name = "lblProductAmountLabel";
            this.lblProductAmountLabel.Size = new System.Drawing.Size(214, 24);
            this.lblProductAmountLabel.TabIndex = 0;
            this.lblProductAmountLabel.Text = "Commodity Amount:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1200, 960);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 60);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1384, 960);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 60);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 1044);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBoxTotals);
            this.Controls.Add(this.groupBoxOrderItems);
            this.Controls.Add(this.groupBoxOrderInfo);
            this.Controls.Add(this.groupBoxCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Order";
            this.groupBoxCustomer.ResumeLayout(false);
            this.groupBoxCustomer.PerformLayout();
            this.groupBoxOrderInfo.ResumeLayout(false);
            this.groupBoxOrderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDownPaymentPercent)).EndInit();
            this.groupBoxOrderItems.ResumeLayout(false);
            this.groupBoxTotals.ResumeLayout(false);
            this.groupBoxTotals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShippingCost)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        
        private GroupBox groupBoxCustomer;
        private Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private GroupBox groupBoxOrderInfo;
        private Label lblOrderNumber;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private Label lblDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblShippingAddress;
        private System.Windows.Forms.TextBox txtShippingAddress;
        private Label lblPaymentTerms;
        private System.Windows.Forms.TextBox txtPaymentTerms;
        private Label lblDownPaymentPercent;
        private NumericUpDown numDownPaymentPercent;
        private CheckBox chkDownPaymentPaid;
        private System.Windows.Forms.CheckBox chkIsCustomized;
        private Label lblSpecialRequirements;
        private System.Windows.Forms.TextBox txtSpecialRequirements;
        private GroupBox groupBoxOrderItems;
        private System.Windows.Forms.ListView listViewOrderItems;
        private ColumnHeader columnHeaderProduct;
        private ColumnHeader columnHeaderQuantity;
        private ColumnHeader columnHeaderUnitPrice;
        private ColumnHeader columnHeaderTotalPrice;
        private GroupBox groupBoxTotals;
        private Label lblProductAmountLabel;
        private System.Windows.Forms.Label lblProductAmount;
        private Label lblShippingCost;
        private System.Windows.Forms.NumericUpDown numShippingCost;
        private Label lblTaxAmountLabel;
        private System.Windows.Forms.Label lblTaxAmount;
        private Label lblTotalAmountLabel;
        private System.Windows.Forms.Label lblTotalAmount;
        private Button btnSave;
        private Button btnCancel;
    }
}