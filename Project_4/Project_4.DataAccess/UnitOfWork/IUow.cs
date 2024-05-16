using System.Threading.Tasks;
using Project_4.DataAccess.Interfaces;
using Project_4.Entities.Domains;

namespace Project_4.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task SaveChanges();
    }
}