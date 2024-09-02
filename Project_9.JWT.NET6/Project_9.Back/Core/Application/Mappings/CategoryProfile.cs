using AutoMapper;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryListDto>().ReverseMap();
    }
}