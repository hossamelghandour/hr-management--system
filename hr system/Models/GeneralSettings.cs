using System.ComponentModel.DataAnnotations.Schema;

namespace hr_system.Models
{
    public class GeneralSettings
    {
        public int Id { get; set; }
        public int OverTimeHour { get; set; }
        public int DiscountHour { get; set; }
        public string Weekend1 { get; set; }
        public string Weekend2 { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }

    }
}
