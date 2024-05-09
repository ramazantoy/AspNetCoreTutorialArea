using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_2.Data.Entities;

namespace Project_2.Data.Configuration
{
    public class ProductDetailConfiguration : ConfigurationBase<ProductDetail>
    {
        public override void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("product_detail").Property(x => x.ProductId)
                .HasColumnName("product_id").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Id).HasColumnName("detail_id").IsRequired();
            builder.Property(x => x.Description).HasColumnName("description");
        }
    }
}