using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly CancellationToken cancellationToken;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET: api/<DepartmentsController
        [HttpGet("{schoolId}")]
        public async Task<IEnumerable<DepartmentDto>> Get(int schoolId)
        {
            return await _departmentService.GetDepartments(schoolId);
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("department/{id}")]
        public async Task<DepartmentDto> GetDepartment(int id)
        {
            return await _departmentService.GetDepartment(id);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task Post([FromBody] DepartmentDto department)
        {
            await _departmentService.PostDepartment(department, cancellationToken);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] DepartmentDto department)
        {

            await _departmentService.PutDepartment(id, department, cancellationToken);
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _departmentService.DeleteDepartment(id, cancellationToken);
        }
    }
}
