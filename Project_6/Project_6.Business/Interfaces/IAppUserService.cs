using Project_6.Dtos.AppUserDtos;
using Project_6.Entities;

namespace Project_6.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
        
    }
}