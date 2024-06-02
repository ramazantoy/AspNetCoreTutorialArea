using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_6.DataAccess.Contexts;
using Project_6.DataAccess.Interfaces;
using Project_6.DataAccess.UnitOfWork;

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
            var mapperConfiguration = new MapperConfiguration(opt =>
            {
            //  opt.AddProfile();
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUow, Uow>();
        }
    }
}