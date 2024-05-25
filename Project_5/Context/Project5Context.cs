using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project_5.Context
{
    public class Project5Context : IdentityDbContext
    {
        public Project5Context(DbContextOptions<Project5Context> options) : base(options)
        {
            
        }
    }
}