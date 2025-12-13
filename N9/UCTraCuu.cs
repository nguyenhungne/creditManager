using System;
using System.Linq;
using System.Windows.Forms;
using N9.Models;
using N9.Services.Implementations;
using N9.Repositories.Implementations;
using N9.Helpers;

namespace N9
{
    public partial class UCTraCuu : UserControl
    {
        private User _currentUser;
        private TransactionService _transactionService;
        private CreditCardService _cardService;
        private CategoryRepository _categoryRepository;

        public UCTraCuu()
        {
            InitializeComponent();
        }

        public UCTraCuu(User user) : this()
        {
            _currentUser = user;
            _transactionService = new TransactionService();
            _cardService = new CreditCardService();
            _categoryRepository = new CategoryRepository();
            LoadFilters();
        }

        private void LoadFilters()
        {
            // Load cards
            var cards = _cardService.GetAllCards(_currentUser.Id);
            cboCard.Items.Clear();
            cboCard.Items.Add(new { Id = (int?)null, DisplayName = "-- Tất cả thẻ --" });
            foreach (var card in cards)
            {
                cboCard.Items.Add(new { Id = (int?)card.Id, card.DisplayName });
            }
            cboCard.DisplayMember = "DisplayName";
            cboCard.ValueMember = "Id";
            cboCard.SelectedIndex = 0;

            // Load categories
            var categories = _categoryRepository.GetAllCategories();
            cboCategory.Items.Clear();
            cboCategory.Items.Add(new { Id = (int?)null, Name = "-- Tất cả --" });
            foreach (var cat in categories)
            {
                cboCategory.Items.Add(new { Id = (int?)cat.Id, cat.Name });
            }
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.SelectedIndex = 0;

            // Set default dates
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            var filter = new TransactionFilter
            {
                Keyword = txtKeyword.Text.Trim(),
                FromDate = dtpFrom.Value.Date,
                ToDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1)
            };

            if (cboCard.SelectedIndex > 0)
            {
                dynamic selected = cboCard.SelectedItem;
                filter.CardId = selected.Id;
            }

            if (cboCategory.SelectedIndex > 0)
            {
                dynamic selected = cboCategory.SelectedItem;
                filter.CategoryId = selected.Id;
            }

            decimal minAmount, maxAmount;
            if (decimal.TryParse(txtMinAmount.Text, out minAmount))
                filter.MinAmount = minAmount;
            if (decimal.TryParse(txtMaxAmount.Text, out maxAmount))
                filter.MaxAmount = maxAmount;

            var transactions = _transactionService.GetTransactions(_currentUser.Id, filter);
            dgvResults.DataSource = null;
            dgvResults.DataSource = transactions;

            // Configure columns
            dgvResults.Columns["Id"].Visible = false;
            dgvResults.Columns["CardId"].Visible = false;
            dgvResults.Columns["StatementId"].Visible = false;
            dgvResults.Columns["CategoryId"].Visible = false;
            dgvResults.Columns["InstallmentMonths"].Visible = false;
            dgvResults.Columns["InstallmentRate"].Visible = false;
            dgvResults.Columns["CreatedAt"].Visible = false;

            dgvResults.Columns["CardDisplayName"].HeaderText = "Thẻ";
            dgvResults.Columns["TransactionDate"].HeaderText = "Ngày";
            dgvResults.Columns["TransactionDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvResults.Columns["MerchantName"].HeaderText = "Đơn vị";
            dgvResults.Columns["Amount"].HeaderText = "Số tiền";
            dgvResults.Columns["Amount"].DefaultCellStyle.Format = "N0";
            dgvResults.Columns["CategoryName"].HeaderText = "Phân loại";
            dgvResults.Columns["IsInstallment"].HeaderText = "Trả góp";

            // Update total
            var total = _transactionService.GetTotalAmount(transactions);
            lblTotal.Text = $"Tổng: {total:N0} VNĐ ({transactions.Count} giao dịch)";
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvResults.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Files (*.csv)|*.csv";
                dialog.FileName = $"GiaoDich_{DateTime.Now:yyyyMMdd}";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelExporter.ExportToCsv(dgvResults, dialog.FileName);
                    MessageBox.Show("Xuất file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            txtMinAmount.Clear();
            txtMaxAmount.Clear();
            cboCard.SelectedIndex = 0;
            cboCategory.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            dgvResults.DataSource = null;
            lblTotal.Text = "";
        }
    }
}
