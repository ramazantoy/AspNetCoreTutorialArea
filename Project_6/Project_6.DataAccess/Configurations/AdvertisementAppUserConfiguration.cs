using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_6.Entities;

namespace Project_6.DataAccess.Configurations
{
    public class AdvertisementAppUserConfiguration : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            builder.HasIndex(x => new
            {
                x.AdvertisementId,
                x.AppUserId
            }).IsUnique();

            builder.Property(x => x.CvPath).HasMaxLength(500).IsRequired();
            
            builder.HasOne(x => x.Advertisement).WithMany(x => x.AdvertisementAppUsers)
                .HasForeignKey(x => x.AdvertisementId);
            
            builder.HasOne(x => x.AppUser).WithMany(x => x.AdvertisementAppUsers)
                .HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.AdvertisementUserStatus).WithMany(x => x.AdvertisementAppUsers)
                .HasForeignKey(x => x.AdvertisementUserStatusId);

            builder.HasOne(x => x.MilitaryStatus).WithMany(x => x.AdvertisementAppUsers)
                .HasForeignKey(x => x.MilitaryStatusId);
        }
    }
}