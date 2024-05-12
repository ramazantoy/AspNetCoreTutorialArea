using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_3.Web.Data.Entities;
using Project_3.Web.Data.Interfaces;
using Project_3.Web.Data.Repositories;
using Project_3.Web.Mapping;
using Project_3.Web.Models;

namespace Project_3.Web.Controllers
{
    public class AccountController : Controller
    {

        // private readonly IApplicationUserRepository _applicationUserRepository;
        // private readonly IAccountRepository _accountRepository;
        // private readonly IUserMapper _userMapper;
        // private readonly IAccountMapper _accountMapper;
        //
        // public AccountController(IApplicationUserRepository applicationUserRepository,IAccountRepository accountRepository,IUserMapper userMapper,IAccountMapper accountMapper)
        // {
        //     _applicationUserRepository = applicationUserRepository;
        //     _accountRepository = accountRepository;
        //     _userMapper = userMapper;
        //     _accountMapper = accountMapper;
        // }


        // private readonly IGenericRepository<Account> _accountRepository;
        // private readonly IGenericRepository<ApplicationUser> _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly IUow _uow;

        public AccountController(/*IGenericRepository<Account> accountRepository,
            IGenericRepository<ApplicationUser> userRepository,*/ IUserMapper userMapper, IUow uow)
        {
            // _accountRepository = accountRepository;
            // _userRepository = userRepository;
            _userMapper = userMapper;
            _uow = uow;
        }

        public IActionResult Create(int id)
        {

            return View(_userMapper.MapToUserListModel(_uow.GetRepository<ApplicationUser>().GetById(id)));

        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _uow.GetRepository<Account>().Create(new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                ApplicationUserId = accountCreateModel.ApplicationUserId,
                Balance = accountCreateModel.Balance,
            });
            
            _uow.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int userId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accountList = query.Where(x => x.ApplicationUserId == userId).ToList();
            var user = _uow.GetRepository<ApplicationUser>().GetById(userId);

            ViewBag.FullName = $"{user.Name} {user.Surname}";

            var userAccountModelsList = accountList.Select(account => new AccountListModel
                {
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    ApplicationUserId = account.ApplicationUserId,
                    Id = account.Id,
                })
                .ToList();

            return View(userAccountModelsList);

        }

        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query =  _uow.GetRepository<Account>().GetQueryable();
            var accounts = query.Where(x => x.Id != accountId).ToList();
            ViewBag.SenderAccountId = accountId;

            var canBeSentList = accounts.Select(account => new AccountListModel
                {
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    ApplicationUserId = account.ApplicationUserId,
                    Id = account.Id,
                })
                .ToList();
            return View(new SelectList(canBeSentList,"Id","AccountNumber"));
        }

    [HttpPost]
    public IActionResult SendMoney(SendMoneyModel sendMoneyModel)
    {
      var toSendAccount=  _uow.GetRepository<Account>().GetById(sendMoneyModel.AccountId);
      var senderAccount = _uow.GetRepository<Account>().GetById(sendMoneyModel.SenderAccountId);
      senderAccount.Balance -= sendMoneyModel.Amount;
      
      _uow.GetRepository<Account>().Update(senderAccount);
      toSendAccount.Balance += sendMoneyModel.Amount;
      _uow.GetRepository<Account>().Update(toSendAccount);
      _uow.SaveChanges();
      return RedirectToAction("Index","Home");

    }
    }
}