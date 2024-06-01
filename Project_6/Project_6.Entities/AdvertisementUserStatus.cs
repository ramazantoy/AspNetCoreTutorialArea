using System.Collections.Generic;

namespace Project_6.Entities
{
    public class AdvertisementUserStatus : BaseEntity
    {
        public string Definition { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}