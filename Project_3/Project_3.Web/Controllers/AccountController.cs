using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_3.Web.Data.Context;
using Project_3.Web.Data.Entities;
using Project_3.Web.Data.Repositories;
using Project_3.Web.Models;

namespace Project_3.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _bankContext;

        private readonly ApplicationUserRepository _applicationUserRepository;
        
        public AccountController(BankContext bankContext)
        {
            _bankContext = bankContext;
            _applicationUserRepository = new ApplicationUserRepository(_bankContext);
        }

        public IActionResult Create(int id)
        {
            var userInfo = _applicationUserRepository.GetById(id);
            
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