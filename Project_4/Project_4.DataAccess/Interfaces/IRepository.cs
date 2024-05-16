using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Project_4.Entities.Domains;

namespace Project_4.DataAccess.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetAll();

        Task <T> GetById(int id);

        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);

        Task Create(T entity);

        void Remove(T entity);
        
        void Update(T entity);

        IQueryable<T> GetQuery();

    }
}