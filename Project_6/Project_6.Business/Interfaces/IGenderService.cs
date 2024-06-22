using Project_6.Dtos.GenderDtos;
using Project_6.Entities;

namespace Project_6.Business.Interfaces
{
    public interface IGenderService : IService<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>
    {
        
    }
}