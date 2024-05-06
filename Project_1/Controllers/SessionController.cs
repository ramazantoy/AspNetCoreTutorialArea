using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_1.Controllers
{
    public class SessionController : Controller
    {
        // GET
        public IActionResult Index()
        {
            SetSession();
            ViewBag.Session = GetSession();
            return View();
        }

        private void SetSession()
        {
            HttpContext.Session.SetString("Dummy","asp.netcore");
        }

        private string GetSession()
        {
            return HttpContext.Session.GetString("Dummy");
        }
    }
}