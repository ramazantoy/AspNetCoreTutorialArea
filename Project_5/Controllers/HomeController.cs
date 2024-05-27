using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_5.Entities;
using Project_5.Models;

namespace Project_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new UserCreateModel());
        }
        [HttpPost]
        public async  Task<IActionResult> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser newUser = new()
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Gender = model.Gender,

                };
             var identityResult= await  _userManager.CreateAsync(newUser, model.Password);
             if (identityResult.Succeeded)
             {
                 return RedirectToAction("Index");
             }
             foreach (var resultError in identityResult.Errors)
             {
                 ModelState.AddModelError("",resultError.Description);
             }
            }
            return View(model);
        }
    }
}