using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_3.Web.Data.Context;

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
            return View(_bankContext.ApplicationUsers.ToList());
        }
    }
}