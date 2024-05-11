using System.Collections.Generic;
using System.Linq;
using Project_3.Web.Data.Context;
using Project_3.Web.Data.Entities;

namespace Project_3.Web.Data.Repositories
{
    public class ApplicationUserRepository
    {
        private readonly BankContext _bankContext;

        public ApplicationUserRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public List<ApplicationUser> GetAll()
        {
            return _bankContext.ApplicationUsers.ToList();
        }

        public ApplicationUser GetById(int id)
        {
            return _bankContext.ApplicationUsers.SingleOrDefault(x => x.Id == id);
        }
    }
}