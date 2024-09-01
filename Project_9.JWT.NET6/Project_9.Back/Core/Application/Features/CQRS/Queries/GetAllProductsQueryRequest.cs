﻿using MediatR;
using Project_9.Back.Core.Application.Dto;

namespace Project_9.Back.Core.Application.Features.CQRS.Queries;

public class GetAllProductsQueryRequest : IRequest<List<ProductListDto>>
{
    
}