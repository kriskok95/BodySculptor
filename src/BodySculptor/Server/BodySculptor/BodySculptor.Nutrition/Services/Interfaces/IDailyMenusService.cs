namespace BodySculptor.Nutrition.Services.Interfaces
{
    using BodySculptor.Common.Services.Intefraces;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Nutrition.Models.DailyMenus;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDailyMenusService : IDataService<DailyMenu>
    {
        Task<DailyMenuDto> CreateDailyMenu(string userId, CreateDailyMenuInputModel input);

        Task<bool> CheckIfDailyMenuExistsByDate(string userId, DateTime date);

        Task<IEnumerable<DailyMenuDto>> GetDailyMenusByUser(string userId);

        Task<DailyMenuDto> GetDailyMenuByUserAndDate(string userId, DateTime date);

        Task<bool> IsDailyMenuExists(int dailyMenuId);

        Task<bool> IsDailyMenuExistsByUser(string userId, int dailyMenuId);

        Task<DailyMenuDto> EditDailyMenu(string userId, int dailyMenuId, EditDailyMenuInputModel input);

        Task DeleteDailyMenu(string userId, int dailyMenuId);
    }
}
