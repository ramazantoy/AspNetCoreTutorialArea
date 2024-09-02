using AutoMapper;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductListDto>().ReverseMap();
        CreateMap<CreateProductCommandRequest, Product>();
    }
}