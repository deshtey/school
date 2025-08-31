using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomStudentController : ControllerBase
    {
        private readonly IClassroomStudentService _classroomStudentService;
        private readonly CancellationToken cancellationToken;

        public ClassroomStudentController(IClassroomStudentService classroomStudentService)
        {
            _classroomStudentService = classroomStudentService;
        }

        // GET: api/<ClassroomStudentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _classroomStudentService.GetClassRoomStudents();
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET api/<ClassroomStudentController>/5/10
        [HttpGet("{classroomId}/{studentId}")]
        public async Task<IActionResult> Get(int classroomId, int studentId)
        {
            var result = await _classroomStudentService.GetClassRoomStudent(classroomId, studentId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<ClassroomStudentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClassRoomStudentDto classroomStudent)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var result = await _classroomStudentService.PostClassRoomStudent(classroomStudent, cancellationToken);
            if (result == true) return CreatedAtAction("Get", new { classroomId = classroomStudent.ClassRoomId, studentId = classroomStudent.StudentId }, classroomStudent);
            return BadRequest();
        }

        // PUT api/<ClassroomStudentController>/5/10
        [HttpPut("{classroomId}/{studentId}")]
        public async Task<IActionResult> Put(int classroomId, int studentId, [FromBody] ClassRoomStudentDto classroomStudent)
        {
            var result = await _classroomStudentService.PutClassRoomStudent(classroomId, studentId, classroomStudent, cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // DELETE api/<ClassroomStudentController>/5/10
        [HttpDelete("{classroomId}/{studentId}")]
        public async Task<IActionResult> Delete(int classroomId, int studentId)
        {
            var result = await _classroomStudentService.DeleteClassRoomStudent(classroomId, studentId, cancellationToken);
            if (result) return NoContent();
            return NotFound();
        }
    }
}