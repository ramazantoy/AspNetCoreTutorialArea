using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_9.Front.Models;

public class UpdateProductModel
{
    public SelectList? Categories { get; set; }
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Stock is required")]

    public int Stock { get; set; }

    [Required(ErrorMessage = "Price is required")]

    public decimal Price { get; set; }

    [Required(ErrorMessage = "Choose a category")]
    public int CategoryId { get; set; }

 
}