using AutoMapper;
using MediatR;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Application.Features.CQRS.Queries;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest,List<ProductListDto>>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
       var data= await _repository.GetAllAsync();

       return _mapper.Map<List<ProductListDto>>(data);
    }
}