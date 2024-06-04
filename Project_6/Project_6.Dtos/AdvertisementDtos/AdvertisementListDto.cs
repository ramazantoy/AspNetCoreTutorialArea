using System;
using Project_6.Dtos.Interfaces;

namespace Project_6.Dtos.AdvertisementDtos
{
    public class AdvertisementListDto : IDto
    {
        public int  Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}