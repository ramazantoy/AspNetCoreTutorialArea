using AutoMapper;
using FluentValidation;
using Project_6.Business.Interfaces;
using Project_6.DataAccess.Interfaces;
using Project_6.Dtos.GenderDtos;
using Project_6.Entities;

namespace Project_6.Business.Services
{
    public class GenderService : Service<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>,IGenderService
    {
        public GenderService(IMapper mapper,IValidator<GenderCreateDto> createDtoValidator,
            IValidator<GenderUpdateDto> updateDtoValidator,
            IUow uow):base(mapper,createDtoValidator,updateDtoValidator,uow)
        
        {
            
        }
    }
}