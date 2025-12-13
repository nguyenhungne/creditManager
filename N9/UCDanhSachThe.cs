using System;
using System.Windows.Forms;
using N9.Models;
using N9.Services.Implementations;

namespace N9
{
    public partial class UCDanhSachThe : UserControl
    {
        private User _currentUser;
        private CreditCardService _cardService;

        public UCDanhSachThe()
        {
            InitializeComponent();
        }

        public UCDanhSachThe(User user) : this()
        {
            _currentUser = user;
            _cardService = new CreditCardService();
            LoadCards();
        }

        private void LoadCards()
        {
            var cards = _cardService.GetAllCards(_currentUser.Id);
            dgvCards.DataSource = null;
            dgvCards.DataSource = cards;
            
            dgvCards.Columns["Id"].Visible = false;
            dgvCards.Columns["UserId"].Visible = false;
            dgvCards.Columns["DisplayName"].Visible = false;
            
            dgvCards.Columns["BankName"].HeaderText = "Ngân hàng";
            dgvCards.Columns["CardType"].HeaderText = "Loại thẻ";
            dgvCards.Columns["Last4Digits"].HeaderText = "4 số cuối";
            dgvCards.Columns["CreditLimit"].HeaderText = "Hạn mức";
            dgvCards.Columns["CreditLimit"].DefaultCellStyle.Format = "N0";
            dgvCards.Columns["StatementDay"].HeaderText = "Ngày sao kê";
            dgvCards.Columns["DueDayOffset"].HeaderText = "Hạn thanh toán";
            dgvCards.Columns["Status"].HeaderText = "Trạng thái";
            dgvCards.Columns["CreatedAt"].HeaderText = "Ngày tạo";
            dgvCards.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlForm.Visible = true;
            lblFormTitle.Text = "Thêm thẻ mới";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCards.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thẻ cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var card = (CreditCard)dgvCards.SelectedRows[0].DataBoundItem;
            LoadCardToForm(card);
            pnlForm.Visible = true;
            lblFormTitle.Text = "Sửa thông tin thẻ";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCards.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thẻ cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var card = (CreditCard)dgvCards.SelectedRows[0].DataBoundItem;
            
            if (_cardService.HasTransactions(card.Id))
            {
                var confirm = MessageBox.Show(
                    "Thẻ này đã có giao dịch. Bạn có chắc muốn xóa?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;
            }

            _cardService.DeleteCard(card.Id);
            LoadCards();
            MessageBox.Show("Đã xóa thẻ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            decimal creditLimit;
            if (!decimal.TryParse(txtCreditLimit.Text.Replace(",", ""), out creditLimit))
            {
                MessageBox.Show("Hạn mức phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var card = new CreditCard
            {
                Id = (int)txtCardId.Tag,
                UserId = _currentUser.Id,
                BankName = txtBankName.Text.Trim(),
                CardType = cboCardType.SelectedItem.ToString(),
                Last4Digits = txtLast4Digits.Text.Trim(),
                CreditLimit = creditLimit,
                StatementDay = (int)numStatementDay.Value,
                DueDayOffset = (int)numDueDayOffset.Value,
                Status = chkActive.Checked ? CardStatus.Active : CardStatus.Locked,
                CreatedAt = DateTime.Now
            };

            if (card.Id == 0)
            {
                _cardService.AddCard(card);
                MessageBox.Show("Đã thêm thẻ mới", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _cardService.UpdateCard(card);
                MessageBox.Show("Đã cập nhật thẻ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            pnlForm.Visible = false;
            LoadCards();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
        }

        private void ClearForm()
        {
            txtCardId.Tag = 0;
            txtBankName.Clear();
            cboCardType.SelectedIndex = 0;
            txtLast4Digits.Clear();
            txtCreditLimit.Clear();
            numStatementDay.Value = 15;
            numDueDayOffset.Value = 15;
            chkActive.Checked = true;
        }

        private void LoadCardToForm(CreditCard card)
        {
            txtCardId.Tag = card.Id;
            txtBankName.Text = card.BankName;
            cboCardType.SelectedItem = card.CardType;
            txtLast4Digits.Text = card.Last4Digits;
            txtCreditLimit.Text = card.CreditLimit.ToString("N0");
            numStatementDay.Value = card.StatementDay;
            numDueDayOffset.Value = card.DueDayOffset;
            chkActive.Checked = card.Status == CardStatus.Active;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtBankName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên ngân hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLast4Digits.Text) || txtLast4Digits.Text.Length != 4)
            {
                MessageBox.Show("Vui lòng nhập đúng 4 số cuối của thẻ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCreditLimit.Text))
            {
                MessageBox.Show("Vui lòng nhập hạn mức", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
