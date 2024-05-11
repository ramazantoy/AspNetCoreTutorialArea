using Project_3.Web.Data.Entities;

namespace Project_3.Web.Data.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account account);
    }
}