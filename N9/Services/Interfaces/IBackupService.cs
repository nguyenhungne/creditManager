using System;

namespace N9.Services.Interfaces
{
    public interface IBackupService
    {
        bool BackupData(string filePath, string password, int userId);
        bool RestoreData(string filePath, string password);
        DateTime? GetLastBackupTime(int userId);
    }
}
