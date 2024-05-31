using System.ComponentModel.DataAnnotations;

namespace Project_5.Models.Admin
{
    public class AdminCreateNewRole
    {
        [Required(ErrorMessage = "Role name is required.")]
        public string Name { get; set; }
    }
}