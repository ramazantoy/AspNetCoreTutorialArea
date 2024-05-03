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
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            // var name = HttpContext.Request.Form["firstName"].ToString();
            // var lastName = HttpContext.Request.Form["lastName"].ToString();
            //
            // Customer lastCustomer = null;
            customer.Id = 1;
            if (CustomerContext.Customers.Count > 0)
            {
                // lastCustomer = CustomerContext.Customers.Last();
                customer.Id = CustomerContext.Customers.Last().Id+1;
            }
            // CustomerContext.Customers.Add(new Customer { Id = id, FirstName = name, LastName = lastName });
            CustomerContext.Customers.Add(customer);
            return RedirectToAction("CustomerTest");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            // var routeData = int.Parse(RouteData.Values["id"].ToString()); //look for endpoint data

            // var removedCustomer = CustomerContext.Customers.Find(customer => customer.Id == routeData);
            var removedCustomer = CustomerContext.Customers.Find(customer => customer.Id == id);

            CustomerContext.Customers.Remove(removedCustomer);
            return RedirectToAction("CustomerTest");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            // var customerId = int.Parse(RouteData.Values["id"].ToString());
            // var updateCustomer = CustomerContext.Customers.FirstOrDefault(customer => customer.Id == customerId);
            var updateCustomer = CustomerContext.Customers.FirstOrDefault(customer => customer.Id ==id);
            return View(updateCustomer);
        }

        [HttpPost]
        public IActionResult Update(Customer updatedCustomer)
        {
            // var customerId = Int32.Parse(HttpContext.Request.Form["id"].ToString());
            // var name = HttpContext.Request.Form["firstName"].ToString();
            // var lastName = HttpContext.Request.Form["lastName"].ToString();
            // var updateCustomer = CustomerContext.Customers.FirstOrDefault(customer => customer.Id == customerId);
            var updateCustomer = CustomerContext.Customers.FirstOrDefault(customer => customer.Id == updatedCustomer.Id);
            
            // updateCustomer.FirstName = name;
            // updateCustomer.LastName = lastName;
            
            updateCustomer.FirstName = updatedCustomer.FirstName;
            updateCustomer.LastName = updatedCustomer.LastName;
            
            return RedirectToAction("CustomerTest");
        }
      
    }
}