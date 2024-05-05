using Microsoft.AspNetCore.Mvc;
using Project_1.Models;

namespace Project_1.ViewComponents
{
    public class NewsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var news = NewsContext.News;
            return View(news);
        }
    }
}