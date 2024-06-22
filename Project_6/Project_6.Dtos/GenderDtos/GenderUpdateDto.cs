using Project_6.Dtos.Interfaces;

namespace Project_6.Dtos.GenderDtos
{
    public class GenderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}