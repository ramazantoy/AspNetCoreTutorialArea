using MediatR;

namespace Project_8.CQRS.CQRS.Commands
{
    public class UpdateStudentCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}