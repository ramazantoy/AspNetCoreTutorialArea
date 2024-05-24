using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_4.Business.Interfaces;
using Project_4.Dtos.WorkDtos;

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
            var response = await _workService.GetAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto workCreateDto)
        {
            var response = await _workService.Create(workCreateDto); // if check for success

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int workId)
        {
            var response = await _workService.GetById<WorkUpdateDto>(workId);
            //if check

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto workUpdateDto)
        {
            var response = await _workService.Update(workUpdateDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}