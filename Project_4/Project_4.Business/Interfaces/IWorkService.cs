using System.Collections.Generic;
using System.Threading.Tasks;
using Project_4.Dtos.WorkDtos;

namespace Project_4.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();
        
    }
}