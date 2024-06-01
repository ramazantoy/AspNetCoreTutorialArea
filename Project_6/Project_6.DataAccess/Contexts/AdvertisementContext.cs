using Microsoft.EntityFrameworkCore;
using Project_6.DataAccess.Configurations;
using Project_6.Entities;

namespace Project_6.DataAccess.Contexts
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedServiceConfiguration());
        }

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<AdvertisementAppUser> AdvertisementAppUsers { get; set; }

        public DbSet<AdvertisementAppUserStatus> AdvertisementUserStatus { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }
        
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<AppUserRole> AppUserRoles { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<MilitaryStatus> MilitaryStatus { get; set; }
        
        public DbSet<ProvidedService> ProvidedServices { get; set; }



    }
}