using System.Collections.Generic;

namespace Project_6.Entities
{
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; }
        
        public List<AppUserRole> UserRoles { get; set; }
    }
}