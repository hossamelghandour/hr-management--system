using hr_system.Data;
using hr_system.DTOS;
using hr_system.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_system.Repositories.SettingsRepository
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly HrDbContext _context;

        public SettingsRepository(HrDbContext context)
        {
            _context = context;
        }

        public void CreateSetting(int id, SettingsDTo settingsDTo)
        {
            var employee=_context.Employees.Where(x=>x.Id==id).FirstOrDefault();
            if(employee!=null)
            {
                var GS = new GeneralSettings()
                {
                    EmployeeId = id,
                    OverTimeHour = settingsDTo.OvertimeHour,
                    DiscountHour = settingsDTo.DiscountHour,
                    Weekend1 = settingsDTo.Weekend1,
                    Weekend2 = settingsDTo.Weekend2,
                };
                _context.GeneralSettings.Add(GS);
                _context.SaveChanges();
            }
        }

        public void EditSetting(int empId, SettingsDTo settingsDTo)
        {
            GeneralSettings GS = _context.GeneralSettings.Where(X => X.EmployeeId == empId).FirstOrDefault();
            if (GS != null)
            {
                GS.OverTimeHour = settingsDTo.OvertimeHour;
                GS.DiscountHour = settingsDTo.DiscountHour;
                GS.Weekend1 = settingsDTo.Weekend1;
                GS.Weekend2 = settingsDTo.Weekend2;

                _context.GeneralSettings.Update(GS);
                _context.SaveChanges();
            }
        }

        public GeneralSettings GeneralSettingsByEmpId(int empId)
        {
            return _context.GeneralSettings.Where(x => x.EmployeeId == empId).FirstOrDefault();
        }
    }
}
