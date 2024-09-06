using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace staffapp.webapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly ISupportStaffService _staffService;
        private readonly CancellationToken cancellationToken;

        public StaffController(ISupportStaffService staffService)
        {
            _staffService = staffService;
        }
        // GET: api/<SupportStaffController>/schoolId
        [HttpGet("{schoolId}")]
        public async Task<IEnumerable<SupportStaffDto>> GetAllStaff(int schoolId)
        {
            return await _staffService.GetSupportStaffs(schoolId);
        }

        // GET api/<SupportStaffController>/5
        [HttpGet("staff/{id}")]
        public async Task<SupportStaffDto> GetStaff(int id)
        {
            return await _staffService.GetSupportStaff(id);
        }

        // POST api/<SupportStaffController>
        [HttpPost]
        public async Task Post([FromBody] SupportStaffDto staff)
        {
            await _staffService.PostSupportStaff(staff, cancellationToken);
        }

        // PUT api/<SupportStaffController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] SupportStaffDto staff)
        {
            await _staffService.PutSupportStaff(id, staff, cancellationToken);
        }

        // DELETE api/<SupportStaffController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _staffService.DeleteSupportStaff(id, cancellationToken);
        }
    }
}
