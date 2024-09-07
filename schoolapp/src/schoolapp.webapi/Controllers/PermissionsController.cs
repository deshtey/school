using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using schoolapp.application.DTOs;
using schoolapp.Domain.Entities.Other;
using schoolapp.Infrastructure.Security.PermissionService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        // GET: api/<PermissionsController>
        [HttpGet]
        public IEnumerable<Permission> GetPermissions()
        {
            return _permissionService.GetPermissions();
        }

        // GET api/<PermissionsController>/5
        [HttpGet("{userId}")]
        public async Task<IEnumerable<string>> GetUserPermissions(string userId)
        {
            return await _permissionService.GetUserPermissionsAsync(userId);
        }
        // POST api/<PermissionsController>/CreatePermission
        [HttpPost("CreatePermission")]
        public async Task<bool> CreatePermission([FromBody] string permission)
        {
            return await _permissionService.CreatePermissionAsync(permission);
        }

    

        // PUT api/<PermissionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Permission userPermission)
        {
        }

        // DELETE api/<PermissionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
