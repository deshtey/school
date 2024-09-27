using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.ClassGrades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeClassRoomService _GradeService;
        private readonly CancellationToken cancellationToken;

        public GradesController(IGradeClassRoomService GradeService)
        {
            _GradeService = GradeService;
        }
        // GET: api/<GradesController
        [HttpGet("{schoolId}")]
        public async Task<IEnumerable<GradeDto>> Get(int schoolId)
        {
            return await _GradeService.GetSchoolClasses(schoolId);
        }

        // GET api/<GradesController>/5
        [HttpGet("Grade/{id}")]
        public async Task<GradeDto> GetGrade(int id)
        {
            return await _GradeService.GetGrade(id);
        }

        // POST api/<GradesController>
        [HttpPost]
        public async Task Post([FromBody] GradeDto grade)
        {
            await _GradeService.PostGrade(grade, cancellationToken);
        }

        // PUT api/<GradesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] GradeDto grade)
        {
            await _GradeService.PutGrade(id, grade, cancellationToken);
        }

        // DELETE api/<GradesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _GradeService.DeleteGrade(id, cancellationToken);
        }
    }
}
