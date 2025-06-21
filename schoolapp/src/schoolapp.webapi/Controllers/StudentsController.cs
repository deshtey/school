using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.DTOs;
using schoolapp.Application.Contracts;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _StudentService;
        private readonly IParentService _parentService;
        private readonly CancellationToken cancellationToken;

        public StudentsController(IStudentService StudentService)
        {
            _StudentService = StudentService;
        }
        // GET: api/<StudentsController
        [HttpGet("{schoolId}")]
        public async Task<IEnumerable<StudentDto>> Get(int schoolId)
        {
            return await _StudentService.GetStudents(schoolId);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{schoolId}/{id}")]
        public async Task<StudentParentDto> Get(int schoolId, int id)
        {
            return await _StudentService.GetStudent(id, schoolId);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task Post([FromBody] StudentParentDto studentParentDto)
        {
            //TODO This should be a transaction

            var student =  await _StudentService.CreateStudentAsync(studentParentDto, cancellationToken);
           //await _parentService.PostParents(studentParentDto.ParentsDto, cancellationToken);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] StudentParentDto studentParentDto)
        {
            await _StudentService.PutStudent(id, studentParentDto, cancellationToken);
            await _parentService.PutParents(studentParentDto.ParentsDto, cancellationToken);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _StudentService.DeleteStudent(id, cancellationToken);
        }
    }
}
