using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectsController : ControllerBase
    {
        private readonly IStudentSubjectService _StudentSubjectservice;
        private readonly CancellationToken cancellationToken;

        public StudentSubjectsController(IStudentSubjectService schoolSubjectservice)
        {
            _StudentSubjectservice = schoolSubjectservice;
        }
        // GET: api/<StudentSubjectsController
        [HttpGet("{schoolId}")]
        public async Task<IEnumerable<StudentSubjectDto>> Get(int schoolId)
        {
            return await _StudentSubjectservice.GetStudentSubjects(schoolId);
        }

        // GET api/<StudentSubjectsController>/5
        [HttpGet("StudentSubject/{id}")]
        public async Task<StudentSubjectDto> GetStudentSubject(int id)
        {
            return await _StudentSubjectservice.GetStudentSubject(id);
        }

        // POST api/<StudentSubjectsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentSubjectDto schoolsubject)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _StudentSubjectservice.PostStudentSubject(schoolsubject, cancellationToken);
            return Ok(schoolsubject);
        }

        // PUT api/<StudentSubjectsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] StudentSubjectDto schoolsubject)
        {
            await _StudentSubjectservice.PutStudentSubject(id, schoolsubject, cancellationToken);
        }

        // DELETE api/<StudentSubjectsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _StudentSubjectservice.DeleteStudentSubject(id, cancellationToken);
        }
    }
}
