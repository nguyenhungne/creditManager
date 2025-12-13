using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using N9.Data;
using N9.Models;
using N9.Repositories.Interfaces;

namespace N9.Repositories.Implementations
{
    public class StatementRepository : IStatementRepository
    {
        public StatementPeriod GetById(int id)
        {
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT s.*, c.BankName, c.CardType, c.Last4Digits 
                  FROM StatementPeriods s 
                  JOIN CreditCards c ON s.CardId = c.Id 
                  WHERE s.Id = @id",
                new SQLiteParameter("@id", id));
            
            if (dt.Rows.Count == 0) return null;
            return MapStatement(dt.Rows[0]);
        }

        public List<StatementPeriod> GetAll()
        {
            var statements = new List<StatementPeriod>();
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT s.*, c.BankName, c.CardType, c.Last4Digits 
                  FROM StatementPeriods s 
                  JOIN CreditCards c ON s.CardId = c.Id 
                  ORDER BY s.DueDate DESC");
            foreach (DataRow row in dt.Rows)
            {
                statements.Add(MapStatement(row));
            }
            return statements;
        }

        public int Add(StatementPeriod entity)
        {
            return DatabaseContext.ExecuteInsertAndGetId(
                @"INSERT INTO StatementPeriods (CardId, StartDate, EndDate, DueDate, TotalAmount, PaidAmount, Status)
                  VALUES (@cardId, @startDate, @endDate, @dueDate, @total, @paid, @status)",
                new SQLiteParameter("@cardId", entity.CardId),
                new SQLiteParameter("@startDate", entity.StartDate.ToString("o")),
                new SQLiteParameter("@endDate", entity.EndDate.ToString("o")),
                new SQLiteParameter("@dueDate", entity.DueDate.ToString("o")),
                new SQLiteParameter("@total", entity.TotalAmount),
                new SQLiteParameter("@paid", entity.PaidAmount),
                new SQLiteParameter("@status", (int)entity.Status));
        }

        public bool Update(StatementPeriod entity)
        {
            DatabaseContext.ExecuteNonQuery(
                @"UPDATE StatementPeriods SET StartDate = @startDate, EndDate = @endDate, DueDate = @dueDate, 
                  TotalAmount = @total, PaidAmount = @paid, Status = @status WHERE Id = @id",
                new SQLiteParameter("@startDate", entity.StartDate.ToString("o")),
                new SQLiteParameter("@endDate", entity.EndDate.ToString("o")),
                new SQLiteParameter("@dueDate", entity.DueDate.ToString("o")),
                new SQLiteParameter("@total", entity.TotalAmount),
                new SQLiteParameter("@paid", entity.PaidAmount),
                new SQLiteParameter("@status", (int)entity.Status),
                new SQLiteParameter("@id", entity.Id));
            return true;
        }

        public bool Delete(int id)
        {
            DatabaseContext.ExecuteNonQuery("DELETE FROM StatementPeriods WHERE Id = @id", new SQLiteParameter("@id", id));
            return true;
        }

        public List<StatementPeriod> GetByCardId(int cardId)
        {
            var statements = new List<StatementPeriod>();
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT s.*, c.BankName, c.CardType, c.Last4Digits 
                  FROM StatementPeriods s 
                  JOIN CreditCards c ON s.CardId = c.Id 
                  WHERE s.CardId = @cardId ORDER BY s.DueDate DESC",
                new SQLiteParameter("@cardId", cardId));
            foreach (DataRow row in dt.Rows)
            {
                statements.Add(MapStatement(row));
            }
            return statements;
        }

        public List<StatementPeriod> GetPendingStatements(int userId)
        {
            var statements = new List<StatementPeriod>();
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT s.*, c.BankName, c.CardType, c.Last4Digits 
                  FROM StatementPeriods s 
                  JOIN CreditCards c ON s.CardId = c.Id 
                  WHERE c.UserId = @userId AND s.Status = @status ORDER BY s.DueDate ASC",
                new SQLiteParameter("@userId", userId),
                new SQLiteParameter("@status", (int)StatementStatus.Pending));
            foreach (DataRow row in dt.Rows)
            {
                statements.Add(MapStatement(row));
            }
            return statements;
        }

        public StatementPeriod GetByCardAndDate(int cardId, DateTime date)
        {
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT s.*, c.BankName, c.CardType, c.Last4Digits 
                  FROM StatementPeriods s 
                  JOIN CreditCards c ON s.CardId = c.Id 
                  WHERE s.CardId = @cardId AND @date BETWEEN s.StartDate AND s.EndDate",
                new SQLiteParameter("@cardId", cardId),
                new SQLiteParameter("@date", date.ToString("o")));
            
            if (dt.Rows.Count == 0) return null;
            return MapStatement(dt.Rows[0]);
        }

        public StatementPeriod GetCurrentStatement(int cardId)
        {
            var dt = DatabaseContext.ExecuteQuery(
                @"SELECT s.*, c.BankName, c.CardType, c.Last4Digits 
                  FROM StatementPeriods s 
                  JOIN CreditCards c ON s.CardId = c.Id 
                  WHERE s.CardId = @cardId AND s.Status IN (0, 1) 
                  ORDER BY s.EndDate DESC LIMIT 1",
                new SQLiteParameter("@cardId", cardId));
            
            if (dt.Rows.Count == 0) return null;
            return MapStatement(dt.Rows[0]);
        }

        public bool UpdatePayment(int statementId, decimal paidAmount, StatementStatus status)
        {
            DatabaseContext.ExecuteNonQuery(
                "UPDATE StatementPeriods SET PaidAmount = @paid, Status = @status WHERE Id = @id",
                new SQLiteParameter("@paid", paidAmount),
                new SQLiteParameter("@status", (int)status),
                new SQLiteParameter("@id", statementId));
            return true;
        }

        public bool UpdateTotalAmount(int statementId, decimal totalAmount)
        {
            DatabaseContext.ExecuteNonQuery(
                "UPDATE StatementPeriods SET TotalAmount = @total WHERE Id = @id",
                new SQLiteParameter("@total", totalAmount),
                new SQLiteParameter("@id", statementId));
            return true;
        }

        private StatementPeriod MapStatement(DataRow row)
        {
            var stmt = new StatementPeriod
            {
                Id = Convert.ToInt32(row["Id"]),
                CardId = Convert.ToInt32(row["CardId"]),
                StartDate = DateTime.Parse(row["StartDate"].ToString()),
                EndDate = DateTime.Parse(row["EndDate"].ToString()),
                DueDate = DateTime.Parse(row["DueDate"].ToString()),
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                PaidAmount = Convert.ToDecimal(row["PaidAmount"]),
                Status = (StatementStatus)Convert.ToInt32(row["Status"])
            };

            if (row.Table.Columns.Contains("BankName"))
            {
                stmt.CardDisplayName = $"{row["BankName"]} {row["CardType"]} *{row["Last4Digits"]}";
            }
            return stmt;
        }
    }
}
