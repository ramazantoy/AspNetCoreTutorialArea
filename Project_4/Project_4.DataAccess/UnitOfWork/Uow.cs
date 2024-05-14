using System.Threading.Tasks;
using Project_4.DataAccess.Contexts;
using Project_4.DataAccess.Interfaces;
using Project_4.DataAccess.Repositories;

namespace Project_4.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {

        private readonly TodoContext _todoContext;

        public Uow(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {

            return new Repository<T>(_todoContext);
        }

        public  async Task SaveChanges()
        {
            await _todoContext.SaveChangesAsync();
        }
    }
}