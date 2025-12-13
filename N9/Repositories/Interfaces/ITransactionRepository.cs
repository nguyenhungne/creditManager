using System;
using System.Collections.Generic;
using N9.Models;

namespace N9.Repositories.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        List<Transaction> GetByCardId(int cardId);
        List<Transaction> GetByStatementId(int statementId);
        List<Transaction> GetByDateRange(int userId, DateTime from, DateTime to);
        List<Transaction> Search(int userId, TransactionFilter filter);
        List<string> GetFrequentMerchants(int userId, int limit = 10);
        bool ExistsByCardId(int cardId);
    }
}
