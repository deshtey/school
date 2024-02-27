using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities.People;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly CancellationToken cancellationToken;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        // GET: api/<TeachersController
        [HttpGet]
        public async Task<IEnumerable<Teacher>> Get()
        {
            return await _teacherService.GetTeachers();
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public async Task<Teacher> Get(int id)
        {
            return await _teacherService.GetTeacher(id);
        }

        // POST api/<TeachersController>
        [HttpPost]
        public async Task Post([FromBody] Teacher school)
        {
            await _teacherService.PostTeacher(school, cancellationToken);
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Teacher school)
        {
            await _teacherService.PutTeacher(id, school, cancellationToken);
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _teacherService.DeleteTeacher(id, cancellationToken);
        }
    }
}
