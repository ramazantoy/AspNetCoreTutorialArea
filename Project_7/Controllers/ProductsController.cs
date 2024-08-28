using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_7.Data;
using Project_7.Interfaces;

namespace Project_7.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /*
        //api/GetProducts
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new[] { new { Name = "Computer", Price = 3500 }, new { Name = "Phone", Price = 1000 } });
        }
        */
        
        /*
        //api/GetProducts/1
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(new[] { new { Name = "Computer", Price = 3500 } });
        }
        */

        
        //ok(200),NotFound(404),NoContent(204),Created(201),BadRequest(401)
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =await _productRepository.GetAllAsync();
            return Ok(result);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data=await _productRepository.GetProductById(id);

            if (data == null)
            {
                return NotFound(id);
            }

            return Ok(data);

        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var addedProduct =await _productRepository.CreateAsync(product);
            return Created(String.Empty, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var checkProduct = _productRepository.GetProductById(product.Id);
            if (checkProduct == null)
            {
                return NotFound(product.Id);
            }

            await _productRepository.UpdateAsync(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var checkProduct = _productRepository.GetProductById(id);
            if (checkProduct == null)
            {
                return NotFound(id);
            }

            await _productRepository.RemoveAsync(id);

            return NoContent();
        }

        //api/products/upload
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm]IFormFile formFile)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created(string.Empty, formFile);
        }
    }
}