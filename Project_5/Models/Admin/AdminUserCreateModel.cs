using System.ComponentModel.DataAnnotations;

namespace Project_5.Models.Admin
{
    public class AdminUserCreateModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }
        
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
    }
}