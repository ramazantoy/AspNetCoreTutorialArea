using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_2.Data.Entities;

namespace Project_2.Data.Configuration
{
    public class ProductCategoryConfiguration : ConfigurationBase<ProductCategory>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("product_category").Property(x => x.ProductId)
                .HasColumnName("product_id").IsRequired();
            builder.Property(x=>x.CategoryId).HasColumnName("category_id").IsRequired();
            
          builder.HasKey(x => new { x.ProductId, x.CategoryId });
        }
    }
}