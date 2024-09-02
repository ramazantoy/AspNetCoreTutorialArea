using MediatR;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Queries;

public class GetCategoryQueryRequest : IRequest<CategoryListDto?>
{
    public int Id { get; private set; }

    public GetCategoryQueryRequest(int id)
    {
        Id = id;
    }
}