using System.Collections.Generic;
using System.Threading.Tasks;
using Project_6.Common;
using Project_6.Dtos.Interfaces;
using Project_6.Dtos.ProvidedServiceDtos;
using Project_6.Entities;

namespace Project_6.Business.Interfaces
{
    public interface IService<TCreateDto, TUpdateDto, TListDto, T>
        where TCreateDto : class, IDto, new()
        where TUpdateDto : class, IDto, new()
        where TListDto : class, IDto, new()
        where T : BaseEntity
    {
        Task<IResponse<TCreateDto>> CreateAsync(TCreateDto dto);

        Task<IResponse<TUpdateDto>> UpdateAsync(TUpdateDto updateDto);

        Task<IResponse<IDto>> GetByIdAsync(int id);

        Task<IResponse> RemoveAsync(int id);

        Task<IResponse<List<TListDto>>> GetAllAsync();
    }
}