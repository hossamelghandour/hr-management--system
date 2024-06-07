using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace hr_system.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required,MaxLength(255)]
        public string FullName { get; set; }
    }
}
