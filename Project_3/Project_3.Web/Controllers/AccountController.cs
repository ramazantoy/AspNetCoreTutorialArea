using Microsoft.AspNetCore.Mvc;
using Project_3.Web.Data.Interfaces;
using Project_3.Web.Mapping;
using Project_3.Web.Models;

namespace Project_3.Web.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserMapper _userMapper;
        private readonly IAccountMapper _accountMapper;
        
        public AccountController(IApplicationUserRepository applicationUserRepository,IAccountRepository accountRepository,IUserMapper userMapper,IAccountMapper accountMapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _accountRepository = accountRepository;
            _userMapper = userMapper;
            _accountMapper = accountMapper;
        }

        public IActionResult Create(int id)
        {
            return View(_userMapper.MapToUserListModel(_applicationUserRepository.GetById(id)));
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _accountRepository.Create(_accountMapper.Map(accountCreateModel));
            return RedirectToAction("Index", "Home");
        }

    }
}