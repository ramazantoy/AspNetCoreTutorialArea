using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project_1.Models;

namespace Project_1.Filters
{
    public class ValidFirstName : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           var dictionary= context.ActionArguments.FirstOrDefault(I => I.Key == "customer");

           var customer = dictionary.Value as Customer;
           if (customer!.FirstName.Equals("Leon"))
           {
               context.Result = new RedirectResult("/Home/Index");
           }
        
           base.OnActionExecuting(context);
        }
    }
}