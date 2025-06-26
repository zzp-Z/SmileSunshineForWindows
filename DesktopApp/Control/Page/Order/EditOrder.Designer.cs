using System.ComponentModel;
using System.Windows.Forms;

namespace DesktopApp.Control.Page.Order
{
    partial class EditOrder
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
            this.lblOrderNumber = new Label();
            this.txtOrderNumber = new TextBox();
            this.lblCustomerId = new Label();
            this.txtCustomerId = new TextBox();
            this.lblPaymentMethod = new Label();
            this.cmbPaymentMethod = new ComboBox();
            this.lblOrderDate = new Label();
            this.dtpOrderDate = new DateTimePicker();
            this.lblDeliveryDate = new Label();
            this.dtpDeliveryDate = new DateTimePicker();
            this.lblStatus = new Label();
            this.cmbStatus = new ComboBox();
            this.lblShippingAddress = new Label();
            this.txtShippingAddress = new TextBox();
            this.lblTotalAmount = new Label();
            this.txtTotalAmount = new TextBox();
            this.chkIsCustomized = new CheckBox();
            this.lblSpecialRequirements = new Label();
            this.txtSpecialRequirements = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(20, 20);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(53, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "订单号:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(120, 17);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(200, 20);
            this.txtOrderNumber.TabIndex = 1;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(20, 50);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(53, 13);
            this.lblCustomerId.TabIndex = 2;
            this.lblCustomerId.Text = "客户ID:";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(120, 47);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerId.TabIndex = 3;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 80);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(65, 13);
            this.lblPaymentMethod.TabIndex = 4;
            this.lblPaymentMethod.Text = "支付方式:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "现金",
            "信用卡",
            "银行转账",
            "支付宝",
            "微信支付"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(120, 77);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(200, 21);
            this.cmbPaymentMethod.TabIndex = 5;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(20, 110);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(65, 13);
            this.lblOrderDate.TabIndex = 6;
            this.lblOrderDate.Text = "订单日期:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(120, 107);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 20);
            this.dtpOrderDate.TabIndex = 7;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Location = new System.Drawing.Point(20, 140);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(65, 13);
            this.lblDeliveryDate.TabIndex = 8;
            this.lblDeliveryDate.Text = "交付日期:";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(120, 137);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDeliveryDate.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 170);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "状态:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "待处理",
            "处理中",
            "已完成",
            "已取消"});
            this.cmbStatus.Location = new System.Drawing.Point(120, 167);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 21);
            this.cmbStatus.TabIndex = 11;
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Location = new System.Drawing.Point(20, 200);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(65, 13);
            this.lblShippingAddress.TabIndex = 12;
            this.lblShippingAddress.Text = "配送地址:";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Location = new System.Drawing.Point(120, 197);
            this.txtShippingAddress.Multiline = true;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new System.Drawing.Size(300, 60);
            this.txtShippingAddress.TabIndex = 13;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 270);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(77, 13);
            this.lblTotalAmount.TabIndex = 14;
            this.lblTotalAmount.Text = "总金额(元):";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(120, 267);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(200, 20);
            this.txtTotalAmount.TabIndex = 15;
            // 
            // chkIsCustomized
            // 
            this.chkIsCustomized.AutoSize = true;
            this.chkIsCustomized.Location = new System.Drawing.Point(120, 300);
            this.chkIsCustomized.Name = "chkIsCustomized";
            this.chkIsCustomized.Size = new System.Drawing.Size(72, 17);
            this.chkIsCustomized.TabIndex = 16;
            this.chkIsCustomized.Text = "定制订单";
            this.chkIsCustomized.UseVisualStyleBackColor = true;
            // 
            // lblSpecialRequirements
            // 
            this.lblSpecialRequirements.AutoSize = true;
            this.lblSpecialRequirements.Location = new System.Drawing.Point(20, 330);
            this.lblSpecialRequirements.Name = "lblSpecialRequirements";
            this.lblSpecialRequirements.Size = new System.Drawing.Size(65, 13);
            this.lblSpecialRequirements.TabIndex = 17;
            this.lblSpecialRequirements.Text = "特殊要求:";
            // 
            // txtSpecialRequirements
            // 
            this.txtSpecialRequirements.Location = new System.Drawing.Point(120, 327);
            this.txtSpecialRequirements.Multiline = true;
            this.txtSpecialRequirements.Name = "txtSpecialRequirements";
            this.txtSpecialRequirements.Size = new System.Drawing.Size(300, 80);
            this.txtSpecialRequirements.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSpecialRequirements);
            this.Controls.Add(this.lblSpecialRequirements);
            this.Controls.Add(this.chkIsCustomized);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.txtShippingAddress);
            this.Controls.Add(this.lblShippingAddress);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.lblCustomerId);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.lblOrderNumber);
            this.Name = "EditOrder";
            this.Size = new System.Drawing.Size(500, 480);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblOrderNumber;
        private TextBox txtOrderNumber;
        private Label lblCustomerId;
        private TextBox txtCustomerId;
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
        private Label lblTotalAmount;
        private TextBox txtTotalAmount;
        private CheckBox chkIsCustomized;
        private Label lblSpecialRequirements;
        private TextBox txtSpecialRequirements;
        private Button btnSave;
        private Button btnCancel;
    }
}