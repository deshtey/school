using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolSubjectsController : ControllerBase
    {
        private readonly ISchoolSubjectService _SchoolSubjectservice;
        private readonly CancellationToken cancellationToken;

        public SchoolSubjectsController(ISchoolSubjectService schoolSubjectservice)
        {
            _SchoolSubjectservice = schoolSubjectservice;
        }
        // GET: api/<SchoolSubjectsController
        [HttpGet("{schoolId}")]
        public async Task<IEnumerable<SchoolSubjectDto>> Get(int schoolId)
        {
            return await _SchoolSubjectservice.GetSchoolSubjects(schoolId);
        }

        // GET api/<SchoolSubjectsController>/5
        [HttpGet("SchoolSubject/{id}")]
        public async Task<SchoolSubjectDto> GetSchoolSubject(int id)
        {
            return await _SchoolSubjectservice.GetSchoolSubject(id);
        }

        // POST api/<SchoolSubjectsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SchoolSubjectDto schoolsubject)
        {        
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _SchoolSubjectservice.PostSchoolSubject(schoolsubject, cancellationToken);
            return Ok(schoolsubject);
        }

        // PUT api/<SchoolSubjectsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] SchoolSubjectDto schoolsubject)
        {
            await _SchoolSubjectservice.PutSchoolSubject(id, schoolsubject, cancellationToken);
        }

        // DELETE api/<SchoolSubjectsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _SchoolSubjectservice.DeleteSchoolSubject(id, cancellationToken);
        }
    }
}
