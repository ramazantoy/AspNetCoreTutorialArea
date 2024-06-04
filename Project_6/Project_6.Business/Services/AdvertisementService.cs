using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Project_6.Business.Interfaces;
using Project_6.Common;
using Project_6.Common.Enums;
using Project_6.DataAccess.Interfaces;
using Project_6.Dtos.AdvertisementDtos;
using Project_6.Entities;

namespace Project_6.Business.Services
{
    public class AdvertisementService : Service<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Advertisement>,IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync()
        {
           var data=await _uow.GetRepository<Advertisement>().GetAllAsync(x => x.Status, x => x.CreatedTime, OrderByType.DESC);
           var dto = _mapper.Map<List<AdvertisementListDto>>(data);
           return new Response<List<AdvertisementListDto>>(ResponseType.Succes, dto);

        }
    }
}