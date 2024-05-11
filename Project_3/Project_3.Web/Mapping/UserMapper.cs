using System.Collections.Generic;
using System.Linq;
using Project_3.Web.Data.Entities;
using Project_3.Web.Models;

namespace Project_3.Web.Mapping
{
    public class UserMapper : IUserMapper
    {
        public List<UserListModel> MapToUserListModels(List<ApplicationUser> applicationUsers)
        {
            return applicationUsers.Select(x => new UserListModel { Id = x.Id, Surname = x.Surname, Name = x.Name }).ToList();
        }

        public UserListModel MapToUserListModel(ApplicationUser applicationUser)
        {
            return new UserListModel
            {
                Id = applicationUser.Id,
                Name = applicationUser.Name,
                Surname = applicationUser.Surname
            };
        }
    }
}