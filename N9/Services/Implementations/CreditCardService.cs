using System.Collections.Generic;
using System.Linq;
using N9.Models;
using N9.Repositories.Implementations;
using N9.Services.Interfaces;

namespace N9.Services.Implementations
{
    public class CreditCardService : ICreditCardService
    {
        private readonly CreditCardRepository _cardRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly StatementRepository _statementRepository;

        public CreditCardService()
        {
            _cardRepository = new CreditCardRepository();
            _transactionRepository = new TransactionRepository();
            _statementRepository = new StatementRepository();
        }

        public List<CreditCard> GetAllCards(int userId)
        {
            return _cardRepository.GetByUserId(userId);
        }

        public List<CreditCard> GetActiveCards(int userId)
        {
            return _cardRepository.GetActiveCards(userId);
        }

        public CreditCard GetCardById(int cardId)
        {
            return _cardRepository.GetById(cardId);
        }

        public int AddCard(CreditCard card)
        {
            return _cardRepository.Add(card);
        }

        public bool UpdateCard(CreditCard card)
        {
            return _cardRepository.Update(card);
        }

        public bool DeleteCard(int cardId)
        {
            return _cardRepository.Delete(cardId);
        }

        public bool HasTransactions(int cardId)
        {
            return _transactionRepository.ExistsByCardId(cardId);
        }

        public decimal GetCurrentBalance(int cardId)
        {
            var statements = _statementRepository.GetByCardId(cardId);
            return statements
                .Where(s => s.Status != StatementStatus.Paid)
                .Sum(s => s.OutstandingBalance);
        }
    }
}
