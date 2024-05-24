using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Project_4.Business.Interfaces;
using Project_4.Business.ValidationRules;
using Project_4.Common.ResponseObjects;
using Project_4.DataAccess.UnitOfWork;
using Project_4.Dtos.WorkDtos;
using Project_4.Entities.Domains;

namespace Project_4.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;

        private readonly IMapper _mapper;

        private readonly IValidator<WorkCreateDto> _createDtoValidator;
        private readonly IValidator<WorkUpdateDto> _updateDtoValidator;

        public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator,
            IValidator<WorkUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
            // var list= await _uow.GetRepository<Work>().GetAll();
            // if (list == null || list.Count < 0)
            // {
            //     return null;
            // }
            //
            // return list.Select(work => new WorkListDto() { Definition = work.Definition, Id = work.Id, IsCompleted = work.IsCompleted }).ToList();

            var data = _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            var validationResult = await _createDtoValidator.ValidateAsync(dto);

            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _uow.SaveChanges();
                return new Response<WorkCreateDto>(ResponseType.Success, dto);
            }

            var customValidationErrors = new List<CustomValidationError>();
            foreach (var resultError in validationResult.Errors)
            {
                customValidationErrors.Add(new CustomValidationError
                {
                    ErrorMessage = resultError.ErrorMessage,
                    PropertyName = resultError.PropertyName
                });
            
            }

            return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, customValidationErrors);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));

            return data == null
                ? new Response<IDto>(ResponseType.NotFound, "Id object is not found")
                : new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);

            if (removedEntity == null)
            {
                return new Response(ResponseType.NotFound, "Id object is not found");
            }

            _uow.GetRepository<Work>().Remove(removedEntity);

            await _uow.SaveChanges();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {
            var result = await _updateDtoValidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Work>().Find(dto.Id);
                if (updatedEntity == null) return new Response<WorkUpdateDto>(ResponseType.NotFound, "Id object is not found");

                _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto), updatedEntity);

                await _uow.SaveChanges();
                return new Response<WorkUpdateDto>(ResponseType.Success,dto);
            }
            
            var customValidationErrors = new List<CustomValidationError>();
            foreach (var resultError in result.Errors)
            {
                customValidationErrors.Add(new CustomValidationError
                {
                    ErrorMessage = resultError.ErrorMessage,
                    PropertyName = resultError.PropertyName
                });
            }

            return new Response<WorkUpdateDto>(ResponseType.ValidationError,dto,customValidationErrors);
            
        }
    }
}