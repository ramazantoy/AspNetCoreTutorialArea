using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_9.Back.Core.Application.Features.CQRS.Queries;

namespace Project_9.Back.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result= await _mediator.Send(new GetCategoriesQueryRequest());
      return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetCategoryQueryRequest(id));

        return result == null ? NotFound(id) : Ok(result);
        
    }
}