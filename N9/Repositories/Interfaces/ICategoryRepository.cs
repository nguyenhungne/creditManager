using System.Collections.Generic;
using N9.Models;

namespace N9.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetAllCategories();
    }
}
