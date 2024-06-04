using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_6.Business.Interfaces;
using Project_6.UI.Extensions;

namespace Project_6.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceManager _providedServiceManager;

        public HomeController(IProvidedServiceManager providedServiceManager)
        {
            _providedServiceManager = providedServiceManager;
        }

        public async Task<IActionResult> Index()
        {
         var response=  await _providedServiceManager.GetAllAsync();

         return this.ResponseView(response);
        }

        public IActionResult OpeningPositions()
        {
            return View();
        }
    }
}