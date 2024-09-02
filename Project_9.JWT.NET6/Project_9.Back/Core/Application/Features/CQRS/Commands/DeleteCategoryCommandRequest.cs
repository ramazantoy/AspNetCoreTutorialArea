using MediatR;

namespace Project_9.Back.Core.Application.Features.CQRS.Commands;

public class DeleteCategoryCommandRequest : IRequest
{
    public int Id { get; private set; }

    public DeleteCategoryCommandRequest(int id)
    {
        Id = id;
    }
}