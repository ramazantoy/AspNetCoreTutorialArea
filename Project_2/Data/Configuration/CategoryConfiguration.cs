using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_2.Data.Entities;

namespace Project_2.Data.Configuration
{
    public class CategoryConfiguration : ConfigurationBase<Category>
    {
        
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(name: "category");
            builder.Property(x => x.Name).HasColumnName("category_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Id).HasColumnName("category_id").IsRequired();
            
            
            builder.HasMany(x => x.ProductCategories).WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
      
    }
}