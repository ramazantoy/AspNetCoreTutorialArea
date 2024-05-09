namespace Project_2.Data.Entities
{
    public class SaleHistory
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; } 
        
        //Navigation property
        public Product Product { get; set; }
        
        public int Amount { get; set; }
        // public int CustomerId { get; set; }
        
    }
}