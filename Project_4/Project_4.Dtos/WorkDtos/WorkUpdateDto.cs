using System.ComponentModel.DataAnnotations;

namespace Project_4.Dtos.WorkDtos
{
    public class WorkUpdateDto
    {
        [Range(1,int.MaxValue,ErrorMessage = "Id is not valid")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Definition is required")]
        public string Definition { get; set; }

        public bool IsCompleted { get; set; }
    }
}