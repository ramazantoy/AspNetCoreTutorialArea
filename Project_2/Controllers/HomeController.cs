using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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



      // var category = context.Categories.SingleOrDefault(x=>x.Id==1); //Tracking
      //
      // category.Name = "Changed";
      //
      // var updateStage = context.Entry(category).State;
      
      // var category = context.Categories.AsNoTracking().SingleOrDefault(x=>x.Id==1); //for client no tracking for db state=detached for not saving or deleting or updating
      //
      // category.Name = "Changed";
      //
      // var updateStage = context.Entry(category).State;

      return View();
       }
    }
}