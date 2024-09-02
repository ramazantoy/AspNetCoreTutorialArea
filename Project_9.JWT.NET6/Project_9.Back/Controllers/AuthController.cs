using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_9.Back.Core.Application.Features.CQRS.Commands;

namespace Project_9.Back.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserCommandRequest request)
    {
       await _mediator.Send(request);
       return Created("", request);
    }
}