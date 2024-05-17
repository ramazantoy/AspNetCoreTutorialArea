using Project_4.Dtos.Interfaces;

namespace Project_4.Dtos.WorkDtos
{
    public class WorkCreateDto : IDto
    {
       // [Required(ErrorMessage = "Definition is required")]
        public string Definition { get; set; }

        public bool IsCompleted { get; set; }
    }
}