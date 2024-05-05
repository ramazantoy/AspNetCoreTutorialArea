using Microsoft.AspNetCore.Mvc;

namespace Project_1.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}