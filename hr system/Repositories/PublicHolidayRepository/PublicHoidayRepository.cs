using hr_system.Data;
using hr_system.Models;

namespace hr_system.Repositories.PublicHolidayRepository
{
    public class PublicHoidayRepository : IPublicHoidayRepository
    {
        private readonly HrDbContext _context;

        public PublicHoidayRepository(HrDbContext context)
        {
            _context = context;
        }

        public bool AddNewHolidy(PublicHolidays publicHoliday)
        {
            _context.PublicHolidays.Add(publicHoliday);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteHolidy(int id)
        {
            var holiday = _context.PublicHolidays.Find(id);
            if (holiday != null)
                return false;
            _context.PublicHolidays.Remove(holiday);
            _context.SaveChanges();
            return true;
            
        }

        public List<PublicHolidays> GetAll()
        {
            return _context.PublicHolidays.ToList();
        }

        public PublicHolidays GetById(int id)
        {
            return _context.PublicHolidays.Find(id);
        }

        public bool UpdateHolidy(int id, PublicHolidays updateHoliday)
        {
            var holiday = _context.PublicHolidays.Find(id);
            if (holiday == null)
                return false;

            holiday.Name= updateHoliday.Name;
            holiday.Day=updateHoliday.Day;

            _context.SaveChanges();
            return true;
        }
    }
}
