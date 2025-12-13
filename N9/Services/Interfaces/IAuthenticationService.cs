using N9.Models;

namespace N9.Services.Interfaces
{
    public interface IAuthenticationService
    {
        LoginResult Login(string username, string password);
        bool Register(string username, string password, string email);
        bool ChangePassword(int userId, string oldPassword, string newPassword);
        bool IsAccountLocked(string username);
        User GetCurrentUser();
        void SetCurrentUser(User user);
        void Logout();
    }
}
