using hr_system.Data;
using hr_system.DTOS;
using hr_system.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_system.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HrDbContext _context;

        public EmployeeRepository(HrDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployee(Employee employee)
        {
            var general = new GeneralSettings
            {
                DiscountHour = 1,
                OverTimeHour = 1,
                Weekend1 = "Friday",
                Weekend2 = "Saturday"
            };
            employee.GeneralSettings=general;

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByDepartment(int deptID)
        {
            var emplloyees = await _context.Employees
                .Include(x => x.Department)
                .Where(x => x.DepartmentId == deptID)
                .Select(x => new EmployeeDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Country = x.Country,
                    City = x.Country,
                    Gender = x.Gender,
                    BirthDate = x.BirthDate,
                    Nationality = x.Nationality,
                    NationalId = x.NationalId,
                    HireDate = x.HireDate,
                    Salary = x.Salary,
                    ArrivalTime = x.ArrivalTime,
                    LeaveTime = x.LeaveTime,
                    UserId = x.UserId,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.Department.DeptName
                })
                .ToListAsync();

            return emplloyees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.Include(x=>x.Department).ToListAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
