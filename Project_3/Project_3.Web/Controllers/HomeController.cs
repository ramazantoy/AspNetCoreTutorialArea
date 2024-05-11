using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_3.Web.Data.Context;
using Project_3.Web.Models;

namespace Project_3.Web.Controllers
{
    public class HomeController : Controller
    {
      private readonly BankContext _bankContext;

        public HomeController(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public IActionResult Index()
        {
            return View(_bankContext.ApplicationUsers.Select(x=>new UserListModel{Id = x.Id,Name = x.Name,Surname= x.Surname}).ToList());
        }
    }
}