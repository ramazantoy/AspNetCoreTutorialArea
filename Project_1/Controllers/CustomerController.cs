using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_1.Models;

namespace Project_1.Controllers
{
    public class CustomerController : Controller
    {
    
        public IActionResult List()
        {
            var customers = CustomerContext.Customers;
            return View(customers);
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

            // var check = ModelState.IsValid;//for correct check
            // var errors = ModelState.Values.SelectMany(I => I.Errors.Select(modelError=>modelError.ErrorMessage));

            // if (customer.FirstName == "Leon")
            // {
            //     ModelState.AddModelError("","first name is cant be leon");
            // }
            if (!ModelState.IsValid)
            {
                return View();
            }
            customer.Id = 1;
            if (CustomerContext.Customers.Count > 0)
            {
                // lastCustomer = CustomerContext.Customers.Last();
                customer.Id = CustomerContext.Customers.Last().Id+1;
            }
            // CustomerContext.Customers.Add(new Customer { Id = id, FirstName = name, LastName = lastName });
            CustomerContext.Customers.Add(customer);
            return RedirectToAction("List");
         
        }
        
        
        [HttpGet]
        public IActionResult Remove(int id)
        {
            // var routeData = int.Parse(RouteData.Values["id"].ToString()); //look for endpoint data

            // var removedCustomer = CustomerContext.Customers.Find(customer => customer.Id == routeData);
            var removedCustomer = CustomerContext.Customers.Find(customer => customer.Id == id);

            CustomerContext.Customers.Remove(removedCustomer);
            return RedirectToAction("List");
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
            
            return RedirectToAction("List");
        }
    }
}