using Microsoft.AspNetCore.Identity;

namespace hr_system.Models
{
    public class CustomRole : IdentityRole
    {
        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
