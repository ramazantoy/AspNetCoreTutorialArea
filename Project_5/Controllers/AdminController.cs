using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_5.Entities;
using Project_5.Models.Admin;
using Project_5.Models.Home;

namespace Project_5.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> AdminPanel()
        {
            var users = _userManager.Users.ToList();
            var userModels = new List<UserModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userModels.Add(new UserModel
                {
                    UserName = user.UserName,
                    Mail = user.Email,
                    Roles = roles.ToList()
                });
            }

            return View(userModels);
        }

        public async Task<IActionResult> Delete(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("AdminPanel");
        }

        public async Task<IActionResult> EditUser(string userName)
        {
            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }


            ViewBag.UserCurrentName = userName;

            var user = await _userManager.FindByNameAsync(userName);
            var userModel = new UserEditModel()
            {
                UserName = user.UserName,
                Mail = user.Email
            };
            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(string userCurrentName, UserEditModel userEditModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "An error occurred while updating the user.";
                return RedirectToAction("EditUser", new { userName = userCurrentName });
            }

            var user = await _userManager.FindByNameAsync(userCurrentName);

            if (user.UserName != userEditModel.UserName)
            {
                var existingUser = await _userManager.FindByNameAsync(userEditModel.UserName);
                if (existingUser != null)
                {
                    TempData["ErrorMessage"] = " This name is already taken.";
                    return RedirectToAction("EditUser", new { userName = userCurrentName });
                }

                user.UserName = userEditModel.UserName;
            }


            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
           
                return RedirectToAction("AdminPanel");
            }

            foreach (var error in result.Errors)
            {
                TempData["ErrorMessage"] += $"{error.Description}\n";
            }

            return RedirectToAction("EditUser", new { userName = userCurrentName });
        }

        public IActionResult CreateNewUser()
        {
            return View(new AdminUserCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser(AdminUserCreateModel userCreateModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser()
                {
                    UserName = userCreateModel.UserName,
                    Email = userCreateModel.Email,
                    Gender = userCreateModel.Gender,
                };

               var result = await _userManager.CreateAsync(newUser, userCreateModel.UserName + "9876");

               if (result.Succeeded)
               {
                   var roleResult=await _userManager.AddToRoleAsync(newUser, "Member");
                   if (roleResult.Succeeded)
                   {
                       return RedirectToAction("AdminPanel");
                   }
                   foreach (var resultError in roleResult.Errors)
                   {
                       ModelState.AddModelError("",resultError.Description);
                   }

               }
               else
               {
                   foreach (var resultError in result.Errors)
                   {
                       ModelState.AddModelError("",resultError.Description);
                   }

               }
               
             
            }
            return View();
        }
    }

}