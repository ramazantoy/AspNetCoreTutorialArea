using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_4.Common.ResponseObjects;
using Project_4.Dtos.Interfaces;
using Project_4.Dtos.WorkDtos;
using Project_4.Entities.Domains;

namespace Project_4.Business.Interfaces
{
    public interface IWorkService
    {
        Task<IResponse<List<WorkListDto>>>GetAll();

        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);

        Task<IResponse<IDto>> GetById<IDto>(int id);

        Task <IResponse> Remove(int id);

        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);
    }
}