using Project_8.CQRS.CQRS.Commands;
using Project_8.CQRS.Data;

namespace Project_8.CQRS.CQRS.Handlers
{
    public class CreateStudentCommandHandler
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
    }
}