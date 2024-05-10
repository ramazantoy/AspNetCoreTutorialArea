using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_3.Web.Data.Entities;

namespace Project_3.Web.Data.Configurations
{
    public class ApplicationUserConfiguration : ConfigureEntities<ApplicationUser>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            builder.ToTable("application_user");
            
            builder.Property(x => x.Name).HasColumnName("user_name").HasMaxLength(200).IsRequired();

            builder.Property(x => x.Surname).HasColumnName("user_surname").HasMaxLength(250).IsRequired();

            builder.Property(x => x.Id).HasColumnName("user_id").IsRequired();
           
            builder.HasMany(x => x.Accounts).WithOne(x => x.ApplicationUser).HasForeignKey(x => x.ApplicationUserId);

        }
    }
}