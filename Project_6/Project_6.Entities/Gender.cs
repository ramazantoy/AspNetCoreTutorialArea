using System.Collections.Generic;

namespace Project_6.Entities
{
    public class Gender  : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}