using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace hr_system.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan ? LeavelTime { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}

