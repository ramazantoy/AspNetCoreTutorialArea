using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_6.Entities;

namespace Project_6.DataAccess.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();

            builder.HasData(new AppRole[]
            {
              new ()
              {
                  Definition = "Admin",
                  Id=1,
              },
              new (){
                  Definition = "Member",
                  Id=2,
              }
            });
        }
    }
}