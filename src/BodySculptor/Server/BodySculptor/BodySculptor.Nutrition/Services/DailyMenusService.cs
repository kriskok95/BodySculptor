namespace BodySculptor.Nutrition.Services
{
    using BodySculptor.Nutrition.Constants;
    using BodySculptor.Nutrition.Data;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Nutrition.Models.DailyMenus;
    using BodySculptor.Nutrition.Services.Interfaces;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    public class DailyMenusService : IDailyMenusService
    {
        private readonly NutritionDbContext context;
        private readonly IUsersService usersService;

        public DailyMenusService(NutritionDbContext context, IUsersService usersService)
        {
            this.context = context;
            this.usersService = usersService;
        }

        public async Task<IEnumerable<DailyMenuDto>> GetDailyMenusByUser(string userId)
        {
            var isUserExists = await this.usersService
                .IsUserExists(userId);

            if (!isUserExists)
            {
                throw new ArgumentException(string.Format(UsersConstants.UserNotExists, userId));
            }

            return await this.context
                .DailyMenus
                .Where(x => x.UserId == userId)
                .To<DailyMenuDto>()
                .ToListAsync();
        }

        public async Task<DailyMenuDto> GetDailyMenuByUserAndDate(string userId, DateTime date)
        {
            var isUserExists = await this.usersService
                .IsUserExists(userId);

            if (!isUserExists)
            {
                throw new ArgumentException(string.Format(UsersConstants.UserNotExists, userId));
            }

            var dailyMenuFromDb = await this.context
                .DailyMenus
                .Include(x => x.DailyMenuFoods)
                    .ThenInclude(x => x.Food)
                    .ThenInclude(x => x.FoodCategory)
                .FirstOrDefaultAsync(x => x.Date.Date == date.Date);

            return dailyMenuFromDb
                .MapTo<DailyMenuDto>();
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
