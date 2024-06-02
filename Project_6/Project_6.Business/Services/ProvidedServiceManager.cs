using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Project_6.Business.Interfaces;
using Project_6.Common;
using Project_6.DataAccess.Interfaces;
using Project_6.Dtos.Interfaces;
using Project_6.Dtos.ProvidedServiceDtos;
using Project_6.Entities;

namespace Project_6.Business.Services
{
    public class ProvidedServiceManager : Service<ProvidedServiceCreateDto,ProvidedServiceUpdateDto,ProvidedServiceListDto,Entities.ProvidedService>,IProvidedServiceManager
    {
        
        
        public ProvidedServiceManager(IMapper mapper,IValidator<ProvidedServiceCreateDto> createDtoValidator,IValidator<ProvidedServiceUpdateDto> updateDtoValidator,IUow uow):base(mapper,createDtoValidator,updateDtoValidator,uow)
        {
            
        }
    }
}