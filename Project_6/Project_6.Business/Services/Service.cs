using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Project_6.Business.Interfaces;
using Project_6.Common;
using Project_6.DataAccess.Interfaces;
using Project_6.Dtos.Interfaces;
using Project_6.Entities;

namespace Project_6.Business.Services
{
    public class Service<TCreateDto, TUpdateDto, TListDto,T> : IService<TCreateDto, TUpdateDto, TListDto,T>
        where TCreateDto : class, IDto, new() where TUpdateDto : class, IDto, new() where TListDto : class, IDto, new() where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<TCreateDto> _createDtoValidator;
        private readonly IValidator<TUpdateDto> _updateDtoValidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<TCreateDto> createDtoValidator, IValidator<TUpdateDto> updateDtoValidator, IUow uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }

        public async Task<IResponse<TCreateDto>> CreateAsync(TCreateDto dto)
        {
        
            //valid ? 
            //_uow.getRepo<>.create(_mapper(entity))
            //response<T> dto
            var result = _createDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
               await _uow.GetRepository<T>().CreateAsync(createdEntity);
               return new Response<TCreateDto>(ResponseType.Succes, dto);
            }
            //foreach for validation erros or using extension
            return new Response<TCreateDto>(dto, errors:new List<CustomValidationError>());
        }

        public Task<IResponse<TUpdateDto>> UpdateAsync(TUpdateDto updateDto)
        {
        }

        public Task<IResponse<IDto>> GetByIdAsync(int id)
        {
        }

        public Task<IResponse> RemoveAsync(int id)
        {
            ;
        }

        public Task<IResponse<List<TListDto>>> GetAllAsync()
        {
        }
    }
}