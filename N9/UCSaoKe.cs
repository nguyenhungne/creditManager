using System;
using System.Drawing;
using System.Windows.Forms;
using N9.Models;
using N9.Services.Implementations;

namespace N9
{
    public partial class UCSaoKe : UserControl
    {
        private User _currentUser;
        private StatementService _statementService;

        public UCSaoKe()
        {
            InitializeComponent();
        }

        public UCSaoKe(User user) : this()
        {
            _currentUser = user;
            _statementService = new StatementService();
            LoadStatements();
        }

        private void LoadStatements()
        {
            var statements = _statementService.GetAllStatements(_currentUser.Id);
            dgvStatements.DataSource = null;
            dgvStatements.DataSource = statements;

            // Configure columns
            dgvStatements.Columns["Id"].Visible = false;
            dgvStatements.Columns["CardId"].Visible = false;
            dgvStatements.Columns["CardDisplayName"].HeaderText = "Thẻ";
            dgvStatements.Columns["StartDate"].HeaderText = "Từ ngày";
            dgvStatements.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvStatements.Columns["EndDate"].HeaderText = "Đến ngày";
            dgvStatements.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvStatements.Columns["DueDate"].HeaderText = "Hạn thanh toán";
            dgvStatements.Columns["DueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvStatements.Columns["TotalAmount"].HeaderText = "Tổng tiền";
            dgvStatements.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
            dgvStatements.Columns["PaidAmount"].HeaderText = "Đã trả";
            dgvStatements.Columns["PaidAmount"].DefaultCellStyle.Format = "N0";
            dgvStatements.Columns["OutstandingBalance"].HeaderText = "Còn nợ";
            dgvStatements.Columns["OutstandingBalance"].DefaultCellStyle.Format = "N0";
            dgvStatements.Columns["MinimumPayment"].HeaderText = "Tối thiểu";
            dgvStatements.Columns["MinimumPayment"].DefaultCellStyle.Format = "N0";
            dgvStatements.Columns["DaysUntilDue"].HeaderText = "Còn (ngày)";
            dgvStatements.Columns["Status"].HeaderText = "Trạng thái";

            // Apply color highlighting
            foreach (DataGridViewRow row in dgvStatements.Rows)
            {
                var statement = (StatementPeriod)row.DataBoundItem;
                if (statement.Status == StatementStatus.Paid)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (statement.DaysUntilDue < 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if (statement.DaysUntilDue <= 3)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (dgvStatements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn kỳ sao kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var statement = (StatementPeriod)dgvStatements.SelectedRows[0].DataBoundItem;
            
            if (statement.Status == StatementStatus.Paid)
            {
                MessageBox.Show("Kỳ sao kê này đã được thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Xác nhận thanh toán {statement.OutstandingBalance:N0} VNĐ cho kỳ sao kê này?",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _statementService.ConfirmPayment(statement.Id, statement.OutstandingBalance);
                MessageBox.Show("Đã xác nhận thanh toán!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStatements();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatements();
        }
    }
}
