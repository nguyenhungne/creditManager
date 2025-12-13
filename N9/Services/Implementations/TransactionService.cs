using System;
using System.Collections.Generic;
using System.Linq;
using N9.Models;
using N9.Repositories.Implementations;
using N9.Services.Interfaces;

namespace N9.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly StatementRepository _statementRepository;
        private readonly CreditCardRepository _cardRepository;

        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
            _statementRepository = new StatementRepository();
            _cardRepository = new CreditCardRepository();
        }

        public List<Transaction> GetTransactions(int userId, TransactionFilter filter)
        {
            return _transactionRepository.Search(userId, filter);
        }

        public Transaction GetById(int transactionId)
        {
            return _transactionRepository.GetById(transactionId);
        }

        public int AddTransaction(Transaction transaction)
        {
            // Auto-assign to statement period
            var statement = GetOrCreateStatementPeriod(transaction.CardId, transaction.TransactionDate);
            if (statement != null)
            {
                transaction.StatementId = statement.Id;
            }

            transaction.CreatedAt = DateTime.Now;
            var id = _transactionRepository.Add(transaction);

            // Update statement total
            if (statement != null)
            {
                UpdateStatementTotal(statement.Id);
            }

            return id;
        }

        public bool UpdateTransaction(Transaction transaction)
        {
            var result = _transactionRepository.Update(transaction);
            
            // Update statement total if assigned
            if (transaction.StatementId.HasValue)
            {
                UpdateStatementTotal(transaction.StatementId.Value);
            }
            
            return result;
        }

        public bool DeleteTransaction(int transactionId)
        {
            var transaction = _transactionRepository.GetById(transactionId);
            var statementId = transaction?.StatementId;
            
            var result = _transactionRepository.Delete(transactionId);
            
            // Update statement total
            if (statementId.HasValue)
            {
                UpdateStatementTotal(statementId.Value);
            }
            
            return result;
        }

        public List<string> GetFrequentMerchants(int userId)
        {
            return _transactionRepository.GetFrequentMerchants(userId);
        }

        public decimal GetTotalAmount(List<Transaction> transactions)
        {
            return transactions.Sum(t => t.Amount);
        }

        private StatementPeriod GetOrCreateStatementPeriod(int cardId, DateTime transactionDate)
        {
            var card = _cardRepository.GetById(cardId);
            if (card == null) return null;

            // Calculate statement period dates
            var statementDay = card.StatementDay;
            var txDate = transactionDate.Date;
            
            DateTime startDate, endDate;
            
            if (txDate.Day <= statementDay)
            {
                // Transaction is in current month's statement
                endDate = new DateTime(txDate.Year, txDate.Month, statementDay);
                startDate = endDate.AddMonths(-1).AddDays(1);
            }
            else
            {
                // Transaction is in next month's statement
                startDate = new DateTime(txDate.Year, txDate.Month, statementDay).AddDays(1);
                endDate = startDate.AddMonths(1).AddDays(-1);
                endDate = new DateTime(endDate.Year, endDate.Month, Math.Min(statementDay, DateTime.DaysInMonth(endDate.Year, endDate.Month)));
            }

            var dueDate = endDate.AddDays(card.DueDayOffset);

            // Check if statement exists
            var existing = _statementRepository.GetByCardAndDate(cardId, txDate);
            if (existing != null) return existing;

            // Create new statement
            var statement = new StatementPeriod
            {
                CardId = cardId,
                StartDate = startDate,
                EndDate = endDate,
                DueDate = dueDate,
                TotalAmount = 0,
                PaidAmount = 0,
                Status = StatementStatus.NotIssued
            };

            statement.Id = _statementRepository.Add(statement);
            return statement;
        }

        private void UpdateStatementTotal(int statementId)
        {
            var transactions = _transactionRepository.GetByStatementId(statementId);
            var total = transactions.Sum(t => t.Amount);
            _statementRepository.UpdateTotalAmount(statementId, total);
        }
    }
}
