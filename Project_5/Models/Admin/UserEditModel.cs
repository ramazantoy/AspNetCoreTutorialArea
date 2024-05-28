using System.ComponentModel.DataAnnotations;

namespace Project_5.Models.Admin
{
    public class UserEditModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Mail { get; set; }
    }
}