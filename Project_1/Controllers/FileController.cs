using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_1.Controllers
{
    public class FileController : Controller
    {
        // GET
        public IActionResult List()
        {
            var info=new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","files"));
            var files = info.GetFiles();
            return View(files);
        }

        public IActionResult Remove()
        {
            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string fileName)
        {
            var fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files",fileName));
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }
            return RedirectToAction("List");
        }

        public IActionResult CreateWithData()
        {
            var fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files",Guid.NewGuid()+".txt"));

           var writer= fileInfo.CreateText();
           writer.Write("Hi, its ramo");
           writer.Close();
            return RedirectToAction("List");
        }

        public IActionResult Upload()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Upload(IFormFile formFile)
        {
            if (formFile.ContentType == "image/png")
            {
                var ext= Path.GetExtension(formFile.FileName);
                var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",Guid.NewGuid()+ext), FileMode.Create);
                formFile.CopyTo(stream);
                TempData["message"] = "File uploaded successfully.";
            }
            else
            {
                TempData["message"] = "Fail to upload file. Unsuitable file type ";
            }

            return View();
        }
    }
    
}