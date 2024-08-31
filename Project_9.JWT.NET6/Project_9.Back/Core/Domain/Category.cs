namespace Project_9.Back.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
