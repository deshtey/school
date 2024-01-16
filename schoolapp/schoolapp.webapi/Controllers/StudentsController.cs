using Microsoft.AspNetCore.Mvc;
using Studentapp.Application.Contracts;
using Studentapp.Application.Contracts;
using schoolapp.Domain.Entities.People;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Studentapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _StudentService;
        private readonly CancellationToken cancellationToken;

        public StudentsController(IStudentService StudentService)
        {
            _StudentService = StudentService;
        }
        // GET: api/<StudentsController
        [HttpGet]
        public async Task<IEnumerable<Student>> Get(int schoolId)
        {
            return await _StudentService.GetStudents(schoolId);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<Student> Get(int id, int schoolId)
        {
            return await _StudentService.GetStudent(id, schoolId);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student Student)
        {
            _StudentService.PostStudent(Student, cancellationToken);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student Student)
        {
            _StudentService.PutStudent(id, Student, cancellationToken);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _StudentService.DeleteStudent(id, cancellationToken);
        }
    }
}
