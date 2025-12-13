using System;
using N9.Helpers;
using N9.Models;
using N9.Repositories.Implementations;
using N9.Services.Interfaces;

namespace N9.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserRepository _userRepository;
        private User _currentUser;
        private const int MaxFailedAttempts = 5;
        private const int LockoutMinutes = 5;

        public AuthenticationService()
        {
            _userRepository = new UserRepository();
        }

        public LoginResult Login(string username, string password)
        {
            var result = new LoginResult();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                result.Message = "Vui lòng nhập tên đăng nhập và mật khẩu";
                return result;
            }

            var user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                result.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
                return result;
            }

            // Check if account is locked
            if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.Now)
            {
                result.IsLocked = true;
                result.RemainingLockSeconds = (int)(user.LockoutEnd.Value - DateTime.Now).TotalSeconds;
                result.Message = $"Tài khoản bị khóa. Vui lòng thử lại sau {result.RemainingLockSeconds / 60} phút {result.RemainingLockSeconds % 60} giây";
                return result;
            }

            // Verify password
            if (!CryptoHelper.VerifyPassword(password, user.Salt, user.PasswordHash))
            {
                // Increment failed attempts
                user.FailedLoginAttempts++;
                
                if (user.FailedLoginAttempts >= MaxFailedAttempts)
                {
                    var lockoutEnd = DateTime.Now.AddMinutes(LockoutMinutes);
                    _userRepository.UpdateLoginAttempts(user.Id, user.FailedLoginAttempts, lockoutEnd);
                    result.IsLocked = true;
                    result.RemainingLockSeconds = LockoutMinutes * 60;
                    result.Message = $"Đăng nhập sai quá {MaxFailedAttempts} lần. Tài khoản bị khóa trong {LockoutMinutes} phút";
                }
                else
                {
                    _userRepository.UpdateLoginAttempts(user.Id, user.FailedLoginAttempts, null);
                    result.Message = $"Tên đăng nhập hoặc mật khẩu không đúng. Còn {MaxFailedAttempts - user.FailedLoginAttempts} lần thử";
                }
                return result;
            }

            // Success - reset failed attempts and update last login
            _userRepository.UpdateLastLogin(user.Id);
            _currentUser = user;
            _currentUser.FailedLoginAttempts = 0;
            _currentUser.LockoutEnd = null;

            result.Success = true;
            result.User = user;
            result.Message = "Đăng nhập thành công";
            return result;
        }

        public bool Register(string username, string password, string email)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            if (_userRepository.UsernameExists(username))
                return false;

            var salt = CryptoHelper.GenerateSalt();
            var hash = CryptoHelper.HashPassword(password, salt);

            var user = new User
            {
                Username = username,
                PasswordHash = hash,
                Salt = salt,
                Email = email,
                ReminderDays = 3,
                CreatedAt = DateTime.Now
            };

            var id = _userRepository.Add(user);
            return id > 0;
        }

        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var user = _userRepository.GetById(userId);
            if (user == null) return false;

            if (!CryptoHelper.VerifyPassword(oldPassword, user.Salt, user.PasswordHash))
                return false;

            var newSalt = CryptoHelper.GenerateSalt();
            var newHash = CryptoHelper.HashPassword(newPassword, newSalt);

            _userRepository.UpdatePassword(userId, newHash, newSalt);
            return true;
        }

        public bool IsAccountLocked(string username)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null) return false;
            return user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.Now;
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        public void Logout()
        {
            _currentUser = null;
        }
    }
}
