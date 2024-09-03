using MediatR;
using Project_9.Back.Core.Application.Dto;
using Project_9.Back.Core.Application.Features.CQRS.Queries;
using Project_9.Back.Core.Application.Interfaces;
using Project_9.Back.Core.Domain;

namespace Project_9.Back.Core.Application.Features.CQRS.Handlers;

public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest,CheckUserResponseDto>
{
    private readonly IRepository<AppUser> _userRepository;
    private readonly IRepository<AppRole> _roleRepository;

    public CheckUserRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
    {
        var dto = new CheckUserResponseDto();
        var user = await _userRepository.GetByFilter(x => x.UserName == request.Username && x.Password == request.Password);

        if (user == null)
        {
            dto.IsExist = false;
        }
        else
        {
            dto.Username = user.UserName;
            dto.Id = user.Id;
            dto.IsExist = true;
            var role = await _roleRepository.GetByFilter(x => x.Id == user.AppRoleId);
            dto.Role = role?.Definition;
            
        }

        return dto;

    }
}