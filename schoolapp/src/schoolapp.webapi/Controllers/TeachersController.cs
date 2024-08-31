using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
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
        [HttpGet("{schoolId}")]
        public async Task<IEnumerable<TeacherDto>> Get(int schoolId)
        {
            return await _teacherService.GetTeachers(schoolId);
        }

        // GET api/<TeachersController>/5
        [HttpGet("teacher/{id}")]
        public async Task<TeacherDto> GetTeacher(int id)
        {
            return await _teacherService.GetTeacher(id);
        }

        // POST api/<TeachersController>
        [HttpPost]
        public async Task Post([FromBody] TeacherDto teacher)
        {
            await _teacherService.PostTeacher(teacher, cancellationToken);
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TeacherDto teacher)
        {
            await _teacherService.PutTeacher(id, teacher, cancellationToken);
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _teacherService.DeleteTeacher(id, cancellationToken);
        }
    }
}
