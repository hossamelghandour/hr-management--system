using System.ComponentModel.DataAnnotations;

namespace hr_system.Models
{
    public class TokenReqModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
