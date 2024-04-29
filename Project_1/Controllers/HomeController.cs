using Microsoft.AspNetCore.Mvc;

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


            return View();
        }
    }
}
