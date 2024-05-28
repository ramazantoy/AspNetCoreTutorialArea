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
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult SignUp()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

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
                    var memberRole = await _roleManager.FindByNameAsync("Member");
                    if (memberRole == null)
                    {
                        await _roleManager.CreateAsync(new()
                        {
                            Name = "Member",
                            CreatedTime = DateTime.Now
                        });
                    }

                    await _userManager.AddToRoleAsync(newUser, "Member");
                    
                }

                foreach (var resultError in identityResult.Errors)
                {
                    ModelState.AddModelError("", resultError.Description);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult SignIn(string returnUrl)
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            return View(new UserSignInModel()
            {
                ReturnUrl = returnUrl
            });
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
             
                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    var roles = await _userManager.GetRolesAsync(user);

                    return RedirectToAction(roles.Contains("Admin") ? "AdminPanel" : "Panel");
                }

                if (signInResult.IsLockedOut)
                {
                    //locked
                }
                else if (signInResult.IsNotAllowed)
                {
                    //email or phone number verification false
                }
            }
         
            ModelState.AddModelError("","Username or password is not correct");
            

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
        public  async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult Panel()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult MemberPage()
        {
            return View();
        }
    }
}