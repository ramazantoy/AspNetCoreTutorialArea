using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_6.Common.Enums;
using Project_6.DataAccess.Contexts;
using Project_6.DataAccess.Interfaces;
using Project_6.Entities;

namespace Project_6.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T:BaseEntity
    {
        private readonly AdvertisementContext _context;

        public Repository(AdvertisementContext context)
        {
            _context = context;
        }
        
        //get all
        //order by
        //get all by filter
        //asnotracking()
       public async Task<List<T>> GetAllAsync()
       {
           return await _context.Set<T>().ToListAsync();
       }
       
       public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter)
       {
           return await _context.Set<T>().Where(filter).ToListAsync();
       }
       
       public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T,TKey>> selector, OrderByType orderByType=OrderByType.DESC)
       {
           return orderByType==OrderByType.ASC ?  await _context.Set<T>().OrderBy(selector).ToListAsync() : await _context.Set<T>().OrderByDescending(selector).ToListAsync();
       }
    }
}