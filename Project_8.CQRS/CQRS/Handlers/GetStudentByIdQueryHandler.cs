using Project_8.CQRS.CQRS.Queries;
using Project_8.CQRS.CQRS.Results;
using Project_8.CQRS.Data;

namespace Project_8.CQRS.CQRS.Handlers
{
    public class GetStudentByIdQueryHandler
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public GetStudentByIdQueryResult Handle(GetStudentByIdQuery getStudentByIdQuery)
        {
            var result = _context.Set<Student>().Find(getStudentByIdQuery.Id);

            return new GetStudentByIdQueryResult
            {
                Age = result.Age,
                Name = result.Name,
                Surname = result.Surname
            };
        }
    }
}