using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project_4.Business.Interfaces;
using Project_4.Business.Services;
using Project_4.DataAccess.Contexts;
using Project_4.DataAccess.UnitOfWork;

namespace Project_4.Business.DependencyResolver.Microsoft
{
    public  static class StartupExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database=Project4Core; integrated security=true;");
            });

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();
        }
    }
}