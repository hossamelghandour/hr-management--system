using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hr_system.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string NationalId { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan LeaveTime { get; set; }
        public string ? UserId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public ICollection<Attendance>? Attendances { get; set; }

        public GeneralSettings? GeneralSettings { get; set; }
         

    }
}
