using System.Linq;
using Microsoft.AspNetCore.Mvc;
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


        private readonly IGenericRepository<Account> _accountRepository;
        private readonly IGenericRepository<ApplicationUser> _userRepository;
        private readonly IUserMapper _userMapper;
        public AccountController(IGenericRepository<Account> accountRepository,IGenericRepository<ApplicationUser> userRepository, IUserMapper userMapper)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _userMapper = userMapper;
        }
        
        public IActionResult Create(int id)
        {

            return View(_userMapper.MapToUserListModel(_userRepository.GetById(id)));

        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _accountRepository.Create(new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                ApplicationUserId = accountCreateModel.ApplicationUserId,
                Balance = accountCreateModel.Balance,
            });
            return RedirectToAction("Index", "Home");
        }

    }
}