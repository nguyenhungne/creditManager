using System;
using System.Windows.Forms;
using N9.Models;
using N9.Services.Implementations;

namespace N9
{
    public partial class FormTrangChu : Form
    {
        private User _currentUser;
        private NotificationService _notificationService;

        public FormTrangChu()
        {
            InitializeComponent();
        }

        public FormTrangChu(User user) : this()
        {
            _currentUser = user;
            _notificationService = new NotificationService();
            
            // Hiển thị thông tin user
            if (_currentUser != null)
            {
                lblTenUser.Text = _currentUser.Username;
                lblEmail.Text = !string.IsNullOrEmpty(_currentUser.Email) ? _currentUser.Email : "";
            }
        }

        private void LoadUserControl(UserControl uc)
        {
            pnlMainContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            // Load dashboard
            UCDashBoard dashboard = new UCDashBoard(_currentUser);
            LoadUserControl(dashboard);

            // Check for payment reminders
            CheckPaymentReminders();
        }

        private void CheckPaymentReminders()
        {
            if (_currentUser == null || _notificationService == null) return;

            var reminders = _notificationService.GetPendingReminders(_currentUser.Id);
            if (reminders.Count > 0)
            {
                foreach (var reminder in reminders)
                {
                    var message = $"Thẻ {reminder.CardName} sắp đến hạn thanh toán vào ngày {reminder.DueDate:dd/MM/yyyy}.\n" +
                                  $"Số tiền: {reminder.Amount:N0} VNĐ\n" +
                                  $"Còn {reminder.DaysRemaining} ngày";
                    
                    MessageBox.Show(message, "Nhắc nhở thanh toán", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCDashBoard(_currentUser));
        }

        private void btnDanhSachThe_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCDanhSachThe(_currentUser));
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCGiaoDich(_currentUser));
        }

        private void btnSaoKe_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCSaoKe(_currentUser));
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCTraCuu(_currentUser));
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCBaoCao(_currentUser));
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCCaiDat(_currentUser));
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                _currentUser = null;
                var loginForm = new FormDangNhap();
                loginForm.Show();
                this.Close();
            }
        }

        public User CurrentUser => _currentUser;
    }
}
