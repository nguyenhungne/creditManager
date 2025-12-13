using System;
using System.Windows.Forms;
using N9.Data;
using N9.Helpers;
using N9.Services.Implementations;

namespace N9
{
    public partial class FormDangNhap : Form
    {
        private readonly AuthenticationService _authService;
        private Timer _lockoutTimer;
        private int _remainingSeconds;
        private const string RememberMeKey = "CreditCardManagerKey2024";

        public FormDangNhap()
        {
            InitializeComponent();
            _authService = new AuthenticationService();
            
            // Initialize database
            DatabaseInitializer.Initialize();
            
            // Setup password field
            txtPass.UseSystemPasswordChar = true;
            
            // Setup events
            btnLogin.Click += BtnLogin_Click;
            lnkDangKy.LinkClicked += LnkDangKy_LinkClicked;
            lnkForgotPass.LinkClicked += LnkForgotPass_LinkClicked;
            txtPass.KeyPress += TxtPass_KeyPress;
            
            // Load remembered credentials
            LoadRememberedCredentials();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var username = txtEmail.Text.Trim();
            var password = txtPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = _authService.Login(username, password);

            if (result.Success)
            {
                // Save credentials if remember me (simplified - just save username)
                SaveRememberedCredentials(username);
                
                // Open main form
                var mainForm = new FormTrangChu(result.User);
                mainForm.Show();
                this.Hide();
                
                mainForm.FormClosed += (s, args) => this.Close();
            }
            else if (result.IsLocked)
            {
                StartLockoutTimer(result.RemainingLockSeconds);
                MessageBox.Show(result.Message, "Tài khoản bị khóa", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(result.Message, "Đăng nhập thất bại", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartLockoutTimer(int seconds)
        {
            _remainingSeconds = seconds;
            btnLogin.Enabled = false;
            
            if (_lockoutTimer == null)
            {
                _lockoutTimer = new Timer();
                _lockoutTimer.Interval = 1000;
                _lockoutTimer.Tick += LockoutTimer_Tick;
            }
            
            UpdateLockoutDisplay();
            _lockoutTimer.Start();
        }

        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            _remainingSeconds--;
            
            if (_remainingSeconds <= 0)
            {
                _lockoutTimer.Stop();
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
            else
            {
                UpdateLockoutDisplay();
            }
        }

        private void UpdateLockoutDisplay()
        {
            int minutes = _remainingSeconds / 60;
            int seconds = _remainingSeconds % 60;
            btnLogin.Text = $"Đợi {minutes:D2}:{seconds:D2}";
        }

        private void LnkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new FormDangKy();
            registerForm.ShowDialog();
        }

        private void LnkForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgotForm = new FormQuenMatKhau();
            forgotForm.ShowDialog();
        }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        private void LoadRememberedCredentials()
        {
            try
            {
                var savedUsername = Properties.Settings.Default.RememberedUsername;
                if (!string.IsNullOrEmpty(savedUsername))
                {
                    txtEmail.Text = CryptoHelper.DecryptString(savedUsername, RememberMeKey);
                }
            }
            catch { }
        }

        private void SaveRememberedCredentials(string username)
        {
            try
            {
                Properties.Settings.Default.RememberedUsername = CryptoHelper.EncryptString(username, RememberMeKey);
                Properties.Settings.Default.Save();
            }
            catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _lockoutTimer?.Stop();
            _lockoutTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
