using hr_system.DTOS;
using hr_system.Models;
using hr_system.Repositories.AttendanceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hr_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var attens=_attendanceRepository.GetAll();
            List<AttendanceDTO> attDtos = new List<AttendanceDTO>();

            foreach (var att in attens)
            {
                var attDto = new AttendanceDTO()
                {
                    Id=att.Id,
                    Date = new DateOnly(att.Date.Year, att.Date.Month, att.Date.Day),
                    ArrivalTime=att.ArrivalTime,
                    LeaveTime=att.LeavelTime,
                    employeeId=att.EmployeeId,
                    EmployeeName=att.Employee.FirstName,
                    DepartmentName=att.Employee.Department.DeptName
                };
                attDtos.Add(attDto);
            }

            return Ok(attDtos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var att=_attendanceRepository.GetById(id);
            var attDto = new AttendanceDTO()
            {
                Id = att.Id,
                Date = new DateOnly(att.Date.Year, att.Date.Month, att.Date.Day),
                ArrivalTime = att.ArrivalTime,
                LeaveTime = att.LeavelTime,
                employeeId = att.EmployeeId,
                EmployeeName = att.Employee.FirstName,
                DepartmentName = att.Employee.Department.DeptName
            };

            return Ok(attDto);
        }

        [HttpPut("AddEmployeAttendance")]
        public IActionResult AddEmployeAttendance(Attendance attendance)
        {
            if (attendance == null)
                return BadRequest();
            _attendanceRepository.AddEmployeeAttendance(attendance);
            _attendanceRepository.Save();
            return Ok();
        }
         
        [HttpPost("EditEmployeeAttedance/{id}")]
        public IActionResult EditEmployeeAttedance(int id,Attendance attendance)
        {
            attendance.Id = id;
            if(attendance==null)
                return BadRequest("Attendace Not Found");
            _attendanceRepository.UpdateEmployeeAttendance(attendance);
            _attendanceRepository.Save();
            return Ok();
        }

        [HttpGet("GetAmployeeAttendanceByDate")]
        public List<AttendanceDTO> GetAmployeeAttendanceByDate(DateTime startDate,DateTime endDate)
        {
            var attendances = _attendanceRepository.GetEmployeeAttendanceByDate(startDate, endDate);
            List<AttendanceDTO> attDtos = new List<AttendanceDTO>();
            foreach (var item in attendances)
            {
                var attDto = new AttendanceDTO()
                {
                    Id = item.Id,
                    Date = new DateOnly(item.Date.Year, item.Date.Month, item.Date.Day),
                    ArrivalTime = item.ArrivalTime,
                    LeaveTime = item.LeavelTime,
                    employeeId = item.EmployeeId,
                    EmployeeName = item.Employee.FirstName,
                    DepartmentName = item.Employee.Department.DeptName
                };
                attDtos.Add(attDto);
            }
            return attDtos;
        }

        [HttpGet("GetEmployeeAttendanceByName")]
        public List<AttendanceDTO> GetEmployeeAttendanceByName(string name)
        {
            var attendances = _attendanceRepository.GetEmployeeByName(name);
            List<AttendanceDTO> attDtos = new List<AttendanceDTO>();
            foreach (var item in attendances)
            {
                var attDto = new AttendanceDTO()
                {
                    Id = item.Id,
                    Date = new DateOnly(item.Date.Year, item.Date.Month, item.Date.Day),
                    ArrivalTime = item.ArrivalTime,
                    LeaveTime = item.LeavelTime,
                    employeeId = item.EmployeeId,
                    EmployeeName = item.Employee.FirstName,
                    DepartmentName = item.Employee.Department.DeptName
                };
                attDtos.Add(attDto);
            }
            return attDtos;
        }

        [HttpDelete("DeleteEmployeeAttendance/{id}")]
        public IActionResult DeleteEmployeeAttendance(int id)
        {
            var attendance = _attendanceRepository.GetById(id);
            if (attendance == null)
                return BadRequest();
            _attendanceRepository.DeleteEmployeeAttendance(attendance);
            _attendanceRepository.Save();
            return Ok();
        }
    }
}
