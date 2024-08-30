using Microsoft.EntityFrameworkCore;

namespace Project_8.CQRS.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student()
                {
                    Id = 1,
                    Name = "Leon",
                    Surname = "Brave",
                    Age = 21,

                },
                new Student()
                {
                    Id = 2,
                    Name = "a fool",
                    Surname = "as fallen",
                    Age = 27,

                },
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}