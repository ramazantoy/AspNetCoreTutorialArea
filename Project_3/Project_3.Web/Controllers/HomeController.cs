using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_3.Web.Data.Context;
using Project_3.Web.Data.Repositories;
using Project_3.Web.Models;

namespace Project_3.Web.Controllers
{
    public class HomeController : Controller
    {
      private readonly BankContext _bankContext;
      private readonly ApplicationUserRepository _applicationUserRepository;

        public HomeController(BankContext bankContext)
        {
            _bankContext = bankContext;
            _applicationUserRepository = new ApplicationUserRepository(_bankContext);
        }

        public IActionResult Index()
        {
            return View(_applicationUserRepository.GetAll());
        }
    }
}