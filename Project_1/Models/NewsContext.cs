using System.Collections.Generic;

namespace Project_1.Models
{
    public static class NewsContext
    {
        public static List<News> News = new()
        {
            new News{Title = "News_1"},
            new News { Title = "News_2"}
        };
    }
}