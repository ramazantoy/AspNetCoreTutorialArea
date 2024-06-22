using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_6.Business.Interfaces;
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
            
            var userCreateModel = new UserCreateModel
            {
                Genders = new SelectList(response.Data)
            };
            
            return View(new UserCreateModel());
        }
    }
}