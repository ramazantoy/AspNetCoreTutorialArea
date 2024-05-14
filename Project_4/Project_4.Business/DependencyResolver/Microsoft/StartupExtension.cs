using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project_4.DataAccess.Contexts;

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

        }
    }
}