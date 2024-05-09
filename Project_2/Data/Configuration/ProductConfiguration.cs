using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_2.Data.Entities;

namespace Project_2.Data.Configuration
{
    public class ProductConfiguration : ConfigurationBase<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(name: "product");
            builder.Property(x => x.Name).HasColumnName("product_name").HasMaxLength(50).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasDefaultValueSql("'Product name is null'");
            // modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique(true); // for adding unique value
            builder.Property(x => x.CreatedTime).HasColumnName("created_time");
            builder.Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");//for default date time
            builder.Property(x => x.Id).HasColumnName("product_id").IsRequired();
            builder.Property(x => x.Price).HasColumnName("product_price").HasMaxLength(50).IsRequired();
            
            builder.HasOne(x => x.ProductDetail).WithOne(x => x.Product)
                .HasForeignKey<ProductDetail>(x => x.ProductId);//one to one
            
           builder.HasMany(x => x.ProductCategories).WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId); //many to many 

        }
    }
}