using System.ComponentModel.DataAnnotations;

namespace hr_system.Models
{
    public class RegisterModel
    {
        [Required,StringLength(100)]
        public string FullName { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; }

        [Required, StringLength(128)]
        public string Password { get; set; }

        [Required, StringLength(256)]
        public string Email { get; set; }

        public string roleName { get; set; }
    }
}
