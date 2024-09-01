using AutoMapper;
using MediatR;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async  Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
       await _repository.CreateAsync(_mapper.Map<Product>(request));
       return  Unit.Value;
       
    }
}