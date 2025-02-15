using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize]
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
        //[Authorize(Policy = "get_schools")]
        public async Task<IEnumerable<SchoolDto>> Get()
        {
            return await _schoolService.GetSchools();
        }

        // GET api/<SchoolsController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "get_school")]
        public async Task<School> Get(int id)
        {
            return await _schoolService.GetSchool(id);
        }

        // POST api/<SchoolsController>
        [HttpPost]
        //[Authorize(Policy = "post_school")]
        public async Task Post([FromBody] SchoolDto school)
        {
            await _schoolService.PostSchool(school, cancellationToken);
        }

        // PUT api/<SchoolsController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "put_school")]

        public async Task Put(int id, [FromBody] SchoolDto school)
        {
            await _schoolService.PutSchool(id, school, cancellationToken);
        }

        // DELETE api/<SchoolsController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "delete_school")]

        public async Task Delete(int id)
        {
            await _schoolService.DeleteSchool(id, cancellationToken);
        }
    }
}
