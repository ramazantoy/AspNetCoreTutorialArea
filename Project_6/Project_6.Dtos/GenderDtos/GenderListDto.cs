using System.Security.Cryptography;
using Project_6.Dtos.Interfaces;

namespace Project_6.Dtos.GenderDtos
{
    public class GenderListDto : IDto
    {
        public int Id;
        public string Definition { get; set; }
    }
}