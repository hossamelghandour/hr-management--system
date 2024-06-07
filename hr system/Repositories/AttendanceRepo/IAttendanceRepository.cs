using hr_system.Models;

namespace hr_system.Repositories.AttendanceRepo
{
    public interface IAttendanceRepository
    {
        List<Attendance> GetAll();
        Attendance GetById(int id);
        void AddEmployeeAttendance(Attendance attendance);
        void DeleteEmployeeAttendance(Attendance attendance);
        void UpdateEmployeeAttendance(Attendance attendance);
        List<Attendance> GetEmployeeByName(string name);
        List<Attendance> GetEmployeeAttendanceByDate(DateTime startDate,DateTime endDate);
        void Save();

    }
}
