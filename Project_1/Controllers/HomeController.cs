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

            // return View("Index",customer) for open other views and with customer.
            // return RedirectToAction("Index", customer); not open directly calls  Index func. first

            //  return RedirectToAction("Index", new { @id=1}); for parameter calls.  overload calls.

            // return RedirectToAction("Index", "Product"); jump for other controllers actionrestult

            //return RedirectToAction("Index", "Product", new {@id=5}); with parameter

            return View(customer); //only class not string or other variables
        }
    }
}
