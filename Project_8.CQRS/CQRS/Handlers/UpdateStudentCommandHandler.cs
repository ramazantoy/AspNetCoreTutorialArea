using Project_8.CQRS.CQRS.Commands;
using Project_8.CQRS.Data;

namespace Project_8.CQRS.CQRS.Handlers
{
    public class UpdateStudentCommandHandler
    {
        private readonly StudentContext _context;

        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public void Handle(UpdateStudentCommand command)
        {
            var updatedStudent=_context.Students.Find(command.Id);
            updatedStudent.Age = command.Age;
            updatedStudent.Name = command.Name;
            updatedStudent.Surname = command.Surname;

            _context.SaveChanges();
        }
    }
    
}