using Microsoft.AspNetCore.Mvc;

namespace Project_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ramo()
        {
            return View();
        }
    }
}
