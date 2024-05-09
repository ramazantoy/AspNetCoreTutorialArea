using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using Project_2.Data.Entities;

namespace Project_2.Data.Contexts
{
    public class Project2Context :DbContext
    {
        public DbSet<Product> Products { get; set; } //default of table name

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<SaleHistory> SaleHistories { get; set; }
        
        public DbSet<ProductDetail> ProductDetails { get; set; }
        
        public DbSet<ProductCategory> ProductCategories { get; set; }
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
            modelBuilder.Entity<Customer>().HasKey(x => new { x.Name, x.Id }); //name and id setting to primary key
            
            modelBuilder.Entity<Category>().ToTable(name: "category");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("category_name").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("category_id").IsRequired();

            modelBuilder.Entity<Product>().ToTable(name: "product");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("product_name").HasMaxLength(50).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Name).HasDefaultValueSql("'Product name is null'");
            // modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique(true); // for adding unique value
            modelBuilder.Entity<Product>().Property(x => x.CreatedTime).HasColumnName("created_time");
            modelBuilder.Entity<Product>().Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");//for default date time
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("product_id").IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnName("product_price").HasMaxLength(50).IsRequired();

            modelBuilder.Entity<SaleHistory>().ToTable("sale_history");
            modelBuilder.Entity<SaleHistory>().Property(x => x.Id).HasColumnName("history_id").IsRequired().HasDefaultValueSql("-1");
            modelBuilder.Entity<SaleHistory>().Property(x => x.ProductId).HasColumnName("product_id").IsRequired().HasDefaultValueSql("-1");
            modelBuilder.Entity<SaleHistory>().Property(x => x.Amount).HasColumnName("sold_amount").HasDefaultValueSql("0");


            
            // one to many with fluent api
            
            // modelBuilder.Entity<Product>().HasMany(x => x.SaleHistories).WithOne(x => x.Product)
            //     .HasForeignKey(x => x.ProductId);
            

            modelBuilder.Entity<SaleHistory>().HasOne(x => x.Product).WithMany(x => x.SaleHistories)
                .HasForeignKey(x => x.ProductId);//one to many

            modelBuilder.Entity<Product>().HasOne(x => x.ProductDetail).WithOne(x => x.Product)
                .HasForeignKey<ProductDetail>(x => x.ProductId);//one to one
            
            modelBuilder.Entity<ProductDetail>().ToTable("product_detail").Property(x => x.ProductId)
                .HasColumnName("product_id").IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ProductDetail>().Property(x => x.Id).HasColumnName("detail_id").IsRequired();
            modelBuilder.Entity<ProductDetail>().Property(x => x.Description).HasColumnName("description");


            modelBuilder.Entity<ProductCategory>().ToTable("product_category").Property(x => x.ProductId)
                .HasColumnName("product_id").IsRequired();
            
            modelBuilder.Entity<ProductCategory>().Property(x=>x.CategoryId).HasColumnName("category_id").IsRequired();

            modelBuilder.Entity<Product>().HasMany(x => x.ProductCategories).WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId); //many to many 
            
            modelBuilder.Entity<Category>().HasMany(x => x.ProductCategories).WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}