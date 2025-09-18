using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly CancellationToken cancellationToken;

        public ExamController(IExamService examService)
        {
            _examService = examService;
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

        // GET: api/<ExamController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var schoolId = GetSchoolId();
            var result = await _examService.GetExams(schoolId, cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET api/<ExamController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var schoolId = GetSchoolId();
            var result = await _examService.GetExam(id, cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<ExamController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExamDto exam)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var result = await _examService.PostExam(exam, cancellationToken);
            if (result == true) return CreatedAtAction("Get", new { id = exam.Id }, exam);
            return BadRequest();
        }

        // PUT api/<ExamController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ExamDto exam)
        {
            var result = await _examService.PutExam(id, exam, cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _examService.DeleteExam(id, cancellationToken);
            if (result) return NoContent();
            return NotFound();
        }
    }
}