namespace N9
{
    partial class UCGiaoDich
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.cboCard = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblMerchant = new System.Windows.Forms.Label();
            this.txtMerchant = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.chkInstallment = new System.Windows.Forms.CheckBox();
            this.pnlInstallment = new System.Windows.Forms.Panel();
            this.numInstallmentRate = new System.Windows.Forms.NumericUpDown();
            this.lblInstallmentRate = new System.Windows.Forms.Label();
            this.numInstallmentMonths = new System.Windows.Forms.NumericUpDown();
            this.lblInstallmentMonths = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlInstallment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInstallmentRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInstallmentMonths)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(244, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm giao dịch mới";
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCard.Location = new System.Drawing.Point(32, 80);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(79, 25);
            this.lblCard.TabIndex = 1;
            this.lblCard.Text = "Chọn thẻ";
            // 
            // cboCard
            // 
            this.cboCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboCard.Location = new System.Drawing.Point(36, 108);
            this.cboCard.Name = "cboCard";
            this.cboCard.Size = new System.Drawing.Size(350, 33);
            this.cboCard.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDate.Location = new System.Drawing.Point(32, 160);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(115, 25);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Ngày giao dịch";
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransactionDate.Location = new System.Drawing.Point(36, 188);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(200, 32);
            this.dtpTransactionDate.TabIndex = 4;
            // 
            // lblMerchant
            // 
            this.lblMerchant.AutoSize = true;
            this.lblMerchant.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMerchant.Location = new System.Drawing.Point(32, 240);
            this.lblMerchant.Name = "lblMerchant";
            this.lblMerchant.Size = new System.Drawing.Size(175, 25);
            this.lblMerchant.TabIndex = 5;
            this.lblMerchant.Text = "Đơn vị chấp nhận thẻ";
            // 
            // txtMerchant
            // 
            this.txtMerchant.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMerchant.Location = new System.Drawing.Point(36, 268);
            this.txtMerchant.Name = "txtMerchant";
            this.txtMerchant.Size = new System.Drawing.Size(350, 32);
            this.txtMerchant.TabIndex = 6;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAmount.Location = new System.Drawing.Point(32, 320);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(107, 25);
            this.lblAmount.TabIndex = 7;
            this.lblAmount.Text = "Số tiền (VNĐ)";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAmount.Location = new System.Drawing.Point(36, 348);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 32);
            this.txtAmount.TabIndex = 8;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCategory.Location = new System.Drawing.Point(32, 400);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(119, 25);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "Phân loại chi tiêu";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboCategory.Location = new System.Drawing.Point(36, 428);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(250, 33);
            this.cboCategory.TabIndex = 10;
            // 
            // chkInstallment
            // 
            this.chkInstallment.AutoSize = true;
            this.chkInstallment.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkInstallment.Location = new System.Drawing.Point(36, 480);
            this.chkInstallment.Name = "chkInstallment";
            this.chkInstallment.Size = new System.Drawing.Size(152, 29);
            this.chkInstallment.TabIndex = 11;
            this.chkInstallment.Text = "Đăng ký trả góp";
            this.chkInstallment.CheckedChanged += new System.EventHandler(this.chkInstallment_CheckedChanged);
            // 
            // pnlInstallment
            // 
            this.pnlInstallment.Controls.Add(this.numInstallmentRate);
            this.pnlInstallment.Controls.Add(this.lblInstallmentRate);
            this.pnlInstallment.Controls.Add(this.numInstallmentMonths);
            this.pnlInstallment.Controls.Add(this.lblInstallmentMonths);
            this.pnlInstallment.Location = new System.Drawing.Point(36, 510);
            this.pnlInstallment.Name = "pnlInstallment";
            this.pnlInstallment.Size = new System.Drawing.Size(350, 70);
            this.pnlInstallment.TabIndex = 12;
            this.pnlInstallment.Visible = false;
            // 
            // numInstallmentRate
            // 
            this.numInstallmentRate.DecimalPlaces = 2;
            this.numInstallmentRate.Location = new System.Drawing.Point(200, 30);
            this.numInstallmentRate.Name = "numInstallmentRate";
            this.numInstallmentRate.Size = new System.Drawing.Size(80, 22);
            this.numInstallmentRate.TabIndex = 3;
            // 
            // lblInstallmentRate
            // 
            this.lblInstallmentRate.AutoSize = true;
            this.lblInstallmentRate.Location = new System.Drawing.Point(197, 5);
            this.lblInstallmentRate.Name = "lblInstallmentRate";
            this.lblInstallmentRate.Size = new System.Drawing.Size(68, 17);
            this.lblInstallmentRate.TabIndex = 2;
            this.lblInstallmentRate.Text = "Lãi suất %";
            // 
            // numInstallmentMonths
            // 
            this.numInstallmentMonths.Location = new System.Drawing.Point(0, 30);
            this.numInstallmentMonths.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.numInstallmentMonths.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numInstallmentMonths.Name = "numInstallmentMonths";
            this.numInstallmentMonths.Size = new System.Drawing.Size(80, 22);
            this.numInstallmentMonths.TabIndex = 1;
            this.numInstallmentMonths.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblInstallmentMonths
            // 
            this.lblInstallmentMonths.AutoSize = true;
            this.lblInstallmentMonths.Location = new System.Drawing.Point(-3, 5);
            this.lblInstallmentMonths.Name = "lblInstallmentMonths";
            this.lblInstallmentMonths.Size = new System.Drawing.Size(72, 17);
            this.lblInstallmentMonths.TabIndex = 0;
            this.lblInstallmentMonths.Text = "Số kỳ (tháng)";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(450, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 45);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Lưu giao dịch";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClear.Location = new System.Drawing.Point(450, 168);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 45);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Xóa form";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // UCGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlInstallment);
            this.Controls.Add(this.chkInstallment);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtMerchant);
            this.Controls.Add(this.lblMerchant);
            this.Controls.Add(this.dtpTransactionDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cboCard);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.lblTitle);
            this.Name = "UCGiaoDich";
            this.Size = new System.Drawing.Size(900, 600);
            this.pnlInstallment.ResumeLayout(false);
            this.pnlInstallment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInstallmentRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInstallmentMonths)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.ComboBox cboCard;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label lblMerchant;
        private System.Windows.Forms.TextBox txtMerchant;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.CheckBox chkInstallment;
        private System.Windows.Forms.Panel pnlInstallment;
        private System.Windows.Forms.NumericUpDown numInstallmentMonths;
        private System.Windows.Forms.Label lblInstallmentMonths;
        private System.Windows.Forms.NumericUpDown numInstallmentRate;
        private System.Windows.Forms.Label lblInstallmentRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
    }
}
