using Project_3.Web.Data.Entities;
using Project_3.Web.Models;

namespace Project_3.Web.Mapping
{
    public class AccountMapper : IAccountMapper
    {
        public Account Map(AccountCreateModel accountCreateModel)
        {
            return new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                ApplicationUserId = accountCreateModel.ApplicationUserId,
                Balance = accountCreateModel.Balance
            };
        }
    }
}