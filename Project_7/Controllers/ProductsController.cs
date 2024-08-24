﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_7.Data;
using Project_7.Interfaces;

namespace Project_7.Controllers
{
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =await _productRepository.GetAllAsync();
            return Ok(result);
        }
        
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
    }
}