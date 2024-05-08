using Microsoft.EntityFrameworkCore;
using Project_2.Data.Entities;

namespace Project_2.Data.Contexts
{
    public class Project2Context :DbContext
    {
        public DbSet<Product> Products { get; set; } //default of table name

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "server=(localdb)\\mssqllocaldb; database=Project2Core; integrated security=true;");
        }
    }
}