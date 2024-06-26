using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_6.Business.Interfaces;
using Project_6.Business.Mappings.AutoMapper;
using Project_6.Business.Services;
using Project_6.Business.ValidationRules.FluentValidation;
using Project_6.DataAccess.Contexts;
using Project_6.DataAccess.Interfaces;
using Project_6.DataAccess.UnitOfWork;
using Project_6.Dtos.AdvertisementDtos;
using Project_6.Dtos.AppUserDtos;
using Project_6.Dtos.GenderDtos;
using Project_6.Dtos.ProvidedServiceDtos;

namespace Project_6.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

       
            services.AddScoped<IUow, Uow>();

            /*Validators*/

            #region Validators

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();

            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();

            #endregion


            #region Services

            services.AddScoped<IProvidedServiceManager, ProvidedServiceManager>();

            services.AddScoped<IAdvertisementService, AdvertisementService>();

            services.AddScoped<IAppUserService, AppUserService>();

            services.AddScoped<IGenderService, GenderService>();

            #endregion
        }
        
   
    }
   
}