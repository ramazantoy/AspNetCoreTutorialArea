using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_6.Business.Interfaces;
using Project_6.Common;
using Project_6.Common.Enums;
using Project_6.Dtos.AppUserDtos;
using Project_6.UI.Extensions;
using Project_6.UI.Models;

namespace Project_6.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserService, IMapper mapper)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            
            var genders = response.Data.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Definition
            }).ToList();
            var model = new UserCreateModel
            {
                Genders = genders
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var validateResult = await _userCreateModelValidator.ValidateAsync(model);

            if (validateResult.IsValid)
            {
                var dto =  _mapper.Map<AppUserCreateDto>(model);
               var createResponse= await _appUserService.CreateWithRoleAsync(dto,(int)RoleType.Member);
               return this.ResponseRedirectToAction(createResponse, "SignIn");
                // return View(model);
            }
            
            foreach (var validateResultError in validateResult.Errors)
            {
                ModelState.AddModelError(validateResultError.PropertyName,validateResultError.ErrorMessage);
            }
            return View(model);
 
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto model)
        {
         var result=await  _appUserService.CheckUserAsync(model);

         if (result.ResponseType == ResponseType.Succes)
         {
             var claims = new List<Claim>
             {
             };

             var claimsIdentity = new ClaimsIdentity(
                 claims, CookieAuthenticationDefaults.AuthenticationScheme);

             var authProperties = new AuthenticationProperties
             {
                 IsPersistent = model.RememberMe,
             };

             await HttpContext.SignInAsync(
                 CookieAuthenticationDefaults.AuthenticationScheme, 
                 new ClaimsPrincipal(claimsIdentity), 
                 authProperties);
         }
         
         ModelState.AddModelError("",result.Message);
         return View(model);
        }
    }
}