using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_6.Business.Interfaces;
using Project_6.Dtos.GenderDtos;
using Project_6.Entities;
using Project_6.UI.Models;

namespace Project_6.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IAppUserService _appUserService;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserService)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserService = appUserService;
        }

        // GET
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
              //  _appUserService.CreateAsync()
                return View(model);
            }
            
            foreach (var validateResultError in validateResult.Errors)
            {
                ModelState.AddModelError(validateResultError.PropertyName,validateResultError.ErrorMessage);
            }
            return View(model);
 
        }
    }
}