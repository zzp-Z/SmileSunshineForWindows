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
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.txtShippingAddress = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.chkIsCustomized = new System.Windows.Forms.CheckBox();
            this.lblSpecialRequirements = new System.Windows.Forms.Label();
            this.txtSpecialRequirements = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(30, 28);
            this.lblOrderNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(125, 18);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Order Number:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(180, 24);
            this.txtOrderNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(298, 28);
            this.txtOrderNumber.TabIndex = 1;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(30, 69);
            this.lblCustomerId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(116, 18);
            this.lblCustomerId.TabIndex = 2;
            this.lblCustomerId.Text = "Customer ID:";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(180, 65);
            this.txtCustomerId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(298, 28);
            this.txtCustomerId.TabIndex = 3;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(30, 111);
            this.lblPaymentMethod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(152, 18);
            this.lblPaymentMethod.TabIndex = 4;
            this.lblPaymentMethod.Text = "Payment Methods:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit card", "Bank transfer", "Alipay", "WeChat Pay" });
            this.cmbPaymentMethod.Location = new System.Drawing.Point(180, 107);
            this.cmbPaymentMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(298, 26);
            this.cmbPaymentMethod.TabIndex = 5;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(30, 152);
            this.lblOrderDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(107, 18);
            this.lblOrderDate.TabIndex = 6;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(180, 148);
            this.dtpOrderDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(298, 28);
            this.dtpOrderDate.TabIndex = 7;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Location = new System.Drawing.Point(30, 194);
            this.lblDeliveryDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(134, 18);
            this.lblDeliveryDate.TabIndex = 8;
            this.lblDeliveryDate.Text = "Delivery Date:";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(180, 190);
            this.dtpDeliveryDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(298, 28);
            this.dtpDeliveryDate.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 235);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 18);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "Processing", "Completed", "Cancelled" });
            this.cmbStatus.Location = new System.Drawing.Point(180, 231);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(298, 26);
            this.cmbStatus.TabIndex = 11;
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Location = new System.Drawing.Point(30, 277);
            this.lblShippingAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(161, 18);
            this.lblShippingAddress.TabIndex = 12;
            this.lblShippingAddress.Text = "Shipping address:";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Location = new System.Drawing.Point(199, 273);
            this.txtShippingAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtShippingAddress.Multiline = true;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new System.Drawing.Size(429, 82);
            this.txtShippingAddress.TabIndex = 13;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(30, 374);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(242, 18);
            this.lblTotalAmount.TabIndex = 14;
            this.lblTotalAmount.Text = "Total amount (in dollars):";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(280, 364);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(348, 28);
            this.txtTotalAmount.TabIndex = 15;
            // 
            // chkIsCustomized
            // 
            this.chkIsCustomized.AutoSize = true;
            this.chkIsCustomized.Location = new System.Drawing.Point(180, 415);
            this.chkIsCustomized.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIsCustomized.Name = "chkIsCustomized";
            this.chkIsCustomized.Size = new System.Drawing.Size(151, 22);
            this.chkIsCustomized.TabIndex = 16;
            this.chkIsCustomized.Text = "Custom Orders";
            this.chkIsCustomized.UseVisualStyleBackColor = true;
            // 
            // lblSpecialRequirements
            // 
            this.lblSpecialRequirements.AutoSize = true;
            this.lblSpecialRequirements.Location = new System.Drawing.Point(30, 457);
            this.lblSpecialRequirements.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpecialRequirements.Name = "lblSpecialRequirements";
            this.lblSpecialRequirements.Size = new System.Drawing.Size(161, 18);
            this.lblSpecialRequirements.TabIndex = 17;
            this.lblSpecialRequirements.Text = "Special Requests:";
            // 
            // txtSpecialRequirements
            // 
            this.txtSpecialRequirements.Location = new System.Drawing.Point(199, 453);
            this.txtSpecialRequirements.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSpecialRequirements.Multiline = true;
            this.txtSpecialRequirements.Name = "txtSpecialRequirements";
            this.txtSpecialRequirements.Size = new System.Drawing.Size(429, 109);
            this.txtSpecialRequirements.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(180, 595);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 32);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(330, 595);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 32);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EditOrder";
            this.Size = new System.Drawing.Size(750, 665);
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
        private System.Windows.Forms.TextBox txtShippingAddress;
        private Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private CheckBox chkIsCustomized;
        private Label lblSpecialRequirements;
        private System.Windows.Forms.TextBox txtSpecialRequirements;
        private Button btnSave;
        private Button btnCancel;
    }
}