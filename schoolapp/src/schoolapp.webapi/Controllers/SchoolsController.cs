﻿using Azure.Core;
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
        public async Task<IActionResult> Get()
        {
            var res=  await _schoolService.GetSchools(cancellationToken);
            if(res.IsSuccess) return Ok(res.Value);
            return StatusCode(500, res.Value);
        }

        // GET api/<SchoolsController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "get_school")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _schoolService.GetSchool(id, cancellationToken);
            if(result.IsSuccess == false) return Ok(result.Value);
            return StatusCode(500, (result.Value));
        }

        // POST api/<SchoolsController>
        [HttpPost]
        //[Authorize(Policy = "post_school")]
        public async Task<IActionResult> Post([FromBody] SchoolDto request)
        {

            if (string.IsNullOrWhiteSpace(request.SchoolName))
                return BadRequest("School name is required");

            if (string.IsNullOrWhiteSpace(request.Email))
                return BadRequest("Email is required");

            if (string.IsNullOrWhiteSpace(request.Location))
                return BadRequest("Location is required");
            var res = await _schoolService.PostSchool(request, cancellationToken);
            if(res.IsSuccess) return CreatedAtAction("GetSchool", new { id = res.Value.Id }, res.Value);

            return StatusCode(500, res.Value);
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
