using Microsoft.AspNetCore.Mvc;
using Project_3.Web.Data.Context;
using Project_3.Web.Data.Entities;
using Project_3.Web.Data.Interfaces;
using Project_3.Web.Data.Repositories;
using Project_3.Web.Mapping;

namespace Project_3.Web.Controllers
{
    public class HomeController : Controller
    {
        // private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        private readonly IUow _uow;

        public HomeController(/*IApplicationUserRepository applicationUserRepository, */IUserMapper userMapper, IUow uow)
        {
            // _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToUserListModels(_uow.GetRepository<ApplicationUser>().GetAll()));
        }
    }
}