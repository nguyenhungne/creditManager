namespace N9
{
    partial class UCDashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlTotalDebt = new System.Windows.Forms.Panel();
            this.lblTotalDebt = new System.Windows.Forms.Label();
            this.lblTotalDebtTitle = new System.Windows.Forms.Label();
            this.pnlDueCards = new System.Windows.Forms.Panel();
            this.lblDueCards = new System.Windows.Forms.Label();
            this.lblDueCardsTitle = new System.Windows.Forms.Label();
            this.pnlTotalCards = new System.Windows.Forms.Panel();
            this.lblTotalCards = new System.Windows.Forms.Label();
            this.lblTotalCardsTitle = new System.Windows.Forms.Label();
            this.chartOverview = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTotalDebt.SuspendLayout();
            this.pnlDueCards.SuspendLayout();
            this.pnlTotalCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOverview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(20, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(175, 41);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Dashboard";
            // 
            // pnlTotalDebt
            // 
            this.pnlTotalDebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.pnlTotalDebt.Controls.Add(this.lblTotalDebt);
            this.pnlTotalDebt.Controls.Add(this.lblTotalDebtTitle);
            this.pnlTotalDebt.Location = new System.Drawing.Point(26, 80);
            this.pnlTotalDebt.Name = "pnlTotalDebt";
            this.pnlTotalDebt.Size = new System.Drawing.Size(260, 120);
            this.pnlTotalDebt.TabIndex = 1;
            // 
            // lblTotalDebt
            // 
            this.lblTotalDebt.AutoSize = true;
            this.lblTotalDebt.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalDebt.ForeColor = System.Drawing.Color.White;
            this.lblTotalDebt.Location = new System.Drawing.Point(15, 55);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(109, 46);
            this.lblTotalDebt.TabIndex = 1;
            this.lblTotalDebt.Text = "0 VNĐ";
            // 
            // lblTotalDebtTitle
            // 
            this.lblTotalDebtTitle.AutoSize = true;
            this.lblTotalDebtTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalDebtTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalDebtTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTotalDebtTitle.Name = "lblTotalDebtTitle";
            this.lblTotalDebtTitle.Size = new System.Drawing.Size(99, 28);
            this.lblTotalDebtTitle.TabIndex = 0;
            this.lblTotalDebtTitle.Text = "Tổng dư nợ";
            // 
            // pnlDueCards
            // 
            this.pnlDueCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.pnlDueCards.Controls.Add(this.lblDueCards);
            this.pnlDueCards.Controls.Add(this.lblDueCardsTitle);
            this.pnlDueCards.Location = new System.Drawing.Point(306, 80);
            this.pnlDueCards.Name = "pnlDueCards";
            this.pnlDueCards.Size = new System.Drawing.Size(260, 120);
            this.pnlDueCards.TabIndex = 2;
            // 
            // lblDueCards
            // 
            this.lblDueCards.AutoSize = true;
            this.lblDueCards.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblDueCards.ForeColor = System.Drawing.Color.White;
            this.lblDueCards.Location = new System.Drawing.Point(15, 50);
            this.lblDueCards.Name = "lblDueCards";
            this.lblDueCards.Size = new System.Drawing.Size(52, 62);
            this.lblDueCards.TabIndex = 1;
            this.lblDueCards.Text = "0";
            // 
            // lblDueCardsTitle
            // 
            this.lblDueCardsTitle.AutoSize = true;
            this.lblDueCardsTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDueCardsTitle.ForeColor = System.Drawing.Color.White;
            this.lblDueCardsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDueCardsTitle.Name = "lblDueCardsTitle";
            this.lblDueCardsTitle.Size = new System.Drawing.Size(139, 28);
            this.lblDueCardsTitle.TabIndex = 0;
            this.lblDueCardsTitle.Text = "Thẻ sắp đến hạn";
            // 
            // pnlTotalCards
            // 
            this.pnlTotalCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlTotalCards.Controls.Add(this.lblTotalCards);
            this.pnlTotalCards.Controls.Add(this.lblTotalCardsTitle);
            this.pnlTotalCards.Location = new System.Drawing.Point(586, 80);
            this.pnlTotalCards.Name = "pnlTotalCards";
            this.pnlTotalCards.Size = new System.Drawing.Size(260, 120);
            this.pnlTotalCards.TabIndex = 3;
            // 
            // lblTotalCards
            // 
            this.lblTotalCards.AutoSize = true;
            this.lblTotalCards.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalCards.ForeColor = System.Drawing.Color.White;
            this.lblTotalCards.Location = new System.Drawing.Point(15, 50);
            this.lblTotalCards.Name = "lblTotalCards";
            this.lblTotalCards.Size = new System.Drawing.Size(52, 62);
            this.lblTotalCards.TabIndex = 1;
            this.lblTotalCards.Text = "0";
            // 
            // lblTotalCardsTitle
            // 
            this.lblTotalCardsTitle.AutoSize = true;
            this.lblTotalCardsTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalCardsTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalCardsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTotalCardsTitle.Name = "lblTotalCardsTitle";
            this.lblTotalCardsTitle.Size = new System.Drawing.Size(73, 28);
            this.lblTotalCardsTitle.TabIndex = 0;
            this.lblTotalCardsTitle.Text = "Số thẻ";
            // 
            // chartOverview
            // 
            chartArea1.Name = "ChartArea1";
            this.chartOverview.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartOverview.Legends.Add(legend1);
            this.chartOverview.Location = new System.Drawing.Point(26, 220);
            this.chartOverview.Name = "chartOverview";
            this.chartOverview.Size = new System.Drawing.Size(820, 350);
            this.chartOverview.TabIndex = 4;
            // 
            // UCDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chartOverview);
            this.Controls.Add(this.pnlTotalCards);
            this.Controls.Add(this.pnlDueCards);
            this.Controls.Add(this.pnlTotalDebt);
            this.Controls.Add(this.lblWelcome);
            this.Name = "UCDashBoard";
            this.Size = new System.Drawing.Size(900, 600);
            this.pnlTotalDebt.ResumeLayout(false);
            this.pnlTotalDebt.PerformLayout();
            this.pnlDueCards.ResumeLayout(false);
            this.pnlDueCards.PerformLayout();
            this.pnlTotalCards.ResumeLayout(false);
            this.pnlTotalCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOverview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlTotalDebt;
        private System.Windows.Forms.Label lblTotalDebt;
        private System.Windows.Forms.Label lblTotalDebtTitle;
        private System.Windows.Forms.Panel pnlDueCards;
        private System.Windows.Forms.Label lblDueCards;
        private System.Windows.Forms.Label lblDueCardsTitle;
        private System.Windows.Forms.Panel pnlTotalCards;
        private System.Windows.Forms.Label lblTotalCards;
        private System.Windows.Forms.Label lblTotalCardsTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOverview;
    }
}
