using System.Collections.Generic;
using N9.Models;

namespace N9.Services.Interfaces
{
    public interface ICreditCardService
    {
        List<CreditCard> GetAllCards(int userId);
        List<CreditCard> GetActiveCards(int userId);
        CreditCard GetCardById(int cardId);
        int AddCard(CreditCard card);
        bool UpdateCard(CreditCard card);
        bool DeleteCard(int cardId);
        bool HasTransactions(int cardId);
        decimal GetCurrentBalance(int cardId);
    }
}
