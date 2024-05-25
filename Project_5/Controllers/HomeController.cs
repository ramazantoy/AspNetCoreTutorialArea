using Microsoft.AspNetCore.Mvc;

namespace Project_5.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}