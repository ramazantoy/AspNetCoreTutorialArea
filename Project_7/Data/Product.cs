using System;

namespace Project_7.Data
{
    public class Product
    {
        public int Id { get; set; }
        public int  Stock { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImagePath { get; set; }
    }
}