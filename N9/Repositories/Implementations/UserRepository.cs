using System;
using System.Collections.Generic;
using System.Data.SQLite;
using N9.Data;
using N9.Models;
using N9.Repositories.Interfaces;

namespace N9.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            var dt = DatabaseContext.ExecuteQuery(
                "SELECT * FROM Users WHERE Id = @id",
                new SQLiteParameter("@id", id));
            
            if (dt.Rows.Count == 0) return null;
            return MapUser(dt.Rows[0]);
        }

        public List<User> GetAll()
        {
            var users = new List<User>();
            var dt = DatabaseContext.ExecuteQuery("SELECT * FROM Users");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                users.Add(MapUser(row));
            }
            return users;
        }

        public int Add(User entity)
        {
            return DatabaseContext.ExecuteInsertAndGetId(
                @"INSERT INTO Users (Username, PasswordHash, Salt, Email, ReminderDays, RememberMe, CreatedAt, FailedLoginAttempts)
                  VALUES (@username, @passwordHash, @salt, @email, @reminderDays, @rememberMe, @createdAt, 0)",
                new SQLiteParameter("@username", entity.Username),
                new SQLiteParameter("@passwordHash", entity.PasswordHash),
                new SQLiteParameter("@salt", entity.Salt),
                new SQLiteParameter("@email", entity.Email ?? ""),
                new SQLiteParameter("@reminderDays", entity.ReminderDays),
                new SQLiteParameter("@rememberMe", entity.RememberMe ? 1 : 0),
                new SQLiteParameter("@createdAt", DateTime.Now.ToString("o")));
        }

        public bool Update(User entity)
        {
            DatabaseContext.ExecuteNonQuery(
                @"UPDATE Users SET Username = @username, Email = @email, ReminderDays = @reminderDays, RememberMe = @rememberMe WHERE Id = @id",
                new SQLiteParameter("@username", entity.Username),
                new SQLiteParameter("@email", entity.Email ?? ""),
                new SQLiteParameter("@reminderDays", entity.ReminderDays),
                new SQLiteParameter("@rememberMe", entity.RememberMe ? 1 : 0),
                new SQLiteParameter("@id", entity.Id));
            return true;
        }

        public bool Delete(int id)
        {
            DatabaseContext.ExecuteNonQuery("DELETE FROM Users WHERE Id = @id", new SQLiteParameter("@id", id));
            return true;
        }

        public User GetByUsername(string username)
        {
            var dt = DatabaseContext.ExecuteQuery(
                "SELECT * FROM Users WHERE Username = @username",
                new SQLiteParameter("@username", username));
            
            if (dt.Rows.Count == 0) return null;
            return MapUser(dt.Rows[0]);
        }

        public bool UsernameExists(string username)
        {
            var count = DatabaseContext.ExecuteScalar(
                "SELECT COUNT(*) FROM Users WHERE Username = @username",
                new SQLiteParameter("@username", username));
            return Convert.ToInt32(count) > 0;
        }

        public bool UpdateLoginAttempts(int userId, int attempts, DateTime? lockoutEnd)
        {
            DatabaseContext.ExecuteNonQuery(
                @"UPDATE Users SET FailedLoginAttempts = @attempts, LockoutEnd = @lockoutEnd WHERE Id = @id",
                new SQLiteParameter("@attempts", attempts),
                new SQLiteParameter("@lockoutEnd", lockoutEnd?.ToString("o") ?? (object)DBNull.Value),
                new SQLiteParameter("@id", userId));
            return true;
        }

        public bool UpdateLastLogin(int userId)
        {
            DatabaseContext.ExecuteNonQuery(
                "UPDATE Users SET LastLogin = @lastLogin, FailedLoginAttempts = 0, LockoutEnd = NULL WHERE Id = @id",
                new SQLiteParameter("@lastLogin", DateTime.Now.ToString("o")),
                new SQLiteParameter("@id", userId));
            return true;
        }

        public bool UpdateReminderDays(int userId, int days)
        {
            DatabaseContext.ExecuteNonQuery(
                "UPDATE Users SET ReminderDays = @days WHERE Id = @id",
                new SQLiteParameter("@days", days),
                new SQLiteParameter("@id", userId));
            return true;
        }

        public bool UpdatePassword(int userId, string passwordHash, string salt)
        {
            DatabaseContext.ExecuteNonQuery(
                "UPDATE Users SET PasswordHash = @hash, Salt = @salt WHERE Id = @id",
                new SQLiteParameter("@hash", passwordHash),
                new SQLiteParameter("@salt", salt),
                new SQLiteParameter("@id", userId));
            return true;
        }

        private User MapUser(System.Data.DataRow row)
        {
            return new User
            {
                Id = Convert.ToInt32(row["Id"]),
                Username = row["Username"].ToString(),
                PasswordHash = row["PasswordHash"].ToString(),
                Salt = row["Salt"].ToString(),
                Email = row["Email"]?.ToString(),
                ReminderDays = Convert.ToInt32(row["ReminderDays"]),
                RememberMe = Convert.ToInt32(row["RememberMe"]) == 1,
                CreatedAt = DateTime.Parse(row["CreatedAt"].ToString()),
                LastLogin = row["LastLogin"] != DBNull.Value ? DateTime.Parse(row["LastLogin"].ToString()) : (DateTime?)null,
                FailedLoginAttempts = Convert.ToInt32(row["FailedLoginAttempts"]),
                LockoutEnd = row["LockoutEnd"] != DBNull.Value ? DateTime.Parse(row["LockoutEnd"].ToString()) : (DateTime?)null
            };
        }
    }
}
