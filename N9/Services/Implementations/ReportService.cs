using System;
using System.Collections.Generic;
using System.Linq;
using N9.Models;
using N9.Repositories.Implementations;
using N9.Services.Interfaces;

namespace N9.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly CreditCardRepository _cardRepository;
        private readonly StatementRepository _statementRepository;
        private readonly CategoryRepository _categoryRepository;

        public ReportService()
        {
            _transactionRepository = new TransactionRepository();
            _cardRepository = new CreditCardRepository();
            _statementRepository = new StatementRepository();
            _categoryRepository = new CategoryRepository();
        }

        public Dictionary<string, decimal> GetSpendingByCategory(int userId, DateTime from, DateTime to)
        {
            var transactions = _transactionRepository.GetByDateRange(userId, from, to);
            var categories = _categoryRepository.GetAllCategories();
            
            var result = new Dictionary<string, decimal>();
            
            foreach (var cat in categories)
            {
                var total = transactions.Where(t => t.CategoryId == cat.Id).Sum(t => t.Amount);
                if (total > 0)
                {
                    result[cat.Name] = total;
                }
            }
            
            return result;
        }

        public Dictionary<string, decimal> GetMonthlySpending(int userId, int year)
        {
            var from = new DateTime(year, 1, 1);
            var to = new DateTime(year, 12, 31);
            var transactions = _transactionRepository.GetByDateRange(userId, from, to);
            
            var result = new Dictionary<string, decimal>();
            var months = new[] { "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12" };
            
            for (int i = 1; i <= 12; i++)
            {
                var monthTotal = transactions
                    .Where(t => t.TransactionDate.Month == i)
                    .Sum(t => t.Amount);
                result[months[i - 1]] = monthTotal;
            }
            
            return result;
        }

        public Dictionary<string, decimal> GetBalanceByCard(int userId)
        {
            var cards = _cardRepository.GetByUserId(userId);
            var result = new Dictionary<string, decimal>();
            
            foreach (var card in cards)
            {
                var statements = _statementRepository.GetByCardId(card.Id);
                var balance = statements
                    .Where(s => s.Status != StatementStatus.Paid)
                    .Sum(s => s.OutstandingBalance);
                
                if (balance > 0)
                {
                    result[card.DisplayName] = balance;
                }
            }
            
            return result;
        }

        public decimal GetTotalDebt(int userId)
        {
            var cards = _cardRepository.GetByUserId(userId);
            decimal total = 0;
            
            foreach (var card in cards)
            {
                var statements = _statementRepository.GetByCardId(card.Id);
                total += statements
                    .Where(s => s.Status != StatementStatus.Paid)
                    .Sum(s => s.OutstandingBalance);
            }
            
            return total;
        }

        public int GetDueCardsCount(int userId)
        {
            var pendingStatements = _statementRepository.GetPendingStatements(userId);
            return pendingStatements.Count(s => s.DaysUntilDue <= 3);
        }
    }
}
