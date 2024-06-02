using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_6.DataAccess.Contexts;

namespace Project_6.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
        }
    }
}