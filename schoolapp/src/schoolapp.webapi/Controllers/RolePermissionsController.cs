using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.DTOs;
using schoolapp.Infrastructure.Security.RolePermissionService;

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionsController : ControllerBase
    {
        private readonly IRolePermissionService _rolePermissionService;

        public RolePermissionsController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }

        // GET: api/RolePermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolePermissionDto>>> GetRolePermissions()
        {
            return await _rolePermissionService.GetRolePermissions();
        }

        // PUT: api/RolePermissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolePermission(int id, RolePermissionDto rolePermission)
        {
            if (id != rolePermission.Id)
            {
                return BadRequest();
            }

            

            return NoContent();
        }

        // POST: api/RolePermissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolePermissionDto>> PostRolePermission(RolePermissionDto rolePermission)
        {
            await _rolePermissionService.CreateRolePermissionAsync(rolePermission);

            return CreatedAtAction("GetRolePermission", new { id = rolePermission.Id }, rolePermission);
        }

        // DELETE: api/RolePermissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolePermission(int id)
        {
            try
            {
                var res = await _rolePermissionService.DeleteRolePermissionAsync(id);
                if (res)
                {
                    return Ok(res);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return StatusCode(500,new { message="An error occured"});
            }
        }
    }
}
