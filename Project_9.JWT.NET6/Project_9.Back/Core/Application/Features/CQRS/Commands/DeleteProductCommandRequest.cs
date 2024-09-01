using MediatR;

namespace Project_9.Back.Core.Application.Features.CQRS.Commands;

public class DeleteProductCommandRequest : IRequest
{
    public int Id { get; private set; }

    public DeleteProductCommandRequest(int id)
    {
        Id = id;
    }
}