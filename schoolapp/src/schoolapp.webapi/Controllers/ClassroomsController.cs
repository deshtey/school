using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.ClassGrades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly IClassroomService _classroomService;
        private readonly CancellationToken cancellationToken;

        public ClassroomsController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        private int GetSchoolId()
        {
            var schoolIdClaim = User.FindFirst("school_id");
            if (schoolIdClaim == null || !int.TryParse(schoolIdClaim.Value, out var schoolId))
            {
                throw new UnauthorizedAccessException("School ID not found in user claims");
            }
            return schoolId;
        }
        // GET: api/<ClassroomsController
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> Get(int schoolId)
        {
            var result = await _classroomService.GetClassRooms(schoolId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET api/<ClassroomsController>/5
        [HttpGet("Classroom/{id}")]
        public async Task<IActionResult> GetClassroom(int id)
        {
            var schoolId = GetSchoolId();
            var result = await _classroomService.GetClassRoom(id, schoolId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<ClassroomsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClassRoom classroom)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var result = await _classroomService.PostClassRoom(classroom, cancellationToken);
            if (result == true) return CreatedAtAction("GetClassroom", new { id = classroom.Id }, classroom);
            return BadRequest();
        }

        // PUT api/<ClassroomsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClassRoom classroom)
        {
            var schoolId = GetSchoolId();
            var result = await _classroomService.PutClassRoom(id, classroom, schoolId, cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // DELETE api/<ClassroomsController>/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _classroomService.DeleteClassRoom(id, cancellationToken);
            if (result) return NoContent();
            return NotFound();
        }
    }
}
