using MediatR;
using Project_8.CQRS.CQRS.Results;

namespace Project_8.CQRS.CQRS.Queries
{
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}