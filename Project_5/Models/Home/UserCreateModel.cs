using System.ComponentModel.DataAnnotations;

namespace Project_5.Models.Home
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Passwords are not same.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
    }
}