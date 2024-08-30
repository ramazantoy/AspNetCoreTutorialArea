using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project_8.CQRS.CQRS.Commands;
using Project_8.CQRS.Data;

namespace Project_8.CQRS.CQRS.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _context;

        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public void Handle(CreateStudentCommand createStudentCommand)
        {
            _context.Students.Add(new Student()
            {
                Age = createStudentCommand.Age,
                Name = createStudentCommand.Name,
                Surname = createStudentCommand.Surname,
            });
            _context.SaveChanges();
        }

        public  async  Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _context.Students.Add(new Student()
            {
                Age = request.Age,
                Name = request.Name,
                Surname =request.Surname,
            });
           await _context.SaveChangesAsync(cancellationToken);
           return Unit.Value;
        }
    }
}