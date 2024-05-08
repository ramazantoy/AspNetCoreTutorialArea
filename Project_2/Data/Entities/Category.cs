// using System.ComponentModel.DataAnnotations.Schema;

namespace Project_2.Data.Entities
{
    // [Table(name:"Category",Schema = "c")] // for table name and shema write add-migrate ... and update-database
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}