namespace N9
{
    partial class UCSaoKe
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
            this.dgvStatements = new System.Windows.Forms.DataGridView();
            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblYellow = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatements)).BeginInit();
            this.pnlLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý kỳ sao kê";
            // 
            // dgvStatements
            // 
            this.dgvStatements.AllowUserToAddRows = false;
            this.dgvStatements.AllowUserToDeleteRows = false;
            this.dgvStatements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatements.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatements.Location = new System.Drawing.Point(20, 100);
            this.dgvStatements.MultiSelect = false;
            this.dgvStatements.Name = "dgvStatements";
            this.dgvStatements.ReadOnly = true;
            this.dgvStatements.RowHeadersWidth = 51;
            this.dgvStatements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatements.Size = new System.Drawing.Size(860, 400);
            this.dgvStatements.TabIndex = 1;
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnConfirmPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPayment.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnConfirmPayment.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.Location = new System.Drawing.Point(20, 520);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(180, 45);
            this.btnConfirmPayment.TabIndex = 2;
            this.btnConfirmPayment.Text = "Xác nhận thanh toán";
            this.btnConfirmPayment.UseVisualStyleBackColor = false;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRefresh.Location = new System.Drawing.Point(220, 520);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 45);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlLegend
            // 
            this.pnlLegend.Controls.Add(this.lblRed);
            this.pnlLegend.Controls.Add(this.lblYellow);
            this.pnlLegend.Controls.Add(this.lblGreen);
            this.pnlLegend.Location = new System.Drawing.Point(20, 60);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(600, 30);
            this.pnlLegend.TabIndex = 4;
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.BackColor = System.Drawing.Color.LightCoral;
            this.lblRed.Location = new System.Drawing.Point(300, 5);
            this.lblRed.Name = "lblRed";
            this.lblRed.Padding = new System.Windows.Forms.Padding(5);
            this.lblRed.Size = new System.Drawing.Size(82, 27);
            this.lblRed.TabIndex = 2;
            this.lblRed.Text = "Quá hạn";
            // 
            // lblYellow
            // 
            this.lblYellow.AutoSize = true;
            this.lblYellow.BackColor = System.Drawing.Color.LightYellow;
            this.lblYellow.Location = new System.Drawing.Point(150, 5);
            this.lblYellow.Name = "lblYellow";
            this.lblYellow.Padding = new System.Windows.Forms.Padding(5);
            this.lblYellow.Size = new System.Drawing.Size(117, 27);
            this.lblYellow.TabIndex = 1;
            this.lblYellow.Text = "Sắp đến hạn";
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.BackColor = System.Drawing.Color.LightGreen;
            this.lblGreen.Location = new System.Drawing.Point(0, 5);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Padding = new System.Windows.Forms.Padding(5);
            this.lblGreen.Size = new System.Drawing.Size(113, 27);
            this.lblGreen.TabIndex = 0;
            this.lblGreen.Text = "Đã thanh toán";
            // 
            // UCSaoKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlLegend);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.dgvStatements);
            this.Controls.Add(this.lblTitle);
            this.Name = "UCSaoKe";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatements)).EndInit();
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvStatements;
        private System.Windows.Forms.Button btnConfirmPayment;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblYellow;
        private System.Windows.Forms.Label lblRed;
    }
}
