using Microsoft.AspNetCore.Mvc;

namespace Project_9.Front.ViewComponents;

public class NavbarViewComponent : ViewComponent
{
   public IViewComponentResult Invoke()
   {
      return View();
      
   }
}