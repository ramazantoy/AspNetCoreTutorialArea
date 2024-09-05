using System.ComponentModel.DataAnnotations;

namespace Project_9.Front.Models;

public class CreateCategoryModel
{
    [Required(ErrorMessage = "Required Category Definition.")]
    public string? Definition { get; set; } = null!;
}