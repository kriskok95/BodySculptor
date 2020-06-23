namespace BodySculptor.Nutrition.Services.Interfaces
{
    using BodySculptor.Common.Services;
    using BodySculptor.Nutrition.Models.DailyMenus;
    using System.Threading.Tasks;

    public interface IDailyMenusService
    {
        public Task<Result<DailyMenuDto>> CreateDailyMenu(CreateDailyMenuInputModel input);
    }
}
