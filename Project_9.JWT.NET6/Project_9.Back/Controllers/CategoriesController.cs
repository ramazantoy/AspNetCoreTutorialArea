using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Application.Features.CQRS.Queries;

namespace Project_9.Back.Controllers;

[Authorize(Roles = "Admin")]
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
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetCategoryQueryRequest(id));

        return result == null ? NotFound(id) : Ok(result);
        
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
    {
        await _mediator.Send(request);

        return Created("",request);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
    {
        await _mediator.Send(request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCategoryCommandRequest(id));
        return Ok();
    }
    
}