using MediatR;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Queries;

public class GetProductQueryRequest : IRequest<ProductListDto>
{

    public int Id { get;  private  set; }

    public GetProductQueryRequest(int id)
    {
        Id = id;
    }
}