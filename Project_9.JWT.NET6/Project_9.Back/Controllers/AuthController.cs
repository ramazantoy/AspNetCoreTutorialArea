using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Application.Features.CQRS.Queries;
using Project_9.Back.Infrastructure.Tools;

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

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(CheckUserQueryRequest request)
    {
        var dto = await _mediator.Send(request);
        if (dto.IsExist)
        {
            return Created("", JwtTokenGenerator.GenerateToken(dto));
        }

        return BadRequest("username or password is wrong");
    }
}