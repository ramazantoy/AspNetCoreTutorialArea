using Project_3.Web.Data.Context;
using Project_3.Web.Data.Interfaces;
using Project_3.Web.Data.Repositories;

namespace Project_3.Web.Data.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly BankContext _bankContext;

        public Uow(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(_bankContext);
        }

        public void SaveChanges()
        {
            _bankContext.SaveChanges();
        }
    }


    
}