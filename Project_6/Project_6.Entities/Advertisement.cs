using System;
using System.Collections.Generic;

namespace Project_6.Entities
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}