using Project_8.CQRS.CQRS.Commands;
using Project_8.CQRS.Data;

namespace Project_8.CQRS.CQRS.Handlers
{
    public class RemoveStudentCommandHandler
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
    }
}