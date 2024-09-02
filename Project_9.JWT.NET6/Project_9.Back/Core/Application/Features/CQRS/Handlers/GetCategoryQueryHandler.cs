using AutoMapper;
using MediatR;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Application.Features.CQRS.Queries;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest,CategoryListDto>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByFilter(x => x.Id == request.Id);

        return _mapper.Map<CategoryListDto>(result);
    }
}