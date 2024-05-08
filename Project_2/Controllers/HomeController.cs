using Microsoft.AspNetCore.Mvc;

namespace Project_2.Controllers
{

    public class HomeController : Controller
    {
       public IActionResult Index(){

        return View();
       }
    }
}