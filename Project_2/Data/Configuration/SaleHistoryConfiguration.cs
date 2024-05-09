using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_2.Data.Entities;

namespace Project_2.Data.Configuration
{
    public class SaleHistoryConfiguration : ConfigurationBase<SaleHistory>
    {
        public override void Configure(EntityTypeBuilder<SaleHistory> builder)
        {
            builder.ToTable("sale_history");
            builder.Property(x => x.Id).HasColumnName("history_id").IsRequired().HasDefaultValueSql("-1");
            builder.Property(x => x.ProductId).HasColumnName("product_id").IsRequired().HasDefaultValueSql("-1");
            builder.Property(x => x.Amount).HasColumnName("sold_amount").HasDefaultValueSql("0");
            
            
            builder.HasOne(x => x.Product).WithMany(x => x.SaleHistories)
                .HasForeignKey(x => x.ProductId);//one to many
        }
    }
}