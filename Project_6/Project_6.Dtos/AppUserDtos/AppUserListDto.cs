using Project_6.Dtos.Interfaces;

namespace Project_6.Dtos.AppUserDtos
{
    public class AppUserListDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public int GenderId { get; set; }
    }
}