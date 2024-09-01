using AutoMapper;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        this.CreateMap<Product, ProductListDto>().ReverseMap();
    }
}