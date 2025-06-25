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
            this.groupBoxCustomer = new GroupBox();
            this.btnAddCustomer = new Button();
            this.cmbCustomer = new ComboBox();
            this.lblCustomer = new Label();
            this.groupBoxOrderInfo = new GroupBox();
            this.txtSpecialRequirements = new TextBox();
            this.lblSpecialRequirements = new Label();
            this.chkIsCustomized = new CheckBox();
            this.chkDownPaymentPaid = new CheckBox();
            this.numDownPaymentPercent = new NumericUpDown();
            this.lblDownPaymentPercent = new Label();
            this.txtPaymentTerms = new TextBox();
            this.lblPaymentTerms = new Label();
            this.txtShippingAddress = new TextBox();
            this.lblShippingAddress = new Label();
            this.cmbStatus = new ComboBox();
            this.lblStatus = new Label();
            this.dtpDeliveryDate = new DateTimePicker();
            this.lblDeliveryDate = new Label();
            this.dtpOrderDate = new DateTimePicker();
            this.lblOrderDate = new Label();
            this.cmbPaymentMethod = new ComboBox();
            this.lblPaymentMethod = new Label();
            this.txtOrderNumber = new TextBox();
            this.lblOrderNumber = new Label();
            this.groupBoxOrderItems = new GroupBox();
            this.listViewOrderItems = new ListView();
            this.columnHeaderProduct = new ColumnHeader();
            this.columnHeaderQuantity = new ColumnHeader();
            this.columnHeaderUnitPrice = new ColumnHeader();
            this.columnHeaderTotalPrice = new ColumnHeader();
            this.groupBoxTotals = new GroupBox();
            this.lblTotalAmount = new Label();
            this.lblTotalAmountLabel = new Label();
            this.lblTaxAmount = new Label();
            this.lblTaxAmountLabel = new Label();
            this.numShippingCost = new NumericUpDown();
            this.lblShippingCost = new Label();
            this.lblProductAmount = new Label();
            this.lblProductAmountLabel = new Label();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.groupBoxCustomer.SuspendLayout();
            this.groupBoxOrderInfo.SuspendLayout();
            ((ISupportInitialize)(this.numDownPaymentPercent)).BeginInit();
            this.groupBoxOrderItems.SuspendLayout();
            this.groupBoxTotals.SuspendLayout();
            ((ISupportInitialize)(this.numShippingCost)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Controls.Add(this.btnAddCustomer);
            this.groupBoxCustomer.Controls.Add(this.cmbCustomer);
            this.groupBoxCustomer.Controls.Add(this.lblCustomer);
            this.groupBoxCustomer.Location = new Point(12, 12);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Size = new Size(760, 60);
            this.groupBoxCustomer.TabIndex = 0;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "客户信息";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new Point(15, 25);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new Size(41, 12);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "客户:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new Point(62, 22);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new Size(200, 20);
            this.cmbCustomer.TabIndex = 1;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new Point(280, 20);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new Size(80, 25);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.Text = "添加客户";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new EventHandler(this.btnAddCustomer_Click);
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
            this.groupBoxOrderInfo.Location = new Point(12, 78);
            this.groupBoxOrderInfo.Name = "groupBoxOrderInfo";
            this.groupBoxOrderInfo.Size = new Size(760, 180);
            this.groupBoxOrderInfo.TabIndex = 1;
            this.groupBoxOrderInfo.TabStop = false;
            this.groupBoxOrderInfo.Text = "订单信息";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new Point(15, 25);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new Size(53, 12);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "订单号:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new Point(74, 22);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new Size(150, 21);
            this.txtOrderNumber.TabIndex = 1;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new Point(250, 25);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new Size(65, 12);
            this.lblPaymentMethod.TabIndex = 2;
            this.lblPaymentMethod.Text = "支付方式:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] { "现金", "信用卡", "银行转账" });
            this.cmbPaymentMethod.Location = new Point(321, 22);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new Size(120, 20);
            this.cmbPaymentMethod.TabIndex = 3;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new Point(15, 55);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new Size(65, 12);
            this.lblOrderDate.TabIndex = 4;
            this.lblOrderDate.Text = "订单日期:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new Point(86, 52);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new Size(120, 21);
            this.dtpOrderDate.TabIndex = 5;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Location = new Point(250, 55);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new Size(65, 12);
            this.lblDeliveryDate.TabIndex = 6;
            this.lblDeliveryDate.Text = "交付日期:";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Format = DateTimePickerFormat.Short;
            this.dtpDeliveryDate.Location = new Point(321, 52);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new Size(120, 21);
            this.dtpDeliveryDate.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(470, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(41, 12);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "状态:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "待处理", "已完成", "已取消" });
            this.cmbStatus.Location = new Point(517, 22);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new Size(100, 20);
            this.cmbStatus.TabIndex = 9;
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Location = new Point(15, 85);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new Size(65, 12);
            this.lblShippingAddress.TabIndex = 10;
            this.lblShippingAddress.Text = "配送地址:";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Location = new Point(86, 82);
            this.txtShippingAddress.Multiline = true;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new Size(355, 40);
            this.txtShippingAddress.TabIndex = 11;
            // 
            // lblPaymentTerms
            // 
            this.lblPaymentTerms.AutoSize = true;
            this.lblPaymentTerms.Location = new Point(470, 85);
            this.lblPaymentTerms.Name = "lblPaymentTerms";
            this.lblPaymentTerms.Size = new Size(65, 12);
            this.lblPaymentTerms.TabIndex = 12;
            this.lblPaymentTerms.Text = "付款条件:";
            // 
            // txtPaymentTerms
            // 
            this.txtPaymentTerms.Location = new Point(541, 82);
            this.txtPaymentTerms.Multiline = true;
            this.txtPaymentTerms.Name = "txtPaymentTerms";
            this.txtPaymentTerms.Size = new Size(200, 40);
            this.txtPaymentTerms.TabIndex = 13;
            // 
            // lblDownPaymentPercent
            // 
            this.lblDownPaymentPercent.AutoSize = true;
            this.lblDownPaymentPercent.Location = new Point(15, 135);
            this.lblDownPaymentPercent.Name = "lblDownPaymentPercent";
            this.lblDownPaymentPercent.Size = new Size(89, 12);
            this.lblDownPaymentPercent.TabIndex = 14;
            this.lblDownPaymentPercent.Text = "预付款比例(%):";
            // 
            // numDownPaymentPercent
            // 
            this.numDownPaymentPercent.Location = new Point(110, 133);
            this.numDownPaymentPercent.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numDownPaymentPercent.Name = "numDownPaymentPercent";
            this.numDownPaymentPercent.Size = new Size(80, 21);
            this.numDownPaymentPercent.TabIndex = 15;
            // 
            // chkDownPaymentPaid
            // 
            this.chkDownPaymentPaid.AutoSize = true;
            this.chkDownPaymentPaid.Location = new Point(220, 135);
            this.chkDownPaymentPaid.Name = "chkDownPaymentPaid";
            this.chkDownPaymentPaid.Size = new Size(96, 16);
            this.chkDownPaymentPaid.TabIndex = 16;
            this.chkDownPaymentPaid.Text = "预付款已支付";
            this.chkDownPaymentPaid.UseVisualStyleBackColor = true;
            // 
            // chkIsCustomized
            // 
            this.chkIsCustomized.AutoSize = true;
            this.chkIsCustomized.Location = new Point(350, 135);
            this.chkIsCustomized.Name = "chkIsCustomized";
            this.chkIsCustomized.Size = new Size(72, 16);
            this.chkIsCustomized.TabIndex = 17;
            this.chkIsCustomized.Text = "定制订单";
            this.chkIsCustomized.UseVisualStyleBackColor = true;
            // 
            // lblSpecialRequirements
            // 
            this.lblSpecialRequirements.AutoSize = true;
            this.lblSpecialRequirements.Location = new Point(15, 155);
            this.lblSpecialRequirements.Name = "lblSpecialRequirements";
            this.lblSpecialRequirements.Size = new Size(65, 12);
            this.lblSpecialRequirements.TabIndex = 18;
            this.lblSpecialRequirements.Text = "特殊要求:";
            // 
            // txtSpecialRequirements
            // 
            this.txtSpecialRequirements.Location = new Point(86, 152);
            this.txtSpecialRequirements.Name = "txtSpecialRequirements";
            this.txtSpecialRequirements.Size = new Size(655, 21);
            this.txtSpecialRequirements.TabIndex = 19;
            // 
            // groupBoxOrderItems
            // 
            this.groupBoxOrderItems.Controls.Add(this.listViewOrderItems);
            this.groupBoxOrderItems.Location = new Point(12, 264);
            this.groupBoxOrderItems.Name = "groupBoxOrderItems";
            this.groupBoxOrderItems.Size = new Size(500, 200);
            this.groupBoxOrderItems.TabIndex = 2;
            this.groupBoxOrderItems.TabStop = false;
            this.groupBoxOrderItems.Text = "订单商品";
            // 
            // listViewOrderItems
            // 
            this.listViewOrderItems.Columns.AddRange(new ColumnHeader[] { this.columnHeaderProduct, this.columnHeaderQuantity, this.columnHeaderUnitPrice, this.columnHeaderTotalPrice });
            this.listViewOrderItems.Dock = DockStyle.Fill;
            this.listViewOrderItems.FullRowSelect = true;
            this.listViewOrderItems.GridLines = true;
            this.listViewOrderItems.Location = new Point(3, 17);
            this.listViewOrderItems.Name = "listViewOrderItems";
            this.listViewOrderItems.Size = new Size(494, 180);
            this.listViewOrderItems.TabIndex = 0;
            this.listViewOrderItems.UseCompatibleStateImageBehavior = false;
            this.listViewOrderItems.View = View.Details;
            // 
            // columnHeaderProduct
            // 
            this.columnHeaderProduct.Text = "产品名称";
            this.columnHeaderProduct.Width = 200;
            // 
            // columnHeaderQuantity
            // 
            this.columnHeaderQuantity.Text = "数量";
            this.columnHeaderQuantity.Width = 80;
            // 
            // columnHeaderUnitPrice
            // 
            this.columnHeaderUnitPrice.Text = "单价";
            this.columnHeaderUnitPrice.Width = 100;
            // 
            // columnHeaderTotalPrice
            // 
            this.columnHeaderTotalPrice.Text = "小计";
            this.columnHeaderTotalPrice.Width = 100;
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
            this.groupBoxTotals.Location = new Point(518, 264);
            this.groupBoxTotals.Name = "groupBoxTotals";
            this.groupBoxTotals.Size = new Size(254, 200);
            this.groupBoxTotals.TabIndex = 3;
            this.groupBoxTotals.TabStop = false;
            this.groupBoxTotals.Text = "费用明细";
            // 
            // lblProductAmountLabel
            // 
            this.lblProductAmountLabel.AutoSize = true;
            this.lblProductAmountLabel.Location = new Point(15, 30);
            this.lblProductAmountLabel.Name = "lblProductAmountLabel";
            this.lblProductAmountLabel.Size = new Size(65, 12);
            this.lblProductAmountLabel.TabIndex = 0;
            this.lblProductAmountLabel.Text = "商品金额:";
            // 
            // lblProductAmount
            // 
            this.lblProductAmount.AutoSize = true;
            this.lblProductAmount.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold);
            this.lblProductAmount.ForeColor = Color.Red;
            this.lblProductAmount.Location = new Point(86, 30);
            this.lblProductAmount.Name = "lblProductAmount";
            this.lblProductAmount.Size = new Size(42, 17);
            this.lblProductAmount.TabIndex = 1;
            this.lblProductAmount.Text = "¥0.00";
            // 
            // lblShippingCost
            // 
            this.lblShippingCost.AutoSize = true;
            this.lblShippingCost.Location = new Point(15, 60);
            this.lblShippingCost.Name = "lblShippingCost";
            this.lblShippingCost.Size = new Size(53, 12);
            this.lblShippingCost.TabIndex = 2;
            this.lblShippingCost.Text = "运费:";
            // 
            // numShippingCost
            // 
            this.numShippingCost.DecimalPlaces = 2;
            this.numShippingCost.Location = new Point(86, 58);
            this.numShippingCost.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numShippingCost.Name = "numShippingCost";
            this.numShippingCost.Size = new Size(120, 21);
            this.numShippingCost.TabIndex = 3;
            this.numShippingCost.ValueChanged += new EventHandler(this.numShippingCost_ValueChanged);
            // 
            // lblTaxAmountLabel
            // 
            this.lblTaxAmountLabel.AutoSize = true;
            this.lblTaxAmountLabel.Location = new Point(15, 90);
            this.lblTaxAmountLabel.Name = "lblTaxAmountLabel";
            this.lblTaxAmountLabel.Size = new Size(41, 12);
            this.lblTaxAmountLabel.TabIndex = 4;
            this.lblTaxAmountLabel.Text = "税费:";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Location = new Point(86, 90);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new Size(35, 12);
            this.lblTaxAmount.TabIndex = 5;
            this.lblTaxAmount.Text = "¥0.00";
            // 
            // lblTotalAmountLabel
            // 
            this.lblTotalAmountLabel.AutoSize = true;
            this.lblTotalAmountLabel.Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold);
            this.lblTotalAmountLabel.Location = new Point(15, 120);
            this.lblTotalAmountLabel.Name = "lblTotalAmountLabel";
            this.lblTotalAmountLabel.Size = new Size(68, 19);
            this.lblTotalAmountLabel.TabIndex = 6;
            this.lblTotalAmountLabel.Text = "总金额:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold);
            this.lblTotalAmount.ForeColor = Color.Red;
            this.lblTotalAmount.Location = new Point(86, 118);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new Size(51, 22);
            this.lblTotalAmount.TabIndex = 7;
            this.lblTotalAmount.Text = "¥0.00";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = Color.FromArgb(0, 122, 204);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(600, 480);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(80, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(692, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(784, 522);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBoxTotals);
            this.Controls.Add(this.groupBoxOrderItems);
            this.Controls.Add(this.groupBoxOrderInfo);
            this.Controls.Add(this.groupBoxCustomer);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateOrderForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "创建订单";
            this.groupBoxCustomer.ResumeLayout(false);
            this.groupBoxCustomer.PerformLayout();
            this.groupBoxOrderInfo.ResumeLayout(false);
            this.groupBoxOrderInfo.PerformLayout();
            ((ISupportInitialize)(this.numDownPaymentPercent)).EndInit();
            this.groupBoxOrderItems.ResumeLayout(false);
            this.groupBoxTotals.ResumeLayout(false);
            this.groupBoxTotals.PerformLayout();
            ((ISupportInitialize)(this.numShippingCost)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        
        private GroupBox groupBoxCustomer;
        private Label lblCustomer;
        private ComboBox cmbCustomer;
        private Button btnAddCustomer;
        private GroupBox groupBoxOrderInfo;
        private Label lblOrderNumber;
        private TextBox txtOrderNumber;
        private Label lblPaymentMethod;
        private ComboBox cmbPaymentMethod;
        private Label lblOrderDate;
        private DateTimePicker dtpOrderDate;
        private Label lblDeliveryDate;
        private DateTimePicker dtpDeliveryDate;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblShippingAddress;
        private TextBox txtShippingAddress;
        private Label lblPaymentTerms;
        private TextBox txtPaymentTerms;
        private Label lblDownPaymentPercent;
        private NumericUpDown numDownPaymentPercent;
        private CheckBox chkDownPaymentPaid;
        private CheckBox chkIsCustomized;
        private Label lblSpecialRequirements;
        private TextBox txtSpecialRequirements;
        private GroupBox groupBoxOrderItems;
        private ListView listViewOrderItems;
        private ColumnHeader columnHeaderProduct;
        private ColumnHeader columnHeaderQuantity;
        private ColumnHeader columnHeaderUnitPrice;
        private ColumnHeader columnHeaderTotalPrice;
        private GroupBox groupBoxTotals;
        private Label lblProductAmountLabel;
        private Label lblProductAmount;
        private Label lblShippingCost;
        private NumericUpDown numShippingCost;
        private Label lblTaxAmountLabel;
        private Label lblTaxAmount;
        private Label lblTotalAmountLabel;
        private Label lblTotalAmount;
        private Button btnSave;
        private Button btnCancel;
    }
}