using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_1.Models;

namespace Project_1.Controllers
{
    // [Route("[Controller]/[action]")] //removed start up settings
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //viewbag,viewdata,tempdata,model 

            return View();
        }

        // [Route("Ramo")] //override from startup and its can add for controller
        public IActionResult Ramo()
        {
            // var values = RouteData.Values; // for handle all route values
            // ViewBag.Name = "Ramo";
            // ViewData["Name"] = "Ramo2"; //override  for ViewBag
            //
            // TempData["Name"] = "RamoTemp";
            //
            // Customer customer = new (){ FirstName="Leon",LastName="Brave"};

            // return View("Index",customer) for open other views and with customer.
            // return RedirectToAction("Index", customer); not open directly calls  Index func. first

            //  return RedirectToAction("Index", new { @id=1}); for parameter calls.  overload calls.

            // return RedirectToAction("Index", "Product"); jump for other controllers actionrestult

            //return RedirectToAction("Index", "Product", new {@id=5}); with parameter

            // return View(customer); //only class not string or other variables

            var customers = CustomerContext.Customers;
            return View(customers);
        }

        public IActionResult CustomerTest()
        {
            var customers = CustomerContext.Customers;
            return View(customers);
        }

        public IActionResult HandleUnknownRoutes()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWithForm()
        {
            var name = HttpContext.Request.Form["firstName"].ToString();
            var lastName = HttpContext.Request.Form["lastName"].ToString();

            Customer lastCustomer = null;

            if (CustomerContext.Customers.Count > 0)
            {
                lastCustomer = CustomerContext.Customers.Last();
            }

            var id = 1;

            if (lastCustomer != null)
            {
                id = lastCustomer.Id + 1;
            }

            CustomerContext.Customers.Add(new Customer { Id = id, FirstName = name, LastName = lastName });
            return RedirectToAction("CustomerTest");
        }

        [HttpGet]
        public IActionResult Remove()
        {
            var routeData = int.Parse(RouteData.Values["id"].ToString()); //look for endpoint data

            var removedCustomer = CustomerContext.Customers.Find(customer => customer.Id == routeData);

            CustomerContext.Customers.Remove(removedCustomer);
            return RedirectToAction("CustomerTest");
        }


        [HttpGet]
        public IActionResult Update()
        {
            var customerId = int.Parse(RouteData.Values["id"].ToString());
            var updateCustomer = CustomerContext.Customers.FirstOrDefault(customer => customer.Id == customerId);
            return View(updateCustomer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer()
        {
            var customerId = Int32.Parse(HttpContext.Request.Form["id"].ToString());
            var name = HttpContext.Request.Form["firstName"].ToString();
            var lastName = HttpContext.Request.Form["lastName"].ToString();
            var updateCustomer = CustomerContext.Customers.FirstOrDefault(customer => customer.Id == customerId);

            updateCustomer.FirstName = name;
            updateCustomer.LastName = lastName;
            
            return RedirectToAction("CustomerTest");
        }
      
    }
}