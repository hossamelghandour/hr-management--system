using hr_system.DTOS;
using hr_system.Repositories.SettingsRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hr_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsController(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        [HttpGet("CreateSetting/{id}")]
        public IActionResult CreateSetting(int id,SettingsDTo settingsDTo)
        {
            if (id == 0 || settingsDTo == null)
                return BadRequest();

            _settingsRepository.CreateSetting(id, settingsDTo);
            return Ok();
        }
    }
}
