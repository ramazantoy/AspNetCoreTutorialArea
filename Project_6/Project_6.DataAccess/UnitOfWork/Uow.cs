using System.Threading.Tasks;
using Project_6.DataAccess.Contexts;
using Project_6.DataAccess.Interfaces;
using Project_6.DataAccess.Repositories;
using Project_6.Entities;

namespace Project_6.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AdvertisementContext _context;

        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}