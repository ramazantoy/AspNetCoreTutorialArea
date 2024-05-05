using System.ComponentModel.DataAnnotations;

namespace Project_1.Models
{
    //DataAnnotation
    
    public class Customer
    {
        [Required(ErrorMessage = "Id is required")] // maybe CreateCustomer class writing for required jobs nexttime
        [Range(1,int.MaxValue)]
        public  int Id { get; set; }
        
        [Required(ErrorMessage = "The name is required.")]
        [MaxLength(30,ErrorMessage = "Contains max 30 character.")]
        [MinLength(3,ErrorMessage = "Contains min 3 character.")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "The lastname is required.")]
        [MaxLength(30,ErrorMessage = "Contains max 30 character.")]
        [MinLength(2,ErrorMessage = "Contains min 2 character.")]
        public string LastName { get; set; }
    }
}
