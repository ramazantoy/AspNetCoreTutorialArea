using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Project_6.Business.Extensions;
using Project_6.Business.Interfaces;
using Project_6.Common;
using Project_6.DataAccess.Interfaces;
using Project_6.Dtos.Interfaces;
using Project_6.Entities;

namespace Project_6.Business.Services
{
    public class Service<TCreateDto, TUpdateDto, TListDto, T> : IService<TCreateDto, TUpdateDto, TListDto, T>
        where TCreateDto : class, IDto, new()
        where TUpdateDto : class, IUpdateDto, new()
        where TListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<TCreateDto> _createDtoValidator;
        private readonly IValidator<TUpdateDto> _updateDtoValidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<TCreateDto> createDtoValidator,
            IValidator<TUpdateDto> updateDtoValidator, IUow uow)
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
            var result = await _createDtoValidator.ValidateAsync(dto);

            //foreach for validation errors or using extension
            if (!result.IsValid) return new Response<TCreateDto>(dto, errors: result.ConvertToCustomValidationError());

            var createdEntity = _mapper.Map<T>(dto);
            await _uow.GetRepository<T>().CreateAsync(createdEntity);
            await _uow.SaveChanges();
            return new Response<TCreateDto>(ResponseType.Succes, dto);
        }

        public async Task<IResponse<TUpdateDto>> UpdateAsync(TUpdateDto dto)
        {

            var result = await _updateDtoValidator.ValidateAsync(dto);

            if (!result.IsValid) return new Response<TUpdateDto>(dto, result.ConvertToCustomValidationError());
            
            var unChangedData= await _uow.GetRepository<T>().FindAsync(dto.Id);
            if (unChangedData == null)
            {
                return new Response<TUpdateDto>(ResponseType.NotFound, "data is not found by id");
            }

            var entity = _mapper.Map<T>(dto);
            _uow.GetRepository<T>().Update(entity,unChangedData);
            await _uow.SaveChanges();

            return new Response<TUpdateDto>(ResponseType.Succes, dto);

        }

        public async Task<IResponse<IDto>> GetByIdAsync(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data == null) return new Response<IDto>(ResponseType.NotFound, "data is not found by id");

            var dto = _mapper.Map<IDto>(data);
            return new Response<IDto>(ResponseType.Succes, dto);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data == null) return new Response<IDto>(ResponseType.NotFound, "data is not found by id");

            _uow.GetRepository<T>().Remove(data);
            await _uow.SaveChanges();

            return new Response(ResponseType.Succes);
        }

        public async Task<IResponse<List<TListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<TListDto>>(data);
            return new Response<List<TListDto>>(ResponseType.Succes, dto);
        }
    }
}