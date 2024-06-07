using hr_system.Data;
using hr_system.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hr_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryReportController : ControllerBase
    {
        private readonly HrDbContext _context;

        public SalaryReportController(HrDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetSalaryReport")]
        public List<SalaryReportDTO> GetSalaryReport()
        {
            var emps = _context.Employees.Include(x => x.Department).Include(x => x.Attendances).Include(x => x.GeneralSettings).ToList();
            var empsDtos = new List<SalaryReportDTO>();

            foreach (var item in emps)
            {
                int additionalHours = 0;
                int discountHours = 0;
                foreach (var item2 in item.Attendances)
                {
                    if (item2.LeavelTime == null)
                    {
                        additionalHours += 0;
                        discountHours += 0;
                    }
                    else
                    {
                        additionalHours += (int)item2.LeavelTime.Value.TotalHours - (int)item.LeaveTime.TotalHours;
                        discountHours += (int)item2.ArrivalTime.TotalHours - (int)item.ArrivalTime.TotalHours;
                    }
                }
                var absent = 22 - item.Attendances.Count();
                var totalAditionalHours = Math.Round((additionalHours * item.GeneralSettings.OverTimeHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);
                var totalDiscountHours = Math.Round((discountHours * item.GeneralSettings.DiscountHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);

                var salaryDto = new SalaryReportDTO()
                {
                    EmployeeName = item.FirstName + " " + item.LastName,
                    DepartmetName = item.Department.DeptName,
                    Salary = item.Salary,
                    Attend = item.Attendances.Count(),//Where(x => x.Date.Month == 2).Count();
                    Absent = absent,
                    Additional_hours = additionalHours,
                    Discount_hours = discountHours,
                    TotalAditionalHours = totalAditionalHours,
                    TotalDiscountHours = totalDiscountHours,
                    TotalNetSalary = Math.Round((((item.Salary / 22) * item.Attendances.Count()) + totalAditionalHours) - totalDiscountHours, 2)

                };

                empsDtos.Add(salaryDto);
            }


            return empsDtos;
        }

        [HttpGet("FilterSalaryReport")]
        public List<SalaryReportDTO> FilterSalaryReport(int month, int year)
        {
            var emps = _context.Attendances.Include(x => x.Employee).Include(x => x.Employee.Department).Include(x => x.Employee.GeneralSettings).Where(x => x.Date.Month == month && x.Date.Year == year).ToList();

            var empsDtos = new List<SalaryReportDTO>();

            foreach (var item in emps.Select(x => x.Employee))
            {
                int additionalHours = 0;
                int discountHours = 0;
                foreach (var item2 in item.Attendances)
                {
                    if (item2.LeavelTime == null)
                    {
                        additionalHours += 0;
                        discountHours += 0;
                    }
                    else
                    {
                        additionalHours += (int)item2.LeavelTime.Value.TotalHours - (int)item.LeaveTime.TotalHours;
                        discountHours += (int)item2.ArrivalTime.TotalHours - (int)item.ArrivalTime.TotalHours;
                    }
                }
                var absent = 22 - item.Attendances.Count();
                var totalAditionalHours = Math.Round((additionalHours * item.GeneralSettings.OverTimeHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);
                var totalDiscountHours = Math.Round((discountHours * item.GeneralSettings.DiscountHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);

                var salaryDto = new SalaryReportDTO()
                {
                    EmployeeName = item.FirstName + " " + item.LastName,
                    DepartmetName = item.Department.DeptName,
                    Salary = item.Salary,
                    Attend = item.Attendances.Count(),//Where(x => x.Date.Month == 2).Count();
                    Absent = absent,
                    Additional_hours = additionalHours,
                    Discount_hours = discountHours,
                    TotalAditionalHours = totalAditionalHours,
                    TotalDiscountHours = totalDiscountHours,
                    TotalNetSalary = Math.Round((((item.Salary / 22) * item.Attendances.Count()) + totalAditionalHours) - totalDiscountHours, 2)
                };

                empsDtos.Add(salaryDto);
            }


            return empsDtos;
        }
        [HttpGet("FilterSalaryReportByName")]
        public List<SalaryReportDTO> FilterSalaryReportByName(string name)
        {

            var emps = _context.Attendances.Include(x => x.Employee).Include(x => x.Employee.Department).Include(x => x.Employee.GeneralSettings).Where(x => x.Employee.FirstName.Contains(name)).ToList();

            var empsDtos = new List<SalaryReportDTO>();

            foreach (var item in emps.Select(x => x.Employee).Distinct())
            {
                int additionalHours = 0;
                int discountHours = 0;
                foreach (var item2 in item.Attendances)
                {
                    if (item2.LeavelTime == null)
                    {
                        additionalHours += 0;
                        discountHours += 0;
                    }
                    else
                    {
                        additionalHours += (int)item2.LeavelTime.Value.TotalHours - (int)item.LeaveTime.TotalHours;
                        discountHours += (int)item2.ArrivalTime.TotalHours - (int)item.ArrivalTime.TotalHours;
                    }
                }
                var absent = 22 - item.Attendances.Count();
                var totalAditionalHours = Math.Round((additionalHours * item.GeneralSettings.OverTimeHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);
                var totalDiscountHours = Math.Round((discountHours * item.GeneralSettings.DiscountHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);

                var salaryDto = new SalaryReportDTO()
                {
                    EmployeeName = item.FirstName + " " + item.LastName,
                    DepartmetName = item.Department.DeptName,
                    Salary = item.Salary,
                    Attend = item.Attendances.Count(),
                    Absent = absent,
                    Additional_hours = additionalHours,
                    Discount_hours = discountHours,
                    TotalAditionalHours = totalAditionalHours,
                    TotalDiscountHours = totalDiscountHours,
                    TotalNetSalary = Math.Round((((item.Salary / 22) * item.Attendances.Count()) + totalAditionalHours) - totalDiscountHours, 2)
                };

                empsDtos.Add(salaryDto);
            }


            return empsDtos;
        }
    }
}
