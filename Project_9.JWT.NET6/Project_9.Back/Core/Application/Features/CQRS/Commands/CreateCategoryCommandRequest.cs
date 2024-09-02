using MediatR;

namespace Project_9.Back.Core.Application.Features.CQRS.Commands;

public class CreateCategoryCommandRequest : IRequest
{
    public string? Definition { get; set; }
}