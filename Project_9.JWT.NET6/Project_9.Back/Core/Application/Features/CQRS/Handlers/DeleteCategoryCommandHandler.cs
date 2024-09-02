using MediatR;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
{
    private readonly IRepository<Category> _repository;

    public DeleteCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public  async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var toDeleteEntity = await _repository.GetByIdAsync(request.Id);
        if (toDeleteEntity != null)
        {
           await _repository.RemoveAsync(toDeleteEntity);
        }

        return Unit.Value;
    }
}