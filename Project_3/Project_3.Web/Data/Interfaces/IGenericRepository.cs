using System.Collections.Generic;

namespace Project_3.Web.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class ,new()
    {
        void Create(T entity);
        void Remove(T entity);
        List<T> GetAll(T entity);
        T GetById(int id);
        void Update(T entity);

    }
}