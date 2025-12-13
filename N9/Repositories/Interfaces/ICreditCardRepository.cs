using System.Collections.Generic;
using N9.Models;

namespace N9.Repositories.Interfaces
{
    public interface ICreditCardRepository : IRepository<CreditCard>
    {
        List<CreditCard> GetByUserId(int userId);
        List<CreditCard> GetActiveCards(int userId);
    }
}
