using System.Collections.Generic;

namespace N9.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        int Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
