using hr_system.DTOS;
using hr_system.Models;

namespace hr_system.Repositories.SettingsRepository
{
    public interface ISettingsRepository
    {
        void CreateSetting(int id, SettingsDTo settingsDTo);
        void EditSetting(int empId,SettingsDTo settingsDTo);
        GeneralSettings GeneralSettingsByEmpId(int empId);

    }
}
