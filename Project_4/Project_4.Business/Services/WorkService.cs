using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_4.Business.Interfaces;
using Project_4.DataAccess.UnitOfWork;
using Project_4.Dtos.WorkDtos;
using Project_4.Entities.Domains;

namespace Project_4.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;

        public WorkService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<List<WorkListDto>> GetAll()
        {
           var list= await _uow.GetRepository<Work>().GetAll();
           if (list == null || list.Count < 0)
           {
               return null;
           }

           return list.Select(work => new WorkListDto() { Definition = work.Definition, Id = work.Id, IsCompleted = work.IsCompleted }).ToList();
        }

        public async Task Create(WorkCreateDto dto)
        {
           await _uow.GetRepository<Work>().Create(new Work()
            {
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted
            });
           await _uow.SaveChanges();
        }

        public  async Task<WorkListDto> GetById(int id)
        {
            var data = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
            return new()
            {
                Definition = data.Definition,
                IsCompleted = data.IsCompleted,
                Id = id
            };

        }

        public  async Task Remove(int id)
        {
            _uow.GetRepository<Work>().Remove(id);

            await _uow.SaveChanges();
        }

        public  async Task Update(WorkUpdateDto dto)
        {
            _uow.GetRepository<Work>().Update(new Work()
            {
                Definition = dto.Definition,
                Id = dto.Id,
                IsCompleted = dto.IsCompleted
            });
            await _uow.SaveChanges();
        }
    }
}