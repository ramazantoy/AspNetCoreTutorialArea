using Microsoft.AspNetCore.Mvc;

namespace Project_7.MVC.Controllers
{
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }
    }
}