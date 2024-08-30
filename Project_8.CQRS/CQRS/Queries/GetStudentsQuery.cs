using System.Collections;
using System.Collections.Generic;
using MediatR;
using Project_8.CQRS.CQRS.Results;

namespace Project_8.CQRS.CQRS.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}