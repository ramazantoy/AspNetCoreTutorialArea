using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Project_5.Models.Admin
{
    public class UserModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Mail { get; set; }
        [NotNull]
        public List<string> Roles { get; set; }
    }
}