using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_6.Business.Interfaces;
using Project_6.UI.Extensions;

namespace Project_6.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceManager _providedServiceManager;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceManager providedServiceManager, IAdvertisementService advertisementService)
        {
            _providedServiceManager = providedServiceManager;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
         var response=  await _providedServiceManager.GetAllAsync();

         return this.ResponseView(response);
        }

        public async Task<IActionResult> OpeningPositions()
        {
            var response = await _advertisementService.GetActivesAsync();
            return this.ResponseView(response);
        }
    }
}