using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_1.Controllers
{
    public class CookieController : Controller
    {
        // GET
        public IActionResult Index()
        {
            SetCookie();
            ViewBag.Cookie = GetCookie();
            return View();
        }

        private void SetCookie()
        {
            HttpContext.Response.Cookies.Append("Course","Asp net core",new CookieOptions
            {
              Expires  = DateTimeOffset.Now.AddDays(10),//how time store
              HttpOnly = true,// for  not catch from js.
              SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict //only this project using this cookie
            });
        }
        //Response
        //Request

        private string GetCookie()
        { 
            HttpContext.Request.Cookies.TryGetValue("Course",out var cookieValue);
          return cookieValue;
        }
    }
}