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
        private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        private readonly CreateStudentCommandHandler _createStudentCommandHandler;

        public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler,
            GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler)
        {
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
            _getStudentsQueryHandler = getStudentsQueryHandler;
            _createStudentCommandHandler = createStudentCommandHandler;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var result = _getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _getStudentsQueryHandler.Handle(new GetStudentsQuery());
            return Ok(result);
            
        }

        [HttpPost]
        public IActionResult Create(CreateStudentCommand createStudentCommand)
        {
            _createStudentCommandHandler.Handle(createStudentCommand);
            return Ok();
        }
    }
}