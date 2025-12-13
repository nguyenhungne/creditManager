using System;
using System.Collections.Generic;
using System.Linq;
using N9.Models;
using N9.Repositories.Implementations;
using N9.Services.Interfaces;

namespace N9.Services.Implementations
{
    public class StatementService : IStatementService
    {
        private readonly StatementRepository _statementRepository;
        private readonly CreditCardRepository _cardRepository;

        public StatementService()
        {
            _statementRepository = new StatementRepository();
            _cardRepository = new CreditCardRepository();
        }

        public List<StatementPeriod> GetStatements(int cardId)
        {
            return _statementRepository.GetByCardId(cardId);
        }

        public List<StatementPeriod> GetAllStatements(int userId)
        {
            var cards = _cardRepository.GetByUserId(userId);
            var statements = new List<StatementPeriod>();
            
            foreach (var card in cards)
            {
                statements.AddRange(_statementRepository.GetByCardId(card.Id));
            }
            
            return statements.OrderByDescending(s => s.DueDate).ToList();
        }

        public List<StatementPeriod> GetPendingStatements(int userId)
        {
            return _statementRepository.GetPendingStatements(userId);
        }

        public StatementPeriod GetCurrentStatement(int cardId)
        {
            return _statementRepository.GetCurrentStatement(cardId);
        }

        public bool ConfirmPayment(int statementId, decimal amount)
        {
            var statement = _statementRepository.GetById(statementId);
            if (statement == null) return false;

            var newPaidAmount = statement.PaidAmount + amount;
            var newStatus = newPaidAmount >= statement.TotalAmount 
                ? StatementStatus.Paid 
                : StatementStatus.Pending;

            return _statementRepository.UpdatePayment(statementId, newPaidAmount, newStatus);
        }

        public decimal CalculateMinimumPayment(int statementId)
        {
            var statement = _statementRepository.GetById(statementId);
            if (statement == null) return 0;
            return statement.MinimumPayment;
        }

        public int GetDaysUntilDue(int statementId)
        {
            var statement = _statementRepository.GetById(statementId);
            if (statement == null) return 0;
            return statement.DaysUntilDue;
        }

        public void UpdateStatementStatus()
        {
            // Update statements that have passed their end date to Pending status
            var allStatements = _statementRepository.GetAll();
            foreach (var stmt in allStatements)
            {
                if (stmt.Status == StatementStatus.NotIssued && stmt.EndDate < DateTime.Today)
                {
                    _statementRepository.UpdatePayment(stmt.Id, stmt.PaidAmount, StatementStatus.Pending);
                }
            }
        }
    }
}
