using System.Collections.Generic;
using System.Threading.Tasks;
using Project_6.Common;
using Project_6.Dtos.AdvertisementDtos;
using Project_6.Entities;

namespace Project_6.Business.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}