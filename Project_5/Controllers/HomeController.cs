using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_5.Entities;
using Project_5.Models;

namespace Project_5.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET
        public IActionResult Index()
        {
            if (User != null && User.Identity!.IsAuthenticated)
            {
                return View();
            }
            
            return RedirectToAction("SignUp");
        }

        public IActionResult SignUp()
        {
            return View(new UserCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser newUser = new()
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Gender = model.Gender,
                };
                var identityResult = await _userManager.CreateAsync(newUser, model.Password);
                if (identityResult.Succeeded)
                {
                    // await _roleManager.CreateAsync(new()
                    // {
                    //     Name = "Admin",
                    //     CreatedTime = DateTime.Now
                    // });
                    // await _userManager.AddToRoleAsync(newUser, "Admin");
                    return RedirectToAction("Index");
                }

                foreach (var resultError in identityResult.Errors)
                {
                    ModelState.AddModelError("", resultError.Description);
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
                var signInResult =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
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

        [Authorize /*(Roles="Admin, Member")*/]
        public IActionResult GetUserInfo()
        {
            var userName = User.Identity.Name;
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            User.IsInRole("Admin");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}