using AutoMapper;
using MediatR;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public  async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var oldProduct = await _repository.GetByIdAsync(request.Id);

        if (oldProduct != null)
        {
            oldProduct.Id = request.Id;
            oldProduct.CategoryId = request.CategoryId;
            oldProduct.Name = request.Name;
            oldProduct.Stock = request.Stock;
            oldProduct.Price = request.Price;
            await  _repository.UpdateAsync(oldProduct);
        }
        return Unit.Value;
    }
}