﻿using MediatR;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
{
    private readonly IRepository<Category> _repository;

    public CreateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public  async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Category()
        {
            Definition = request.Definition
        });
        return Unit.Value;
    }
}