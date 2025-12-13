using System.Collections.Generic;
using N9.Models;

namespace N9.Services.Interfaces
{
    public interface IStatementService
    {
        List<StatementPeriod> GetStatements(int cardId);
        List<StatementPeriod> GetAllStatements(int userId);
        List<StatementPeriod> GetPendingStatements(int userId);
        StatementPeriod GetCurrentStatement(int cardId);
        bool ConfirmPayment(int statementId, decimal amount);
        decimal CalculateMinimumPayment(int statementId);
        int GetDaysUntilDue(int statementId);
    }
}
