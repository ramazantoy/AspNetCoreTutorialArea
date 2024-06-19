using AutoMapper;
using FluentValidation;
using Project_6.Business.Interfaces;
using Project_6.DataAccess.Interfaces;
using Project_6.Dtos.AppUserDtos;

using Project_6.Entities;

namespace Project_6.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>,IAppUserService
    {
        public AppUserService(IMapper mapper,IValidator<AppUserCreateDto> createDtoValidator,IValidator<AppUserUpdateDto> updateDtoValidator,IUow uow)
            : base(mapper,createDtoValidator,updateDtoValidator,uow)
        {
            
        }
    }
}