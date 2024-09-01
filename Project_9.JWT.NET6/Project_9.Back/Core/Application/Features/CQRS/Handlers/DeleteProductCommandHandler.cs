using MediatR;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
{
    private readonly IRepository<Product> _repository;

    public DeleteProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }


    public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var toDeleteEntry = await _repository.GetByIdAsync(request.Id);
        if (toDeleteEntry != null) await _repository.RemoveAsync(toDeleteEntry);
        return Unit.Value;
    }
}