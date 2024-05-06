using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Diagnostics;
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


        public IActionResult HandleUnknownRoutes()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Status(int? code)
        {
            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            // serilog nlog

            var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");

            var logFileName = DateTime.Now.ToString();
            logFileName = logFileName.Replace(" ", "_");
            logFileName = logFileName.Replace("/", "-");
            logFileName = logFileName.Replace(":", "-");
            logFileName += ".txt";

            var logFilePath = Path.Combine(logFolderPath, logFileName);
            
            var directoryInfo = new DirectoryInfo(logFolderPath);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            var logFileInfo = new FileInfo(logFilePath);
            var writer = logFileInfo.CreateText();
            writer.WriteLine($"Where :{exceptionHandlerFeature.Path}");
            writer.WriteLine($"Message :{exceptionHandlerFeature.Error}");
            writer.Close();
            return View();
        }

        public IActionResult ErrorTest()
        {
            throw new SystemException("Error Test");
        }
    }
}