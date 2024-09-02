using MediatR;
using Project_9.Back.Core.Application.Enums;
using Project_9.Back.Core.Application.Features.CQRS.Commands;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
{
    private readonly IRepository<AppUser> _repository;

    public RegisterUserCommandHandler(IRepository<AppUser> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new AppUser()
        {
            UserName = request.Username,
            Password = request.Password,
            AppRoleId =(int)RoleType.Member,
        });
        return Unit.Value;
    }
}