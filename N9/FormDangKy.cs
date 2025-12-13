using System;
using System.Windows.Forms;
using N9.Services.Implementations;

namespace N9
{
    public partial class FormDangKy : Form
    {
        private readonly AuthenticationService _authService;

        public FormDangKy()
        {
            InitializeComponent();
            _authService = new AuthenticationService();
            
            // Setup password fields
            txtPassWord.UseSystemPasswordChar = true;
            txtVerifyPassWord.UseSystemPasswordChar = true;
            
            // Setup events
            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var username = txtName.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassWord.Text;
            var confirmPassword = txtVerifyPassWord.Text;

            // Validation
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (username.Length < 3)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 3 ký tự", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Focus();
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVerifyPassWord.Focus();
                return;
            }

            // Register
            var success = _authService.Register(username, password, email);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
        }
    }
}
