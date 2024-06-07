using hr_system.DTOS;
using hr_system.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace hr_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet("GetAll")]
        public List<UserWithRole> GetAll()
        {
            var users=userManager.Users.ToList();
            var usersWithRole=new List<UserWithRole>();

            foreach (var user in users)
            {
                var role = userManager.GetRolesAsync(user).Result[0];
                var userWithRole = new UserWithRole()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = role
                };
                usersWithRole.Add(userWithRole);
            }
            return usersWithRole;
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(string id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);

            if(user != null)
            {
                var result = userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return NotFound();
        }

    }
}
