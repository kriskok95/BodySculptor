namespace BodySculptor.Nutrition.Services
{
    using BodySculptor.Common.Services;
    using BodySculptor.Nutrition.Models.DailyMenus;
    using BodySculptor.Nutrition.Services.Interfaces;
    using System.Threading.Tasks;

    public class DailyMenusService : IDailyMenusService
    {
        public Task<Result<DailyMenuDto>> CreateDailyMenu(CreateDailyMenuInputModel input)
        {
            return null;
        }
    }
}
