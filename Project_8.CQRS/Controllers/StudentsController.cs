﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_8.CQRS.CQRS.Commands;
using Project_8.CQRS.CQRS.Handlers;
using Project_8.CQRS.CQRS.Queries;

namespace Project_8.CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        // private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        // private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        // private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        // private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;
        //
        // public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler,
        //     GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        // {
        //     _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        //     _getStudentsQueryHandler = getStudentsQueryHandler;
        //     _createStudentCommandHandler = createStudentCommandHandler;
        //     _removeStudentCommandHandler = removeStudentCommandHandler;
        //     _updateStudentCommandHandler = updateStudentCommandHandler;
        // }

        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            // var result = _getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // var result = _getStudentsQueryHandler.Handle(new GetStudentsQuery());
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand createStudentCommand)
        {
            // _createStudentCommandHandler.Handle(createStudentCommand);

            await _mediator.Send(createStudentCommand);
            return Created("", createStudentCommand.Name);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            //  _removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand updateStudentCommand)
        {
            // _updateStudentCommandHandler.Handle(updateStudentCommand);

            await _mediator.Send(updateStudentCommand);
            return NoContent();
        }
    }
}