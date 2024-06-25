using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AccountController(IGenderService genderService)
        {
            _genderService = genderService;
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
            return View(model);
        }
    }
}