using hr_system.DTOS;
using hr_system.Models;

namespace hr_system.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Department>> GetDepartment();
        Task<Employee> GetEmployeeById(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task<IEnumerable<EmployeeDTO>> GetEmployeesByDepartment(int deptID);


    }
}
