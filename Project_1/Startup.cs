using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project_1.Controllers;
using Project_1.Middlewares;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Project_1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*,IConfiguration configuration*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // var firstName = configuration.GetSection("FirstName"); //Configuration test
            app.UseExceptionHandler("/Home/Error");
            
            app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}");
            
            app.UseStaticFiles();//wwwroot opened
          
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules"))
            });

           
            app.UseRouting();

            app.UseSession();//for using session

           
            app.UseEndpoints(endpoints =>
            {
                
                
                // endpoints.MapControllerRoute( //for using other controllers
                //     name: "test",
                //     pattern: "Test/{Action}/",
                //     defaults: new { Controller = "Home", Action = "Index" }
                // );

                endpoints.MapControllerRoute(
                    name: "Areas",
                    pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller}/{Action}/{id?}",//nullabla id or id:int  only int or id:alpha only characters
                    defaults: new { Controller = "Home", Action = "Index" }//for default page if controller is not found.
                );
                // endpoints.MapFallbackToController("HandleUnknownRoutes", "Home");
            });

            //app.UseMiddleware<ResponseEditingMiddleware>();
            //app.UseMiddleware<RequestEditingMiddleware>();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
