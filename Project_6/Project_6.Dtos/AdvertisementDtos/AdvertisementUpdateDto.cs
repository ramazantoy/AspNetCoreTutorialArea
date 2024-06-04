using Project_6.Dtos.Interfaces;

namespace Project_6.Dtos.AdvertisementDtos
{
    public class AdvertisementUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}