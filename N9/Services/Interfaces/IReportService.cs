using System;
using System.Collections.Generic;

namespace N9.Services.Interfaces
{
    public interface IReportService
    {
        Dictionary<string, decimal> GetSpendingByCategory(int userId, DateTime from, DateTime to);
        Dictionary<string, decimal> GetMonthlySpending(int userId, int year);
        Dictionary<string, decimal> GetBalanceByCard(int userId);
        decimal GetTotalDebt(int userId);
        int GetDueCardsCount(int userId);
    }
}
