using System.Collections.Generic;
using N9.Models;

namespace N9.Services.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions(int userId, TransactionFilter filter);
        Transaction GetById(int transactionId);
        int AddTransaction(Transaction transaction);
        bool UpdateTransaction(Transaction transaction);
        bool DeleteTransaction(int transactionId);
        List<string> GetFrequentMerchants(int userId);
        decimal GetTotalAmount(List<Transaction> transactions);
    }
}
