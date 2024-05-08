using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace Project_2.ViewComponents
{
 
  [HtmlTargetElement("paragraph")]
    public class Category : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

