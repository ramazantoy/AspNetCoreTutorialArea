// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace Project_2.Data.Entities
{
    // [Table(name:"Category",Schema = "c")] // for table name and shema write add-migrate ... and update-database
    public class Category
    {
        // [Column("category_id")] 
        public int Id { get; set; }
        
        // [Required]
        // [MaxLength(50)]
        //for category_name  and max length
        // [Column("category_name",TypeName = "nvarchar(50)")]
        public string Name { get; set; }
    }
}