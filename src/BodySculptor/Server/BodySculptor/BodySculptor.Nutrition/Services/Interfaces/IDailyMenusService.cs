namespace BodySculptor.Nutrition.Services.Interfaces
{
    using BodySculptor.Nutrition.Models.DailyMenus;
    using System;
    using System.Threading.Tasks;

    public interface IDailyMenusService
    {
        public Task<DailyMenuDto> CreateDailyMenu(string userId, CreateDailyMenuInputModel input);

        public Task<bool> CheckIfDailyMenuExistsByDate(string userId, DateTime date);
    }
}
