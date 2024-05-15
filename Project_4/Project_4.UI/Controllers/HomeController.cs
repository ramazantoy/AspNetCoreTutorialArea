using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_4.Business.Interfaces;

namespace Project_4.UI.Controllers
{
    public class HomeController : Controller
    {
        private IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var workList = await _workService.GetAll();
            return View(workList);
        }
    }
}