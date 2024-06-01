using System;

namespace Project_6.Entities
{
    public class AdvertisementAppUser : BaseEntity
    {
        public int AdvertisementId { get; set; }

        public int AppUserId { get; set; }

        public int  AdvertisementUserStatusId { get; set; }
        
        public int  MilitaryStatusId { get; set; }
        
        public DateTime? EndDate { get; set; }

        public int WorkExperience { get; set; }

        public string CvPath { get; set; }
        
 
    }
}