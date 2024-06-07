using hr_system.Models;

namespace hr_system.Repositories.PublicHolidayRepository
{
    public interface IPublicHoidayRepository
    {
        List<PublicHolidays>GetAll();
        PublicHolidays GetById(int id);
        bool AddNewHolidy(PublicHolidays publicHoliday);
        bool UpdateHolidy(int id,PublicHolidays updateHoliday);
        bool DeleteHolidy(int id);
    }
}
