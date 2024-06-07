using hr_system.Models;
using hr_system.Repositories.EmployeeRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hr_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetEmpoyees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("GetAllDepartment")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartment()
        {
            var Departments = await _employeeRepository.GetDepartment();
            return Ok(Departments);
        }

        [HttpGet("GetEmpoyee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee=await _employeeRepository.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPut("PutEmployee/{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(int id,Employee employee)
        {
            employee.Id = id;
            if (employee.Id == null)
            {
                return BadRequest();
            }
            await _employeeRepository.UpdateEmployee(employee);
            return NoContent();

        }

        [HttpPost("PostEmployee")]
        public async Task<ActionResult<Employee>>PostEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new {id=employee.Id},employee);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            await _employeeRepository.DeleteEmployee(id);
            return NoContent();
        }

        [HttpGet]
        [Route("ByDept/{deptId}")]
        public async Task<IActionResult> GetEmployeesByDepartment(int deptId)
        {
            var employees=await _employeeRepository.GetEmployeesByDepartment(deptId); 
            return Ok(employees); 
        }


    }
}
