using Microsoft.EntityFrameworkCore;
using Project_2.Data.Entities;

namespace Project_2.Data.Contexts
{
    public class Project2Context :DbContext
    {
        public DbSet<Product> Products { get; set; } //default of table name

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "server=(localdb)\\mssqllocaldb; database=Project2Core; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //fluent api ovverride to dataannotations
        {
            // modelBuilder.Entity<Category>().HasNoKey(); //if we want create without primarykey
            // modelBuilder.Entity<Category>().HasKey(x=>x.Name); // for set primary key one
            // modelBuilder.Entity<Category>().HasKey(x => new { x.Name, x.Id });//name and id set to primary key

            modelBuilder.Entity<Customer>().ToTable(name: "customer");
            modelBuilder.Entity<Customer>().Property(x => x.Name).HasColumnName("customer_name").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.Surname).HasColumnName("customer_surname").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.Id).HasColumnName("customer_id");
            
            modelBuilder.Entity<Category>().ToTable(name: "category");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("category_name").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("category_id").IsRequired();

            modelBuilder.Entity<Product>().ToTable(name: "product");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("product_name").HasMaxLength(50).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Name).HasDefaultValueSql("'Product name is null'");

            modelBuilder.Entity<Product>().Property(x => x.CreatedTime).HasColumnName("created_time");
            modelBuilder.Entity<Product>().Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");//for default date time
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("product_id").IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnName("product_price").HasMaxLength(50)
                .IsRequired();
            
            
            modelBuilder.Entity<Customer>().HasKey(x => new { x.Name, x.Id });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}