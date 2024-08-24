using Microsoft.AspNetCore.Mvc;

namespace Project_7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        //api/GetProducts
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new[] { new { Name = "Computer", Price = 3500 }, new { Name = "Phone", Price = 1000 } });
        }

        //api/GetProducts/1
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(new[] { new { Name = "Computer", Price = 3500 } } );
        }
    }
}