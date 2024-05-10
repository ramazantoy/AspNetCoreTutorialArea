using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_2.Data.Contexts;
using Project_2.Data.Entities;

namespace Project_2.Controllers
{

    public class HomeController : Controller
    {
       public IActionResult Index()
       {
           Project2Context context = new();
        // var entityEntry=   context.Products.Add(new Product //add database
        //    {
        //     Name = "Phone",
        //     Price = 3400,
        //    });
      

        // context.Products.Update(new Product //update on database
        // {
        //     Id = 1002,
        //     Price = 3400,
        // });
       //
       // var updateProduct= context.Products.Find(1); //for find and update
       // updateProduct.Price = 5500;
       //
       // context.Products.Update(updateProduct);
       //
       //
       // context.SaveChanges(); //save on data base

       // var deletedProduct = context.Products.FirstOrDefault(x => x.Id == 1002); //delete data
       // context.Products.Remove(deletedProduct);

       // var product = new Product { Price =4500 }; //for testing default value
       // context.Products.Add(product);
       // context.SaveChanges();

      // var s= context.Categories.ToList();
      // var list = context.Categories.AsEnumerable(); //can foreach finish job on db
      // var list2 = context.Categories.AsQueryable();//can foreach  not finish job on db
           return View();
       }
    }
}