namespace BodySculptor.Nutrition.Services
{
    using BodySculptor.Nutrition.Constants;
    using BodySculptor.Nutrition.Data;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Nutrition.Models.DailyMenus;
    using BodySculptor.Nutrition.Services.Interfaces;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class DailyMenusService : IDailyMenusService
    {
        private readonly NutritionDbContext context;

        public DailyMenusService(NutritionDbContext context)
        {
            this.context = context;
        }

        public async Task<DailyMenuDto> CreateDailyMenu(string userId, CreateDailyMenuInputModel input)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new InvalidOperationException(UsersConstants.UserNullOrWhiteSpace);   
            }

            var dailyMenuForDb = input
                .MapTo<DailyMenu>();
            dailyMenuForDb.UserId = userId;

            await this.context
                .DailyMenus
                .AddAsync(dailyMenuForDb);

            await this.context
                .SaveChangesAsync();

            var dailyMenuFromDb = await this.context
                .DailyMenus
                .Include(x => x.DailyMenuFoods)
                    .ThenInclude(x => x.Food)
                    .ThenInclude(x => x.FoodCategory)
                .FirstOrDefaultAsync(x => x.Id == dailyMenuForDb.Id);

            var dailyMenuToReturn = dailyMenuFromDb
                .MapTo<DailyMenuDto>();

            return dailyMenuToReturn;
        }

        public async Task<bool> CheckIfDailyMenuExistsByDate(string userId, DateTime date)
        {
            return await this.context
                .DailyMenus
                .AnyAsync(x => x.Date.Date == date.Date && x.UserId == userId);
        }
    }
}
