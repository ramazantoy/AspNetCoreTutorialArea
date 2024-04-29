using Microsoft.AspNetCore.Mvc;
using Project_1.Models;

namespace Project_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            /// viewbag,viewdata,tempdata,model 
            /// 
         
            return View();
        }

        public IActionResult Ramo()
        {
            ViewBag.Name = "Ramo";
            ViewData["Name"] = "Ramo2"; //override  for ViewBag

            TempData["Name"] = "RamoTemp";

            Customer customer = new (){ FirstName="Leon",LastName="Brave"};
          
            return View(customer); //only class not string or other variables
        }
    }
}
