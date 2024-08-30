using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project_8.CQRS.CQRS.Commands;
using Project_8.CQRS.Data;

namespace Project_8.CQRS.CQRS.Handlers
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _context;

        public RemoveStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public void Handle(RemoveStudentCommand removeStudentCommand)
        {
            var toDeleteEntity = _context.Students.Find(removeStudentCommand.Id);
            _context.Students.Remove(toDeleteEntity);
            _context.SaveChanges();
        }

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var toDeleteEntity = _context.Students.Find(request.Id);
            _context.Students.Remove(toDeleteEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}