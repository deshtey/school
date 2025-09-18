using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly CancellationToken cancellationToken;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
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
        // GET: api/<GradesController
        [HttpGet]
        public async Task<IActionResult> Get(int schoolId)
        {

            var result = await _gradeService.GetGrades(schoolId ,cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET api/<GradesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrade(int id)
        {
            var schoolId = GetSchoolId();
            var result = await _gradeService.GetGrade(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<GradesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GradeDto grade)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var result = await _gradeService.PostGrade(grade, cancellationToken);
            if (result == true) return CreatedAtAction("GetGrade", new { id = grade.Id }, grade);
            return BadRequest();
        }

        // PUT api/<GradesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GradeDto grade)
        {
            var result = await _gradeService.PutGrade(id, grade, cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // DELETE api/<GradesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gradeService.DeleteGrade(id, cancellationToken);
            if (result) return NoContent();
            return NotFound();
        }
    }
}
