using Microsoft.EntityFrameworkCore;
using Project_4.DataAccess.Configurations;
using Project_4.Entities.Domains;

namespace Project_4.DataAccess.Contexts
{
    public class TodoContext : DbContext
    {
        public DbSet<Work> Works { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}