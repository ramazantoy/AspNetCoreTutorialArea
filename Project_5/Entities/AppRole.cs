using System;
using Microsoft.AspNetCore.Identity;

namespace Project_5.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreatedTime { get; set; }
        
    }
}