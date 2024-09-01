using MediatR;
using Microsoft.AspNetCore.Mvc;
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
}