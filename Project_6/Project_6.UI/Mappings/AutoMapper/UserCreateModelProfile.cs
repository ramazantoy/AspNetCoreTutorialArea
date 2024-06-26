using AutoMapper;
using Project_6.Dtos.AppUserDtos;
using Project_6.UI.Models;

namespace Project_6.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile : Profile
    {
        public UserCreateModelProfile() 
        {
            CreateMap<UserCreateModel, AppUserCreateDto>();
        }
    }
}