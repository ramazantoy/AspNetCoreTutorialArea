using Microsoft.EntityFrameworkCore;
using Project_9.Back.Core.Domain;
using Project_9.Back.Persistance.Configurations;

namespace Project_9.Back.Persistance.Context;

public class Project9JwtContext : DbContext
{
    public Project9JwtContext(DbContextOptions<Project9JwtContext> options):base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<AppUser> AppUsers => Set<AppUser>();
    public DbSet<AppRole> AppRoles => Set<AppRole>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}