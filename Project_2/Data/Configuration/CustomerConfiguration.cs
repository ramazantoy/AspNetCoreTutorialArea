using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_2.Data.Entities;

namespace Project_2.Data.Configuration
{
    public class CustomerConfiguration : ConfigurationBase<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(name: "customer");
            builder.Property(x => x.Name).HasColumnName("customer_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Surname).HasColumnName("customer_surname").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Id).HasColumnName("customer_id");
            builder.HasKey(x => new { x.Name, x.Id }); //name and id setting to primary key
        }
    }
}