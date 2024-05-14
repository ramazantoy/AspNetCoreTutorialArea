using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project_4.DataAccess.Interfaces
{
    public interface IRepository<T> where T: class,new()
    {
        Task<List<T>> GetAll();

        Task <T> GetById(int id);

        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);

        Task Create(T entity);

        void Remove(T entity);
        
        void Update(T entity);

    }
}