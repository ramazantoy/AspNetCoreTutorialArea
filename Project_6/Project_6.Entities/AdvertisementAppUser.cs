using System;

namespace Project_6.Entities
{
    public class AdvertisementAppUser : BaseEntity
    {
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int  AdvertisementUserStatusId { get; set; }

        public AdvertisementUserStatus AdvertisementUserStatus  { get; set; }
        
        public int  MilitaryStatusId { get; set; }
        
        public DateTime? EndDate { get; set; }

        public MilitaryStatus MilitaryStatus { get; set; }

        public int WorkExperience { get; set; }

        public string CvPath { get; set; }
        
 
    }
}