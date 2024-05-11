using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_3.Web.Data.Context;
using Project_3.Web.Data.Entities;
using Project_3.Web.Models;

namespace Project_3.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _bankContext;
        
        public AccountController(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _bankContext.ApplicationUsers.Select(x=>new UserListModel{Id = x.Id,Name = x.Name,Surname = x.Surname}).SingleOrDefault(x => x.Id == id);
            
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _bankContext.Accounts.Add(new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                ApplicationUserId = accountCreateModel.ApplicationUserId, 
                Balance = accountCreateModel.Balance
            });

            _bankContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}