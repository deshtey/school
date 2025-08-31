using Microsoft.AspNetCore.Mvc;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;

namespace schoolapp.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly CancellationToken cancellationToken;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        // GET: api/<DriverController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _driverService.GetDrivers();
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _driverService.GetDriver(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<DriverController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupportStaffDto driver)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var result = await _driverService.PostDriver(driver, cancellationToken);
            if (result == true) return CreatedAtAction("Get", new { id = driver.Id }, driver);
            return BadRequest();
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SupportStaffDto driver)
        {
            var result = await _driverService.PutDriver(id, driver, cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _driverService.DeleteDriver(id, cancellationToken);
            if (result) return NoContent();
            return NotFound();
        }
    }
}