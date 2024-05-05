using Microsoft.AspNetCore.Mvc;
using Project_1.Models;

namespace Project_1.ViewComponents
{
    public class NewsComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string color="Default")
        {
            var news = NewsContext.News;
            return color switch
            {
                "Default" => View(news),
                "Red" => View("Red", news),
                _ => View("Blue", news)
            };
        }
    }
}