using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
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
        public async Task<IEnumerable<Grade>> Get(int schoolId)
        {
            return await _GradeService.GetSchoolClasses(schoolId);
        }

        // GET api/<GradesController>/5
        [HttpGet("Grade/{id}")]
        public async Task<Grade> GetGrade(int id)
        {
            return await _GradeService.GetGrade(id);
        }

        // POST api/<GradesController>
        [HttpPost]
        public async Task Post([FromBody] Grade school)
        {
            await _GradeService.PostGrade(school, cancellationToken);
        }

        // PUT api/<GradesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Grade school)
        {
            await _GradeService.PutGrade(id, school, cancellationToken);
        }

        // DELETE api/<GradesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _GradeService.DeleteGrade(id, cancellationToken);
        }
    }
}
