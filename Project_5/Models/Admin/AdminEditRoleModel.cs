using System.ComponentModel.DataAnnotations;

namespace Project_5.Models.Admin
{
    public class AdminEditRoleModel
    {
        [Required(ErrorMessage = "*Role Message is required.")]
        public string ChangeToRoleName { get; set; }
        
        public string RoleName { get; set; }
    }
}