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
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public IActionResult SignIn()
        {
            return View(new UserSignInModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (signInResult.Succeeded)
                {
                    
                }
                else if (signInResult.IsLockedOut)
                {
                    //locked
                }
                else if (signInResult.IsNotAllowed)
                {
                    //email or phone number verification false
                }
            }

            return View(model);
        }
    }
}