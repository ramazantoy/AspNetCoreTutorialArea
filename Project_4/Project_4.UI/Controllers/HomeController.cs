using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_4.Business.Interfaces;
using Project_4.Dtos.WorkDtos;

namespace Project_4.UI.Controllers
{
    public class HomeController : Controller
    {
        private IWorkService _workService;

        private readonly IMapper _mapper;

        public HomeController(IWorkService workService, IMapper mapper)
        {
            _workService = workService;
            _mapper = mapper;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var workList = await _workService.GetAll();
            return View(workList);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto workCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _workService.Create(workCreateDto);
                return RedirectPermanent("Index");
            }

            return View(workCreateDto);
        }

        public async Task<IActionResult> Update(int workId)
        {
            return View(_mapper.Map<WorkUpdateDto>(await _workService.GetById(workId)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto workUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _workService.Update(workUpdateDto);
                return RedirectToAction("Index");
            }

            return View(workUpdateDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _workService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}