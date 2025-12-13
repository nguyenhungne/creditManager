using System.Collections.Generic;
using N9.Models;

namespace N9.Services.Interfaces
{
    public interface INotificationService
    {
        List<PaymentReminder> GetPendingReminders(int userId);
        int GetReminderDays(int userId);
        void SetReminderDays(int userId, int days);
    }
}
