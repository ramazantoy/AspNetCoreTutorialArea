﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Application.Features.CQRS.Queries;

namespace Project_9.Back.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
   private readonly IMediator _mediator;

   public ProductsController(IMediator mediator)
   {
      _mediator = mediator;
   }

   [HttpGet]
   public async Task<IActionResult> GetAll()
   {
      var result= await _mediator.Send(new GetAllProductsQueryRequest());
      return Ok(result);
   }

   [HttpGet("{id}")]
   public async Task<IActionResult> Get(int id)
   {
      var result = await _mediator.Send(new GetProductQueryRequest(id));
      return result==null ? NotFound(id) : Ok(result);
   }

   [HttpDelete("{id}")]
   public async Task<IActionResult> Delete(int id)
   { 
      await _mediator.Send(new DeleteProductCommandRequest(id));
      return NoContent();
   }

   [HttpPost]
   public async Task<IActionResult> Create(CreateProductCommandRequest request)
   {
      await _mediator.Send(request);
      return Created("",request);
   }

   [HttpPut]
   public async Task<IActionResult> Update(UpdateProductCommandRequest request)
   {
      await _mediator.Send(request);
      return NoContent();
   }

}