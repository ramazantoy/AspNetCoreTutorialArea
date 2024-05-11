using System.Collections.Generic;
using Project_3.Web.Data.Entities;
using Project_3.Web.Models;

namespace Project_3.Web.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToUserListModels(List<ApplicationUser> applicationUsers);
        
        UserListModel MapToUserListModel(ApplicationUser applicationUser);
    }
}