using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_4.DataAccess.Contexts;
using Project_4.DataAccess.Interfaces;
using Project_4.Entities.Domains;

namespace Project_4.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TodoContext _todocontext;

        public Repository(TodoContext todocontext)
        {
            _todocontext = todocontext;
        }

        public async Task Create(T entity)
        {
            await _todocontext.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _todocontext.Set<T>().AsNoTracking().ToListAsync();
        }

    
        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _todocontext.Set<T>().SingleOrDefaultAsync(filter) : await _todocontext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetById(int id)
        {
            return await _todocontext.Set<T>().FindAsync(id);
        }


        public void Remove(T entity)
        {
            _todocontext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            var entry = _todocontext.Entry(entity);
            
            if (entry.State != EntityState.Detached) return;
            
            var attachedEntity = _todocontext.Set<T>().Find(entity.Id);
            if (attachedEntity != null)
            {
                _todocontext.Entry(attachedEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                entry.State = EntityState.Modified;
            }
        }

        public IQueryable<T> GetQuery()
        {
            return _todocontext.Set<T>().AsQueryable();
        }
    }
}