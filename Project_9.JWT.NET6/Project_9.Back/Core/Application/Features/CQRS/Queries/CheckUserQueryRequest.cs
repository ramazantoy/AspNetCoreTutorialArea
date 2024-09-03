using MediatR;
using Project_9.Back.Core.Application.Dto;

namespace Project_9.Back.Core.Application.Features.CQRS.Queries;

public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}