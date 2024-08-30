﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project_8.CQRS.CQRS.Commands;
using Project_8.CQRS.Data;

namespace Project_8.CQRS.CQRS.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
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

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedStudent=_context.Students.Find(request.Id);
            updatedStudent.Age =request.Age;
            updatedStudent.Name = request.Name;
            updatedStudent.Surname = request.Surname;
            await  _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
    
}