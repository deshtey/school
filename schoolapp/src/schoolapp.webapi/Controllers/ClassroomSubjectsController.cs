using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace classroomapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomSubjectsController : ControllerBase
    {
        private readonly IClassRoomSubjectService _ClassRoomSubjectservice;
        private readonly CancellationToken cancellationToken;

        public ClassRoomSubjectsController(IClassRoomSubjectService classroomSubjectservice)
        {
            _ClassRoomSubjectservice = classroomSubjectservice;
        }
        // GET: api/<ClassRoomSubjectsController
        [HttpGet("{classroomId}")]
        public async Task<IEnumerable<ClassRoomSubjectDto>> Get(int classroomId)
        {
            return await _ClassRoomSubjectservice.GetClassRoomSubjects(classroomId);
        }

        // GET api/<ClassRoomSubjectsController>/5
        [HttpGet("ClassRoomSubject/{id}")]
        public async Task<ClassRoomSubjectDto> GetClassRoomSubject(int id)
        {
            return await _ClassRoomSubjectservice.GetClassRoomSubject(id);
        }

        // POST api/<ClassRoomSubjectsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClassRoomSubjectDto classroomsubject)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _ClassRoomSubjectservice.PostClassRoomSubject(classroomsubject, cancellationToken);
            return Ok(classroomsubject);
        }

        // PUT api/<ClassRoomSubjectsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ClassRoomSubjectDto classroomsubject)
        {
            await _ClassRoomSubjectservice.PutClassRoomSubject(id, classroomsubject, cancellationToken);
        }

        // DELETE api/<ClassRoomSubjectsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ClassRoomSubjectservice.DeleteClassRoomSubject(id, cancellationToken);
        }
    }
}
