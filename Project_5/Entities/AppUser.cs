using Microsoft.AspNetCore.Identity;

namespace Project_5.Entities
{
    public class AppUser :IdentityUser<int> //primary key set to int
    {
        public string ImagePath { get; set; }
        public string Gender { get; set; }
    }
}