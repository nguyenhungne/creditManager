using System;
using System.Collections.Generic;
using System.Linq;
using N9.Models;
using N9.Repositories.Implementations;
using N9.Services.Interfaces;

namespace N9.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly StatementRepository _statementRepository;
        private readonly UserRepository _userRepository;
        private readonly CreditCardRepository _cardRepository;

        public NotificationService()
        {
            _statementRepository = new StatementRepository();
            _userRepository = new UserRepository();
            _cardRepository = new CreditCardRepository();
        }

        public List<PaymentReminder> GetPendingReminders(int userId)
        {
            var reminders = new List<PaymentReminder>();
            var user = _userRepository.GetById(userId);
            if (user == null) return reminders;

            var reminderDays = user.ReminderDays;
            var pendingStatements = _statementRepository.GetPendingStatements(userId);

            foreach (var stmt in pendingStatements)
            {
                if (stmt.DaysUntilDue <= reminderDays && stmt.OutstandingBalance > 0)
                {
                    var card = _cardRepository.GetById(stmt.CardId);
                    reminders.Add(new PaymentReminder
                    {
                        CardId = stmt.CardId,
                        CardName = card?.DisplayName ?? stmt.CardDisplayName,
                        DueDate = stmt.DueDate,
                        Amount = stmt.OutstandingBalance,
                        DaysRemaining = stmt.DaysUntilDue
                    });
                }
            }

            return reminders.OrderBy(r => r.DaysRemaining).ToList();
        }

        public int GetReminderDays(int userId)
        {
            var user = _userRepository.GetById(userId);
            return user?.ReminderDays ?? 3;
        }

        public void SetReminderDays(int userId, int days)
        {
            _userRepository.UpdateReminderDays(userId, days);
        }
    }
}
