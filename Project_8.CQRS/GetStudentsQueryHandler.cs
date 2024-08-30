using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project_8.CQRS.Data;

namespace Project_8.CQRS
{
    public class GetStudentsQueryHandler
    {
        private readonly StudentContext _context;

        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery getStudentsQuery)
        {
            return _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsNoTracking().AsEnumerable();
        }

    }
}