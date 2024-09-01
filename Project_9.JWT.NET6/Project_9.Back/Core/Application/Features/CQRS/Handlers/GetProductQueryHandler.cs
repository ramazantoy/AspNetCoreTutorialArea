using AutoMapper;
using MediatR;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Application.Features.CQRS.Queries;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest,ProductListDto>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;
    public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

 

    public  async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
    {
        var data= await _repository.GetByIdAsync(request.Id);
       return _mapper.Map<ProductListDto>(data);
    }
}