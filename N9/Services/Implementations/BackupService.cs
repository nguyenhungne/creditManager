using System;
using System.Data.SQLite;
using System.IO;
using System.Text;
using N9.Data;
using N9.Helpers;
using N9.Models;
using N9.Services.Interfaces;

namespace N9.Services.Implementations
{
    public class BackupService : IBackupService
    {
        public bool BackupData(string filePath, string password, int userId)
        {
            try
            {
                var dbPath = DatabaseContext.GetDatabasePath();
                if (!File.Exists(dbPath)) return false;

                var dbBytes = File.ReadAllBytes(dbPath);
                var encrypted = CryptoHelper.Encrypt(dbBytes, password);
                File.WriteAllBytes(filePath, encrypted);

                // Log backup
                LogBackup(userId, filePath, false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RestoreData(string filePath, string password)
        {
            try
            {
                if (!File.Exists(filePath)) return false;

                var encrypted = File.ReadAllBytes(filePath);
                var decrypted = CryptoHelper.Decrypt(encrypted, password);

                // Verify it's a valid SQLite database
                if (decrypted.Length < 16 || Encoding.ASCII.GetString(decrypted, 0, 16) != "SQLite format 3\0")
                {
                    return false;
                }

                var dbPath = DatabaseContext.GetDatabasePath();
                
                // Backup current database first
                var backupPath = dbPath + ".bak";
                if (File.Exists(dbPath))
                {
                    File.Copy(dbPath, backupPath, true);
                }

                File.WriteAllBytes(dbPath, decrypted);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DateTime? GetLastBackupTime(int userId)
        {
            try
            {
                var result = DatabaseContext.ExecuteScalar(
                    "SELECT BackupTime FROM BackupLogs WHERE UserId = @userId AND IsRestore = 0 ORDER BY BackupTime DESC LIMIT 1",
                    new SQLiteParameter("@userId", userId));
                
                if (result != null && result != DBNull.Value)
                {
                    return DateTime.Parse(result.ToString());
                }
            }
            catch { }
            
            return null;
        }

        private void LogBackup(int userId, string filePath, bool isRestore)
        {
            try
            {
                DatabaseContext.ExecuteNonQuery(
                    "INSERT INTO BackupLogs (UserId, BackupTime, FilePath, IsRestore) VALUES (@userId, @time, @path, @isRestore)",
                    new SQLiteParameter("@userId", userId),
                    new SQLiteParameter("@time", DateTime.Now.ToString("o")),
                    new SQLiteParameter("@path", filePath),
                    new SQLiteParameter("@isRestore", isRestore ? 1 : 0));
            }
            catch { }
        }
    }
}
