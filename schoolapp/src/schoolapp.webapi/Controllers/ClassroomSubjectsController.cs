using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomSubjectsController : ControllerBase
    {
        private readonly IClassRoomSubjectService _ClassRoomSubjectservice;
        private readonly CancellationToken cancellationToken;

        public ClassRoomSubjectsController(IClassRoomSubjectService schoolSubjectservice)
        {
            _ClassRoomSubjectservice = schoolSubjectservice;
        }
        // GET: api/<ClassRoomSubjectsController
        [HttpGet("{schoolId}")]
        public async Task<IEnumerable<ClassRoomSubjectDto>> Get(int schoolId)
        {
            return await _ClassRoomSubjectservice.GetClassRoomSubjects(schoolId);
        }

        // GET api/<ClassRoomSubjectsController>/5
        [HttpGet("ClassRoomSubject/{id}")]
        public async Task<ClassRoomSubjectDto> GetClassRoomSubject(int id)
        {
            return await _ClassRoomSubjectservice.GetClassRoomSubject(id);
        }

        // POST api/<ClassRoomSubjectsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClassRoomSubjectDto schoolsubject)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _ClassRoomSubjectservice.PostClassRoomSubject(schoolsubject, cancellationToken);
            return Ok(schoolsubject);
        }

        // PUT api/<ClassRoomSubjectsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ClassRoomSubjectDto schoolsubject)
        {
            await _ClassRoomSubjectservice.PutClassRoomSubject(id, schoolsubject, cancellationToken);
        }

        // DELETE api/<ClassRoomSubjectsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ClassRoomSubjectservice.DeleteClassRoomSubject(id, cancellationToken);
        }
    }
}
