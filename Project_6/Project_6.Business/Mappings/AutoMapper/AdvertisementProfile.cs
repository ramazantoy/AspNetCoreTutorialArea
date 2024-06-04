using AutoMapper;
using Project_6.Dtos.AdvertisementDtos;
using Project_6.Entities;

namespace Project_6.Business.Mappings.AutoMapper
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<Advertisement, AdvertisementListDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementCreateDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap();
        }
    }
}