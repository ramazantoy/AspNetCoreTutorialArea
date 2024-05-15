using System.ComponentModel.DataAnnotations;

namespace Project_4.Dtos.WorkDtos
{
    public class WorkCreateDto
    {
       [Required(ErrorMessage = "Definition is required")]
        public string Definition { get; set; }

        public bool IsCompleted { get; set; }
    }
}