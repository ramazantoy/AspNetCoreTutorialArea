using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_3.Web.Data.Context;

namespace Project_3.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _bankContext;
        
        public AccountController(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _bankContext.ApplicationUsers.SingleOrDefault(x => x.Id == id);
            
            return View(userInfo);
        }

    }
}