using System.Collections.Generic;
using Project_3.Web.Data.Entities;

namespace Project_3.Web.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll(); 
        ApplicationUser GetById(int id);
    }
}