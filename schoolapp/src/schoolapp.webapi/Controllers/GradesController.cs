using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly IGradeClassRoomService _ClassroomService;
        private readonly CancellationToken cancellationToken;

        public ClassroomsController(IGradeClassRoomService ClassroomService)
        {
            _ClassroomService = ClassroomService;
        }
        // GET: api/<ClassroomsController
        [HttpGet("{schoolId}")]
        public async Task<IEnumerable<ClassRoomDto>> Get(int schoolId)
        {
            return await _ClassroomService.GetSchoolClassRooms(schoolId);
        }

        // GET api/<ClassroomsController>/5
        [HttpGet("Classroom/{id}")]
        public async Task<ClassRoomDto> GetClassroom(int id)
        {
            return await _ClassroomService.GetClassRoom(id);
        }

        // POST api/<ClassroomsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClassRoomDto classroom)
        {        
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _ClassroomService.PostClassroom(classroom, cancellationToken);
            return Ok(classroom);
        }

        // PUT api/<ClassroomsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ClassRoomDto classroom)
        {
            await _ClassroomService.PutClassroom(id, classroom, cancellationToken);
        }

        // DELETE api/<ClassroomsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ClassroomService.DeleteClassroom(id, cancellationToken);
        }
    }
}
