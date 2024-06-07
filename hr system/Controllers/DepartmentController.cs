using hr_system.Data;
using hr_system.Models;
using hr_system.Repositories.DepartmentRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hr_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly HrDbContext _Context;

        public DepartmentController(IDepartmentRepository departmentRepository
            , HrDbContext context)
        {
            _departmentRepository = departmentRepository;
            _Context = context;
        }

        [HttpGet("GetAllDepartments")]
        public IActionResult GetDepartments()
        {
            var Departments=_departmentRepository.GetAll();
            return Ok(Departments);
        }

        [HttpGet("GetDepartment/{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if(department == null)
            {
                return BadRequest($"This Department with ID : {id} not found");
            }

            return Ok(department);
        }

        [HttpPut("UpdateDepartment/{id}")]
        public IActionResult UpdateDepartment(int id,Department department)
        {
            department.Id = id;
            if(department.Id == null)
            {
                return BadRequest();
            }
            _departmentRepository.Update(department);
            return NoContent();
        }

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(Department department)
        {
            if (department == null)
                return BadRequest();
            _departmentRepository.Add(department);
            return Ok();
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department= _departmentRepository.GetById(id);
            if (department == null)
                return NotFound();
            _departmentRepository.Delete(department);
            return Ok();
        }
    }
}
