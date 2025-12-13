using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using N9.Data;
using N9.Models;
using N9.Repositories.Interfaces;

namespace N9.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        public Transaction GetById(int id)
        {
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT t.*, c.BankName, c.CardType, c.Last4Digits, cat.Name as CategoryName 
                  FROM Transactions t 
                  JOIN CreditCards c ON t.CardId = c.Id 
                  JOIN Categories cat ON t.CategoryId = cat.Id 
                  WHERE t.Id = @id",
                new SQLiteParameter("@id", id));
            
            if (dt.Rows.Count == 0) return null;
            return MapTransaction(dt.Rows[0]);
        }

        public List<Transaction> GetAll()
        {
            var transactions = new List<Transaction>();
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT t.*, c.BankName, c.CardType, c.Last4Digits, cat.Name as CategoryName 
                  FROM Transactions t 
                  JOIN CreditCards c ON t.CardId = c.Id 
                  JOIN Categories cat ON t.CategoryId = cat.Id 
                  ORDER BY t.TransactionDate DESC");
            foreach (DataRow row in dt.Rows)
            {
                transactions.Add(MapTransaction(row));
            }
            return transactions;
        }

        public int Add(Transaction entity)
        {
            return DatabaseContext.ExecuteInsertAndGetId(
                @"INSERT INTO Transactions (CardId, StatementId, TransactionDate, MerchantName, Amount, CategoryId, IsInstallment, InstallmentMonths, InstallmentRate, CreatedAt)
                  VALUES (@cardId, @stmtId, @txDate, @merchant, @amount, @catId, @isInstall, @months, @rate, @createdAt)",
                new SQLiteParameter("@cardId", entity.CardId),
                new SQLiteParameter("@stmtId", entity.StatementId ?? (object)DBNull.Value),
                new SQLiteParameter("@txDate", entity.TransactionDate.ToString("o")),
                new SQLiteParameter("@merchant", entity.MerchantName),
                new SQLiteParameter("@amount", entity.Amount),
                new SQLiteParameter("@catId", entity.CategoryId),
                new SQLiteParameter("@isInstall", entity.IsInstallment ? 1 : 0),
                new SQLiteParameter("@months", entity.InstallmentMonths ?? (object)DBNull.Value),
                new SQLiteParameter("@rate", entity.InstallmentRate ?? (object)DBNull.Value),
                new SQLiteParameter("@createdAt", DateTime.Now.ToString("o")));
        }

        public bool Update(Transaction entity)
        {
            DatabaseContext.ExecuteNonQuery(
                @"UPDATE Transactions SET CardId = @cardId, StatementId = @stmtId, TransactionDate = @txDate, 
                  MerchantName = @merchant, Amount = @amount, CategoryId = @catId, IsInstallment = @isInstall, 
                  InstallmentMonths = @months, InstallmentRate = @rate WHERE Id = @id",
                new SQLiteParameter("@cardId", entity.CardId),
                new SQLiteParameter("@stmtId", entity.StatementId ?? (object)DBNull.Value),
                new SQLiteParameter("@txDate", entity.TransactionDate.ToString("o")),
                new SQLiteParameter("@merchant", entity.MerchantName),
                new SQLiteParameter("@amount", entity.Amount),
                new SQLiteParameter("@catId", entity.CategoryId),
                new SQLiteParameter("@isInstall", entity.IsInstallment ? 1 : 0),
                new SQLiteParameter("@months", entity.InstallmentMonths ?? (object)DBNull.Value),
                new SQLiteParameter("@rate", entity.InstallmentRate ?? (object)DBNull.Value),
                new SQLiteParameter("@id", entity.Id));
            return true;
        }

        public bool Delete(int id)
        {
            DatabaseContext.ExecuteNonQuery("DELETE FROM Transactions WHERE Id = @id", new SQLiteParameter("@id", id));
            return true;
        }

        public List<Transaction> GetByCardId(int cardId)
        {
            var transactions = new List<Transaction>();
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT t.*, c.BankName, c.CardType, c.Last4Digits, cat.Name as CategoryName 
                  FROM Transactions t 
                  JOIN CreditCards c ON t.CardId = c.Id 
                  JOIN Categories cat ON t.CategoryId = cat.Id 
                  WHERE t.CardId = @cardId ORDER BY t.TransactionDate DESC",
                new SQLiteParameter("@cardId", cardId));
            foreach (DataRow row in dt.Rows)
            {
                transactions.Add(MapTransaction(row));
            }
            return transactions;
        }

        public List<Transaction> GetByStatementId(int statementId)
        {
            var transactions = new List<Transaction>();
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT t.*, c.BankName, c.CardType, c.Last4Digits, cat.Name as CategoryName 
                  FROM Transactions t 
                  JOIN CreditCards c ON t.CardId = c.Id 
                  JOIN Categories cat ON t.CategoryId = cat.Id 
                  WHERE t.StatementId = @stmtId ORDER BY t.TransactionDate DESC",
                new SQLiteParameter("@stmtId", statementId));
            foreach (DataRow row in dt.Rows)
            {
                transactions.Add(MapTransaction(row));
            }
            return transactions;
        }

        public List<Transaction> GetByDateRange(int userId, DateTime from, DateTime to)
        {
            var transactions = new List<Transaction>();
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT t.*, c.BankName, c.CardType, c.Last4Digits, cat.Name as CategoryName 
                  FROM Transactions t 
                  JOIN CreditCards c ON t.CardId = c.Id 
                  JOIN Categories cat ON t.CategoryId = cat.Id 
                  WHERE c.UserId = @userId AND t.TransactionDate BETWEEN @from AND @to 
                  ORDER BY t.TransactionDate DESC",
                new SQLiteParameter("@userId", userId),
                new SQLiteParameter("@from", from.ToString("o")),
                new SQLiteParameter("@to", to.ToString("o")));
            foreach (DataRow row in dt.Rows)
            {
                transactions.Add(MapTransaction(row));
            }
            return transactions;
        }

        public List<Transaction> Search(int userId, TransactionFilter filter)
        {
            var transactions = new List<Transaction>();
            var sql = new StringBuilder(
                @"SELECT t.*, c.BankName, c.CardType, c.Last4Digits, cat.Name as CategoryName 
                  FROM Transactions t 
                  JOIN CreditCards c ON t.CardId = c.Id 
                  JOIN Categories cat ON t.CategoryId = cat.Id 
                  WHERE c.UserId = @userId");
            var parameters = new List<SQLiteParameter> { new SQLiteParameter("@userId", userId) };

            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                sql.Append(" AND t.MerchantName LIKE @keyword");
                parameters.Add(new SQLiteParameter("@keyword", $"%{filter.Keyword}%"));
            }
            if (filter.FromDate.HasValue)
            {
                sql.Append(" AND t.TransactionDate >= @from");
                parameters.Add(new SQLiteParameter("@from", filter.FromDate.Value.ToString("o")));
            }
            if (filter.ToDate.HasValue)
            {
                sql.Append(" AND t.TransactionDate <= @to");
                parameters.Add(new SQLiteParameter("@to", filter.ToDate.Value.ToString("o")));
            }
            if (filter.CardId.HasValue)
            {
                sql.Append(" AND t.CardId = @cardId");
                parameters.Add(new SQLiteParameter("@cardId", filter.CardId.Value));
            }
            if (filter.CategoryId.HasValue)
            {
                sql.Append(" AND t.CategoryId = @catId");
                parameters.Add(new SQLiteParameter("@catId", filter.CategoryId.Value));
            }
            if (filter.MinAmount.HasValue)
            {
                sql.Append(" AND t.Amount >= @minAmt");
                parameters.Add(new SQLiteParameter("@minAmt", filter.MinAmount.Value));
            }
            if (filter.MaxAmount.HasValue)
            {
                sql.Append(" AND t.Amount <= @maxAmt");
                parameters.Add(new SQLiteParameter("@maxAmt", filter.MaxAmount.Value));
            }

            sql.Append(" ORDER BY t.TransactionDate DESC");

            var dt = DatabaseContext.ExecuteQuery(sql.ToString(), parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                transactions.Add(MapTransaction(row));
            }
            return transactions;
        }

        public List<string> GetFrequentMerchants(int userId, int limit = 10)
        {
            var merchants = new List<string>();
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT t.MerchantName, COUNT(*) as cnt FROM Transactions t 
                  JOIN CreditCards c ON t.CardId = c.Id 
                  WHERE c.UserId = @userId 
                  GROUP BY t.MerchantName ORDER BY cnt DESC LIMIT @limit",
                new SQLiteParameter("@userId", userId),
                new SQLiteParameter("@limit", limit));
            foreach (DataRow row in dt.Rows)
            {
                merchants.Add(row["MerchantName"].ToString());
            }
            return merchants;
        }

        public bool ExistsByCardId(int cardId)
        {
            var count = DatabaseContext.ExecuteScalar(
                "SELECT COUNT(*) FROM Transactions WHERE CardId = @cardId",
                new SQLiteParameter("@cardId", cardId));
            return Convert.ToInt32(count) > 0;
        }

        private Transaction MapTransaction(DataRow row)
        {
            var tx = new Transaction
            {
                Id = Convert.ToInt32(row["Id"]),
                CardId = Convert.ToInt32(row["CardId"]),
                StatementId = row["StatementId"] != DBNull.Value ? Convert.ToInt32(row["StatementId"]) : (int?)null,
                TransactionDate = DateTime.Parse(row["TransactionDate"].ToString()),
                MerchantName = row["MerchantName"].ToString(),
                Amount = Convert.ToDecimal(row["Amount"]),
                CategoryId = Convert.ToInt32(row["CategoryId"]),
                IsInstallment = Convert.ToInt32(row["IsInstallment"]) == 1,
                InstallmentMonths = row["InstallmentMonths"] != DBNull.Value ? Convert.ToInt32(row["InstallmentMonths"]) : (int?)null,
                InstallmentRate = row["InstallmentRate"] != DBNull.Value ? Convert.ToDecimal(row["InstallmentRate"]) : (decimal?)null,
                CreatedAt = DateTime.Parse(row["CreatedAt"].ToString())
            };

            if (row.Table.Columns.Contains("BankName"))
            {
                tx.CardDisplayName = $"{row["BankName"]} {row["CardType"]} *{row["Last4Digits"]}";
            }
            if (row.Table.Columns.Contains("CategoryName"))
            {
                tx.CategoryName = row["CategoryName"].ToString();
            }
            return tx;
        }
    }
}
