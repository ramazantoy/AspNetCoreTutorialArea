using System.ComponentModel.DataAnnotations;

namespace Project_9.Front.Models;

public class UserLoginModel
{
    [Required(ErrorMessage = "User name is required")]
    public string UserName { get; set; } = null!;
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;
}