using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project_4.Business.Interfaces;
using Project_4.DataAccess.UnitOfWork;
using Project_4.Dtos.WorkDtos;
using Project_4.Entities.Domains;

namespace Project_4.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;

        private readonly IMapper _mapper;

        public WorkService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<WorkListDto>> GetAll()
        {
           // var list= await _uow.GetRepository<Work>().GetAll();
           // if (list == null || list.Count < 0)
           // {
           //     return null;
           // }
           //
           // return list.Select(work => new WorkListDto() { Definition = work.Definition, Id = work.Id, IsCompleted = work.IsCompleted }).ToList();

          return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
           await _uow.SaveChanges();
        }

        public  async Task<WorkListDto> GetById(int id)
        {
       
            return _mapper.Map<WorkListDto>( await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));

        }

        public  async Task Remove(int id)
        {
            _uow.GetRepository<Work>().Remove(id);

            await _uow.SaveChanges();
        }

        public  async Task Update(WorkUpdateDto dto)
        {
            _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto));
          
            await _uow.SaveChanges();
        }
    }
}