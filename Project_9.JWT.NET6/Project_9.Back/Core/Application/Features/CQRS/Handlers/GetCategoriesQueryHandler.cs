using AutoMapper;
using MediatR;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Application.Features.CQRS.Queries;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest,List<CategoryListDto>>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<List<CategoryListDto>>(data);

    }
}