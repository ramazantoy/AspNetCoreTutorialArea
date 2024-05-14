using System.Threading.Tasks;
using Project_4.DataAccess.Interfaces;

namespace Project_4.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();

        Task SaveChanges();
    }
}