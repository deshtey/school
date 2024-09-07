using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using schoolapp.application.DTOs;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities.Other;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        // GET: api/<PermissionsController>
        [HttpGet]
        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            return await _permissionService.GetAllPermissions();
        }

      
        // POST api/<PermissionsController>/CreatePermission
        [HttpPost("CreatePermission")]
        public async Task<bool> CreatePermission([FromBody] Permission permission)
        {
            return await _permissionService.PostPermission(permission,cancellationToken:default);
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
