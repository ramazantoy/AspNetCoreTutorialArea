using System.Threading.Tasks;
using Project_6.Common;
using Project_6.Dtos.AppUserDtos;
using Project_6.Entities;

namespace Project_6.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto createDto,int roleId)
    }
}