using System;
using System.Windows.Forms;
using N9.Models;
using N9.Services.Implementations;

namespace N9
{
    public partial class UCCaiDat : UserControl
    {
        private User _currentUser;
        private AuthenticationService _authService;
        private NotificationService _notificationService;
        private BackupService _backupService;

        public UCCaiDat()
        {
            InitializeComponent();
        }

        public UCCaiDat(User user) : this()
        {
            _currentUser = user;
            _authService = new AuthenticationService();
            _notificationService = new NotificationService();
            _backupService = new BackupService();
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (_currentUser == null) return;
            numReminderDays.Value = _notificationService.GetReminderDays(_currentUser.Id);
            
            var lastBackup = _backupService.GetLastBackupTime(_currentUser.Id);
            lblLastBackup.Text = lastBackup.HasValue 
                ? $"Sao lưu gần nhất: {lastBackup.Value:dd/MM/yyyy HH:mm}" 
                : "Chưa có bản sao lưu";
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var oldPass = txtOldPassword.Text;
            var newPass = txtNewPassword.Text;
            var confirmPass = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var success = _authService.ChangePassword(_currentUser.Id, oldPass, newPass);
            if (success)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveReminder_Click(object sender, EventArgs e)
        {
            _notificationService.SetReminderDays(_currentUser.Id, (int)numReminderDays.Value);
            MessageBox.Show("Đã lưu cài đặt nhắc nhở", "Thành công", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Backup Files (*.bak)|*.bak";
                dialog.DefaultExt = "bak";
                dialog.FileName = $"CreditCardManager_Backup_{DateTime.Now:yyyyMMdd}";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var password = PromptForPassword("Nhập mật khẩu bảo vệ file backup:");
                    if (string.IsNullOrEmpty(password)) return;

                    var success = _backupService.BackupData(dialog.FileName, password, _currentUser.Id);
                    if (success)
                    {
                        MessageBox.Show("Sao lưu dữ liệu thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSettings();
                    }
                    else
                    {
                        MessageBox.Show("Không thể sao lưu dữ liệu", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Phục hồi dữ liệu sẽ ghi đè toàn bộ dữ liệu hiện tại. Bạn có chắc chắn?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Backup Files (*.bak)|*.bak";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var password = PromptForPassword("Nhập mật khẩu file backup:");
                    if (string.IsNullOrEmpty(password)) return;

                    var success = _backupService.RestoreData(dialog.FileName, password);
                    if (success)
                    {
                        MessageBox.Show("Phục hồi dữ liệu thành công! Ứng dụng sẽ khởi động lại.", 
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                    }
                    else
                    {
                        MessageBox.Show("Không thể phục hồi dữ liệu. Mật khẩu có thể không đúng.", 
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string PromptForPassword(string message)
        {
            using (var form = new Form())
            {
                form.Text = "Nhập mật khẩu";
                form.Size = new System.Drawing.Size(350, 150);
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var label = new Label { Text = message, Left = 20, Top = 20, Width = 300 };
                var textBox = new TextBox { Left = 20, Top = 50, Width = 290, UseSystemPasswordChar = true };
                var btnOk = new Button { Text = "OK", Left = 150, Top = 80, Width = 75, DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "Hủy", Left = 235, Top = 80, Width = 75, DialogResult = DialogResult.Cancel };

                form.Controls.AddRange(new Control[] { label, textBox, btnOk, btnCancel });
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }
        }
    }
}
