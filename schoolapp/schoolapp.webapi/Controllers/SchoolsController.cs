using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Common.Security;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly CancellationToken cancellationToken;

        public SchoolsController(ISchoolService schoolService)
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
        public async Task Post([FromBody] School school)
        {
            await _schoolService.PostSchool(school, cancellationToken);
        }

        // PUT api/<SchoolsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] School school)
        {
            await _schoolService.PutSchool(id, school, cancellationToken);
        }

        // DELETE api/<SchoolsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _schoolService.DeleteSchool(id, cancellationToken);
        }
    }
}
