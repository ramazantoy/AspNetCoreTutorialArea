using Project_3.Web.Data.Entities;
using Project_3.Web.Models;

namespace Project_3.Web.Mapping
{
    public interface IAccountMapper
    {
        Account Map(AccountCreateModel accountCreateModel);
    }
}