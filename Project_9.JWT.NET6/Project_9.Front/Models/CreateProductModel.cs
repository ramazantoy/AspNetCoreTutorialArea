using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_9.Front.Models;

public class CreateProductModel
{
    [Required(ErrorMessage = "Name required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Stock Required")]

    public int Stock { get; set; }

    [Required(ErrorMessage = "Price Required")]

    public decimal Price { get; set; }

    [Required(ErrorMessage = "Choose a category")]
    public int CategoryId { get; set; }

    public SelectList? Categories { get; set; }
}