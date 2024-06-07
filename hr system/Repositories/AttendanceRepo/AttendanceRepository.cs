using hr_system.Data;
using hr_system.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_system.Repositories.AttendanceRepo
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly HrDbContext _context;

        public AttendanceRepository(HrDbContext context)
        {
            _context = context;
        }

        public void AddEmployeeAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void DeleteEmployeeAttendance(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }

        public List<Attendance> GetAll()
        {
            return _context.Attendances.Include(x => x.Employee).ThenInclude(x => x.Department).ToList();
        }

        public Attendance GetById(int id)
        {
            return _context.Attendances.Include(x => x.Employee).ThenInclude(x => x.Department).FirstOrDefault(x => x.Id == id);
        }

        public List<Attendance> GetEmployeeAttendanceByDate(DateTime startDate, DateTime endDate)
        {
            return _context.Attendances
                .Include(x=>x.Employee)
                .ThenInclude(x=>x.Department)
                .Where(x => x.Date.Date <= endDate.Date && x.Date.Date >= startDate.Date).ToList();
        }

        public List<Attendance> GetEmployeeByName(string name)
        {
            return _context.Attendances
                .Include(x=>x.Employee)
                .ThenInclude(x=>x.Department)
                .Where(x=>x.Employee.FirstName.Contains(name)).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEmployeeAttendance(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
        }
    }
}
