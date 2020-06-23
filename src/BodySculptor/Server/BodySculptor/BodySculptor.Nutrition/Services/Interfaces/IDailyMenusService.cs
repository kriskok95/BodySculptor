namespace BodySculptor.Nutrition.Services.Interfaces
{
    using BodySculptor.Nutrition.Models.DailyMenus;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDailyMenusService
    {
        Task<DailyMenuDto> CreateDailyMenu(string userId, CreateDailyMenuInputModel input);

        Task<bool> CheckIfDailyMenuExistsByDate(string userId, DateTime date);

        Task<IEnumerable<DailyMenuDto>> GetDailyMenusByUser(string userId);
    }
}
