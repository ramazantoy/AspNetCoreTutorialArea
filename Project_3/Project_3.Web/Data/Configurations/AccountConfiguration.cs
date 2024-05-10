using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_3.Web.Data.Entities;

namespace Project_3.Web.Data.Configurations
{
    public class AccountConfiguration : ConfigureEntities<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");

            builder.Property(x => x.AccountNumber).IsRequired().HasColumnName("account_number");
            builder.Property(x => x.ApplicationUserId).HasColumnName("userId");
            builder.Property(x => x.Balance).HasColumnName("balance").HasColumnType("decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.Id).HasColumnName("account_id");
            
        }
    }
}