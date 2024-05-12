namespace Project_3.Web.Data.Interfaces
{
    public interface IUow
    {
        IGenericRepository<T> GetRepository<T>() where T : class, new();
        void SaveChanges();
    }
}