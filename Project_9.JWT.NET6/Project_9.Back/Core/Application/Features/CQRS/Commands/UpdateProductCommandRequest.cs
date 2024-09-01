using MediatR;

namespace Project_9.Back.Core.Application.Features.CQRS.Commands;

public class UpdateProductCommandRequest : IRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public int  CategoryId { get; set; }
}