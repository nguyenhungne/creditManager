using System;
using System.Collections.Generic;
using System.Data.SQLite;
using N9.Data;
using N9.Models;
using N9.Repositories.Interfaces;

namespace N9.Repositories.Implementations
{
    public class CreditCardRepository : ICreditCardRepository
    {
        public CreditCard GetById(int id)
        {
            var dt = DatabaseContext.ExecuteQuery(
                "SELECT * FROM CreditCards WHERE Id = @id",
                new SQLiteParameter("@id", id));
            
            if (dt.Rows.Count == 0) return null;
            return MapCard(dt.Rows[0]);
        }

        public List<CreditCard> GetAll()
        {
            var cards = new List<CreditCard>();
            var dt = DatabaseContext.ExecuteQuery("SELECT * FROM CreditCards");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                cards.Add(MapCard(row));
            }
            return cards;
        }

        public int Add(CreditCard entity)
        {
            return DatabaseContext.ExecuteInsertAndGetId(
                @"INSERT INTO CreditCards (UserId, BankName, CardType, Last4Digits, CreditLimit, StatementDay, DueDayOffset, Status, CreatedAt)
                  VALUES (@userId, @bankName, @cardType, @last4, @limit, @stmtDay, @dueOffset, @status, @createdAt)",
                new SQLiteParameter("@userId", entity.UserId),
                new SQLiteParameter("@bankName", entity.BankName),
                new SQLiteParameter("@cardType", entity.CardType),
                new SQLiteParameter("@last4", entity.Last4Digits),
                new SQLiteParameter("@limit", entity.CreditLimit),
                new SQLiteParameter("@stmtDay", entity.StatementDay),
                new SQLiteParameter("@dueOffset", entity.DueDayOffset),
                new SQLiteParameter("@status", (int)entity.Status),
                new SQLiteParameter("@createdAt", DateTime.Now.ToString("o")));
        }

        public bool Update(CreditCard entity)
        {
            DatabaseContext.ExecuteNonQuery(
                @"UPDATE CreditCards SET BankName = @bankName, CardType = @cardType, Last4Digits = @last4, 
                  CreditLimit = @limit, StatementDay = @stmtDay, DueDayOffset = @dueOffset, Status = @status WHERE Id = @id",
                new SQLiteParameter("@bankName", entity.BankName),
                new SQLiteParameter("@cardType", entity.CardType),
                new SQLiteParameter("@last4", entity.Last4Digits),
                new SQLiteParameter("@limit", entity.CreditLimit),
                new SQLiteParameter("@stmtDay", entity.StatementDay),
                new SQLiteParameter("@dueOffset", entity.DueDayOffset),
                new SQLiteParameter("@status", (int)entity.Status),
                new SQLiteParameter("@id", entity.Id));
            return true;
        }

        public bool Delete(int id)
        {
            DatabaseContext.ExecuteNonQuery("DELETE FROM CreditCards WHERE Id = @id", new SQLiteParameter("@id", id));
            return true;
        }

        public List<CreditCard> GetByUserId(int userId)
        {
            var cards = new List<CreditCard>();
            var dt = DatabaseContext.ExecuteQuery(
                "SELECT * FROM CreditCards WHERE UserId = @userId ORDER BY BankName, CardType",
                new SQLiteParameter("@userId", userId));
            foreach (System.Data.DataRow row in dt.Rows)
            {
                cards.Add(MapCard(row));
            }
            return cards;
        }

        public List<CreditCard> GetActiveCards(int userId)
        {
            var cards = new List<CreditCard>();
            var dt = DatabaseContext.ExecuteQuery(
                "SELECT * FROM CreditCards WHERE UserId = @userId AND Status = 0 ORDER BY BankName, CardType",
                new SQLiteParameter("@userId", userId));
            foreach (System.Data.DataRow row in dt.Rows)
            {
                cards.Add(MapCard(row));
            }
            return cards;
        }

        private CreditCard MapCard(System.Data.DataRow row)
        {
            return new CreditCard
            {
                Id = Convert.ToInt32(row["Id"]),
                UserId = Convert.ToInt32(row["UserId"]),
                BankName = row["BankName"].ToString(),
                CardType = row["CardType"].ToString(),
                Last4Digits = row["Last4Digits"].ToString(),
                CreditLimit = Convert.ToDecimal(row["CreditLimit"]),
                StatementDay = Convert.ToInt32(row["StatementDay"]),
                DueDayOffset = Convert.ToInt32(row["DueDayOffset"]),
                Status = (CardStatus)Convert.ToInt32(row["Status"]),
                CreatedAt = DateTime.Parse(row["CreatedAt"].ToString())
            };
        }
    }
}
