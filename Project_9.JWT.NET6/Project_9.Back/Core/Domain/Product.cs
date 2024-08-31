namespace Project_9.Back.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int  CategoryId { get; set; }
        public Category  Category { get; set; }

        public Product()
        {
            Category = new Category();
        }
    }
}
