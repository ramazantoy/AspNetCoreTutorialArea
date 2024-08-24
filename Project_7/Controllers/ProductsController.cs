using Microsoft.AspNetCore.Mvc;

namespace Project_7.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new[] { new { Name = "Computer", Price = 3500 }, new { Name = "Phone", Price = 1000 } });
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new[] { new { Name = "Computer", Price = 3500 } } );
        }
    }
}