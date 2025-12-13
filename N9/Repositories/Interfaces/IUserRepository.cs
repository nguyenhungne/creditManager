using N9.Models;

namespace N9.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
        bool UsernameExists(string username);
        bool UpdateLoginAttempts(int userId, int attempts, System.DateTime? lockoutEnd);
        bool UpdateLastLogin(int userId);
        bool UpdateReminderDays(int userId, int days);
    }
}
