using hr_system.Models;
using hr_system.Repositories.PublicHolidayRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace hr_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicHolidaysController : ControllerBase
    {
        private readonly IPublicHoidayRepository _publicHolidayRepository;

        public PublicHolidaysController(IPublicHoidayRepository publicHolidayRepository)
        {
            _publicHolidayRepository = publicHolidayRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Holidays=_publicHolidayRepository.GetAll();
            return Ok(Holidays);
        }

        [HttpGet("GetHolidayById")]
        public IActionResult GetHolidayById(int id)
        {
            var holiday = _publicHolidayRepository.GetById(id);
            if (holiday == null)
                return BadRequest();
            return Ok(holiday);
        }

        [HttpPost("AddNewHoliday")]
        public IActionResult AddNewHoliday(PublicHolidays publicHolidays)
        {
            if (publicHolidays == null)
                return BadRequest();
            _publicHolidayRepository.AddNewHolidy(publicHolidays);
            return Ok(publicHolidays);
        }

        [HttpPost("EditHoliday/{id}")]
        public IActionResult EditHoliday(int id,PublicHolidays publicHolidays)
        {
            publicHolidays.Id = id;
            if (publicHolidays == null)
                return BadRequest();
            if (publicHolidays.Id != id)
                return BadRequest();
            _publicHolidayRepository.UpdateHolidy(id, publicHolidays);
            return Ok(publicHolidays);
        }

        [HttpDelete("DeleteHoliday/{id}")]
        public IActionResult DeleteHoliday(int id)
        {
           var result = _publicHolidayRepository.DeleteHolidy(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
