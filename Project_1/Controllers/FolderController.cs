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
    }
}