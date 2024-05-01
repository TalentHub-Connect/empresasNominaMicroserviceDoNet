using empresasNominaMicroserviceDoNet.Data;
using empresasNominaMicroserviceDoNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace empresasNominaMicroserviceDoNet.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EmpleadosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("obtener-empleados")]
        public async Task<IActionResult> getAllEmployees()
        {
            var allEmployees = await _appDbContext.employee.ToListAsync();
            return Ok(allEmployees);
        }

        [HttpGet("obtener-empleado/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _appDbContext.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost("agregar-empleado")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.employee.Add(employee);
                await _appDbContext.SaveChangesAsync();

                return Ok(employee);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("actualizar-empleado/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var existingEmployee = await _appDbContext.employee.FindAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Surname = employee.Surname;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            existingEmployee.NameEmergencyContact = employee.NameEmergencyContact;
            existingEmployee.EmergencyContact = employee.EmergencyContact;

            if (ModelState.IsValid)
            {
                await _appDbContext.SaveChangesAsync();
                return Ok(existingEmployee);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("eliminar-aspirante/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _appDbContext.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _appDbContext.employee.Remove(employee);

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
