using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Project_6.Business.DependencyResolvers.Microsoft;
using Project_6.Business.Helpers;
using Project_6.UI.Mappings.AutoMapper;
using Project_6.UI.Models;
using Project_6.UI.ValidationRules;

namespace Project_6.UI
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

 
     
        public void ConfigureServices(IServiceCollection services)
        {
          services.AddDependencies(Configuration);
          services.AddControllersWithViews();
          
          services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(opt =>
              {
                  opt.Cookie.Name = "Project_6.Cookie";
                  opt.Cookie.HttpOnly = true;
                  opt.Cookie.SameSite = SameSiteMode.Strict;
                  opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                  opt.Cookie.Expiration=TimeSpan.FromDays(20);
                  opt.LoginPath = new PathString("Account/SignIn");
                  opt.LogoutPath = new PathString("Account/SignOut");
                  opt.AccessDeniedPath = new PathString("Account/AccessDenied");
              });
          
          services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();

          var profiles = ProfileHelper.GetMapperProfiles();

          profiles.Add(new UserCreateModelProfile());

          var configuration = new MapperConfiguration(opt =>
          {
              opt.AddProfiles(profiles);
          });

          var mapper = configuration.CreateMapper();
          services.AddSingleton(mapper);
        }

    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
