using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Project_1.Controllers
{
    public class FolderController : Controller
    {
        public IActionResult List()
        {
            var directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"));
            var directories =directoryInfo.GetDirectories();
            return View(directories);
        }
        [HttpPost]
        public IActionResult Create(string folderName)
        {
            var info=new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",folderName));
            if (!info.Exists)
            {
                info.Create();
            }
            return RedirectToAction("List");
        }
        
        public IActionResult Remove(string folderName)
        {
            var info=new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",folderName));
            if (info.Exists)
            {
                info.Delete();
            }
            return RedirectToAction("List");
        }

     
        public IActionResult Create()
        {
            return View();
        }
    }
}