using System.Security;

namespace hr_system.DTOS
{
    public class RolePermissionDTO
    {
        public string RoleId { get; set; }
        public string Name { get; set; }

        public List<PermissionDTO> permissions { get; set; }
    }
}
