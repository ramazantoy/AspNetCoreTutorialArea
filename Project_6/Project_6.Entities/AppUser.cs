﻿using System.Collections.Generic;

namespace Project_6.Entities
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public int GenderId { get; set; }

        public Gender Gender { get; set; }
        
        public List<AppUserRole> AppUserRoles { get; set; }

        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}