using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_8.CQRS.CQRS.Queries;
using Project_8.CQRS.CQRS.Results;
using Project_8.CQRS.Data;

namespace Project_8.CQRS.CQRS.Handlers
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery,IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _context;

        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

        // public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery getStudentsQuery)
        // {
        //     return _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname })
        //         .AsNoTracking().AsEnumerable();
        // }


        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students
                .Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname })
                .AsNoTracking().ToListAsync();
        }
    }
}