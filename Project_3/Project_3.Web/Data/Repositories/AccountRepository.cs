using System.Linq;
using Project_3.Web.Data.Context;
using Project_3.Web.Data.Entities;
using Project_3.Web.Data.Interfaces;

namespace Project_3.Web.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _bankContext;

        public AccountRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public void Create(Account account)
        {
            _bankContext.Accounts.Add(account);
            _bankContext.SaveChanges();
        }
    }
}