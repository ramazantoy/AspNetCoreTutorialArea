using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_4.Dtos.Interfaces;
using Project_4.Dtos.WorkDtos;
using Project_4.Entities.Domains;

namespace Project_4.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();

        Task Create(WorkCreateDto dto);

        Task<IDto> GetById<IDto>(int id);

        Task Remove(int id);

        Task Update(WorkUpdateDto dto);
    }
}