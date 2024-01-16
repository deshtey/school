using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly CancellationToken cancellationToken;

        public TeachersController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        // GET: api/<SchoolsController
        [HttpGet]
        public async Task<IEnumerable<School>> Get()
        {
            return await _schoolService.GetSchools();
        }

        // GET api/<SchoolsController>/5
        [HttpGet("{id}")]
        public async Task<School> Get(int id)
        {
            return await _schoolService.GetSchool(id);
        }

        // POST api/<SchoolsController>
        [HttpPost]
        public void Post([FromBody] School school)
        {
            _schoolService.PostSchool(school, cancellationToken);
        }

        // PUT api/<SchoolsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] School school)
        {
            _schoolService.PutSchool(id, school, cancellationToken);
        }

        // DELETE api/<SchoolsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _schoolService.DeleteSchool(id, cancellationToken);
        }
    }
}
