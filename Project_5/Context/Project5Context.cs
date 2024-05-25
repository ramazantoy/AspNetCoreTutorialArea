using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_5.Entities;

namespace Project_5.Context
{
    public class Project5Context : IdentityDbContext<AppUser,AppRole,int>
    {
        public Project5Context(DbContextOptions<Project5Context> options) : base(options)
        {
            
        }
    }
}