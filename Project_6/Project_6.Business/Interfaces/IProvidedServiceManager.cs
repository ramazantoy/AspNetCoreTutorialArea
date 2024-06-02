using Project_6.Dtos.ProvidedServiceDtos;
using Project_6.Entities;

namespace Project_6.Business.Interfaces
{
    public interface IProvidedServiceManager : IService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto,ProvidedService>
    {
        
    }
}