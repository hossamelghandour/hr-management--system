using hr_system.Data;
using hr_system.DTOS;
using hr_system.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hr_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly HrDbContext _context;

        public RolesController(HrDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _context.Roles.Include(x => x.Permissions).ToList();
            var dtos = new List<RolePermissionDTO>();
            foreach (var item in roles)
            {
                var rolePermissionDTO = new RolePermissionDTO();
                rolePermissionDTO.RoleId = item.Id;
                rolePermissionDTO.Name = item.Name;

                var permissionsDtos = new List<PermissionDTO>();
                foreach (var perm in item.Permissions)
                {
                    var permissionDto = new PermissionDTO()
                    {
                        Section = perm.Section,
                        CanAdd = perm.CanAdd,
                        CanEdit = perm.CanEdit,
                        CanRead = perm.CanRead,
                        CanDelete = perm.CanDelete
                    };
                    permissionsDtos.Add(permissionDto);
                }
                rolePermissionDTO.permissions = permissionsDtos;

                dtos.Add(rolePermissionDTO);
            }
            return Ok(dtos);
        }

        [HttpGet("getById/{id}")]
        public RolePermissionDTO getById(string id)
        {
            var rolePerm = _context.Roles.Include(x => x.Permissions).FirstOrDefault(x => x.Id == id);

            var rolePermissionDTO = new RolePermissionDTO();
            rolePermissionDTO.RoleId = rolePerm.Id;
            rolePermissionDTO.Name = rolePerm.Name;

            var permissionsDtos = new List<PermissionDTO>();
            foreach (var item in rolePerm.Permissions)
            {
                var permissionDto = new PermissionDTO()
                {
                    Section = item.Section,
                    CanAdd = item.CanAdd,
                    CanRead = item.CanRead,
                    CanDelete = item.CanDelete,
                    CanEdit = item.CanEdit
                };
                permissionsDtos.Add(permissionDto);
            }
            rolePermissionDTO.permissions = permissionsDtos;

            return rolePermissionDTO;

        }

        [HttpPost("CreateRole")]
        public IActionResult CreateRole([FromBody] CustomRole role)
        {
            role.NormalizedName = role.Name.ToUpper();
            role.ConcurrencyStamp = Guid.NewGuid().ToString();
            if (role == null) return BadRequest();
            _context.Roles.Add(role);
            _context.SaveChanges();
            return Ok(role);
        }

        [HttpPut("EditRole/{roleId}")]
        public IActionResult EditRole(string roleId, [FromBody] CustomRole updatedRole)
        {
            updatedRole.Id = roleId;
            if (updatedRole == null) return BadRequest();
            var existingRole = _context.Roles.Include(x => x.Permissions).FirstOrDefault(r => r.Id == roleId);
            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.Name = updatedRole.Name;
            // Update other properties as needed
            foreach (var rolePermission in existingRole.Permissions)
            {
                // Update permissions based on updatedRole or any other conditions
                rolePermission.CanRead = updatedRole.Permissions.Any(rp => rp.Section == rolePermission.Section && rp.CanRead);
                rolePermission.CanAdd = updatedRole.Permissions.Any(rp => rp.Section == rolePermission.Section && rp.CanAdd);
                rolePermission.CanEdit = updatedRole.Permissions.Any(rp => rp.Section == rolePermission.Section && rp.CanEdit);
                rolePermission.CanDelete = updatedRole.Permissions.Any(rp => rp.Section == rolePermission.Section && rp.CanDelete);
                // Update other permissions as needed
            }

            _context.SaveChanges();
            return Ok(existingRole);
        }

        [HttpDelete("DeleteRole/{roleId}")]
        public IActionResult DeleteRole(string roleId)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == roleId);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("getPermissionsForSection/{section}")]
        public List<PermissionDTO> getPermissionsForSection(string section, string role)
        {
            var permissions = _context.Roles.Include(x => x.Permissions).Where(x => x.Name == role).FirstOrDefault();

            var dtos = new List<PermissionDTO>();
            foreach (var item in permissions.Permissions.Where(x => x.Section == section))
            {
                var dto = new PermissionDTO()
                {
                    Section = item.Section,
                    CanAdd = item.CanAdd,
                    CanRead = item.CanRead,
                    CanDelete = item.CanDelete,
                    CanEdit = item.CanEdit
                };
                dtos.Add(dto);
            }

            return dtos;
        }

    }
}

