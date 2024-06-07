using System.ComponentModel.DataAnnotations.Schema;

namespace hr_system.Models
{
    public class PublicHolidays
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Day { get; set; }


    }
}
