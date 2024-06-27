using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Project_6.Business.Extensions;
using Project_6.Business.Interfaces;
using Project_6.Common;
using Project_6.DataAccess.Interfaces;
using Project_6.Dtos.AppUserDtos;
using Project_6.Entities;

namespace Project_6.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<AppUserCreateDto> _createValidator;
        private readonly IValidator<AppUserLoginDto> _loginValidator;

        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator,
            IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserCreateDto> createValidator,
            IValidator<AppUserLoginDto> loginValidator)
            : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _loginValidator = loginValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto createDto, int roleId)
        {
            var validationResult = await _createValidator.ValidateAsync(createDto);

            if (!validationResult.IsValid)
                return new Response<AppUserCreateDto>(createDto, validationResult.ConvertToCustomValidationError());


            var mappedUser = _mapper.Map<AppUser>(createDto);
            mappedUser.AppUserRoles = new List<AppUserRole>
            {
                new()
                {
                    AppUser = mappedUser,
                    AppRoleId = roleId,
                }
            };
            await _uow.GetRepository<AppUser>().CreateAsync(mappedUser);

            await _uow.SaveChanges();
            return new Response<AppUserCreateDto>(ResponseType.Succes, createDto);
        }

        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto appUserLoginDto)
        {
            var validationResult = await _loginValidator.ValidateAsync(appUserLoginDto);

            if (!validationResult.IsValid)
                return new Response<AppUserListDto>(ResponseType.ValidationError,
                    "Username or password is must not empty. ");


            var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x =>
                x.UserName == appUserLoginDto.UserName && x.Password == appUserLoginDto.Password);

            if (user == null)
                return new Response<AppUserListDto>(ResponseType.NotFound, "Username or password not correct");

            var appUserDto = _mapper.Map<AppUserListDto>(user);

            return new Response<AppUserListDto>(ResponseType.Succes, appUserDto);
        }
    }
}