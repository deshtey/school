using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities.Academics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicYearController : ControllerBase
    {
        private readonly IAcademicYearService _academicYearService;
        public AcademicYearController(IAcademicYearService academicYearService)
        {
            _academicYearService = academicYearService;
        }
        // GET: api/<AcademicYearController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _academicYearService.CreateAcademicYear(2, new DateOnly(2025, 1, 1),  new DateOnly(2026, 1, 1), cancellationToken: default);
            if(res.IsSuccess) return Ok(res.Value);
            return StatusCode(500, res.Value);
        }

        // GET api/<AcademicYearController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AcademicYearController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AcademicYearController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AcademicYearController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
