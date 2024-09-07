using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using schoolapp.application.DTOs;
using schoolapp.Infrastructure.Security.RoleService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]

    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/<RolesController>
        [HttpGet]

        public IEnumerable<IdentityRole> GetRoles()
        {
            return _roleService.GetRoles();
        }

        // GET api/<RolesController>/5
        [HttpGet("{userId}")]
        public async Task<IEnumerable<string>> GetUserRoles(string userId)
        {
            return await _roleService.GetUserRolesAsync(userId);
        }
        // POST api/<RolesController>/CreateRole
        [HttpPost("CreateRole")]
        public async Task<bool> CreateRole([FromBody] string role)
        {
            return await _roleService.CreateRoleAsync(role);
        }

        // POST api/<RolesController>/AssignUserRole
        [HttpPost("AssignUserRole")]
        public async Task<bool> AssignUserRole([FromBody] UserRoleDto userRole)
        {
            return await _roleService.AssignRoleToUserAsync(userRole.UserId, userRole.Role);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserRoleDto userRole)
        {
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
