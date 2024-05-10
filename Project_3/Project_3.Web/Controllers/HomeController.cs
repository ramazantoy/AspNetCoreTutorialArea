using Microsoft.AspNetCore.Mvc;

namespace Project_3.Web.Controllers
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