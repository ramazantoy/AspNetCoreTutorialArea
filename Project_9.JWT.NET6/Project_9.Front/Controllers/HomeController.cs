using Microsoft.AspNetCore.Mvc;

namespace Project_9.Front.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}