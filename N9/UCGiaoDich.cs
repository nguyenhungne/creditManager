using System;
using System.Windows.Forms;
using N9.Models;
using N9.Services.Implementations;
using N9.Repositories.Implementations;

namespace N9
{
    public partial class UCGiaoDich : UserControl
    {
        private User _currentUser;
        private CreditCardService _cardService;
        private TransactionService _transactionService;
        private CategoryRepository _categoryRepository;

        public UCGiaoDich()
        {
            InitializeComponent();
        }

        public UCGiaoDich(User user) : this()
        {
            _currentUser = user;
            _cardService = new CreditCardService();
            _transactionService = new TransactionService();
            _categoryRepository = new CategoryRepository();
            LoadData();
        }

        private void LoadData()
        {
            // Load cards
            var cards = _cardService.GetActiveCards(_currentUser.Id);
            cboCard.DataSource = cards;
            cboCard.DisplayMember = "DisplayName";
            cboCard.ValueMember = "Id";

            // Load categories
            var categories = _categoryRepository.GetAllCategories();
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            // Load frequent merchants for autocomplete
            var merchants = _transactionService.GetFrequentMerchants(_currentUser.Id);
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(merchants.ToArray());
            txtMerchant.AutoCompleteCustomSource = autoComplete;
            txtMerchant.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMerchant.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Set default date
            dtpTransactionDate.Value = DateTime.Today;
        }

        private void chkInstallment_CheckedChanged(object sender, EventArgs e)
        {
            pnlInstallment.Visible = chkInstallment.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text.Replace(",", ""), out amount))
            {
                MessageBox.Show("Số tiền phải là số hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var transaction = new Transaction
            {
                CardId = (int)cboCard.SelectedValue,
                TransactionDate = dtpTransactionDate.Value,
                MerchantName = txtMerchant.Text.Trim(),
                Amount = amount,
                CategoryId = (int)cboCategory.SelectedValue,
                IsInstallment = chkInstallment.Checked,
                InstallmentMonths = chkInstallment.Checked ? (int?)numInstallmentMonths.Value : null,
                InstallmentRate = chkInstallment.Checked ? numInstallmentRate.Value : (decimal?)null
            };

            _transactionService.AddTransaction(transaction);
            MessageBox.Show("Đã thêm giao dịch thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtMerchant.Clear();
            txtAmount.Clear();
            dtpTransactionDate.Value = DateTime.Today;
            chkInstallment.Checked = false;
            numInstallmentMonths.Value = 3;
            numInstallmentRate.Value = 0;
        }

        private bool ValidateForm()
        {
            if (cboCard.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thẻ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMerchant.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
