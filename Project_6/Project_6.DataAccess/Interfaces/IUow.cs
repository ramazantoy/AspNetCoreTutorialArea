using System.Threading.Tasks;
using Project_6.Entities;

namespace Project_6.DataAccess.Interfaces
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChanges();
    }
}