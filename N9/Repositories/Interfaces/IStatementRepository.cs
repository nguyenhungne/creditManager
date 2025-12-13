using System;
using System.Collections.Generic;
using N9.Models;

namespace N9.Repositories.Interfaces
{
    public interface IStatementRepository : IRepository<StatementPeriod>
    {
        List<StatementPeriod> GetByCardId(int cardId);
        List<StatementPeriod> GetPendingStatements(int userId);
        StatementPeriod GetByCardAndDate(int cardId, DateTime date);
        StatementPeriod GetCurrentStatement(int cardId);
        bool UpdatePayment(int statementId, decimal paidAmount, StatementStatus status);
        bool UpdateTotalAmount(int statementId, decimal totalAmount);
    }
}
