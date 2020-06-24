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
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task<DailyMenuDto> EditDailyMenu(string userId, int dailyMenuId, EditDailyMenuInputModel input)
        {
            var isUserExists = await this.usersService
                .IsUserExists(userId);

            if (!isUserExists)
            {
                throw new ArgumentException(string.Format(UsersConstants.UserNotExists, userId));
            }

            var isDailyMenuExistsByUser = await this.IsDailyMenuExistsByUser(userId, dailyMenuId);

            if (!isDailyMenuExistsByUser)
            {
                throw new ArgumentException(string.Format(FoodsConstants.DailyMenuDoesntExistsByUser, userId, dailyMenuId));
            }

            var dailyMenuFromDb = await this.context
                .DailyMenus
                .Include(x => x.DailyMenuFoods)
                    .ThenInclude(x => x.Food)
                    .ThenInclude(x => x.FoodCategory)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == dailyMenuId);

            var updatedDailyMenu = input
                .MapTo<EditDailyMenuInputModel, DailyMenu>(dailyMenuFromDb);

            await this.context.SaveChangesAsync();

            var updatedDailyMenuToReturn = await this.context
                .DailyMenus
                .Include(x => x.DailyMenuFoods)
                    .ThenInclude(x => x.Food)
                    .ThenInclude(x => x.FoodCategory)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == dailyMenuId);

            return updatedDailyMenuToReturn
                .MapTo<DailyMenuDto>();
        }

        public async Task<bool> CheckIfDailyMenuExistsByDate(string userId, DateTime date)
        {
            return await this.context
                .DailyMenus
                .AnyAsync(x => x.Date.Date == date.Date && x.UserId == userId);
        }

        public async Task<bool> IsDailyMenuExists(int dailyMenuId)
        {
            return await this.context
                .DailyMenus
                .AnyAsync(x => x.Id == dailyMenuId);
        }

        public async Task<bool> IsDailyMenuExistsByUser(string userId, int dailyMenuId)
        {
            var isUserExists = await this.usersService
                .IsUserExists(userId);

            if (!isUserExists)
            {
                throw new ArgumentException(string.Format(UsersConstants.UserNotExists, userId));
            }

            return await this.context
                .DailyMenus
                .AnyAsync(x => x.UserId == userId && x.Id == dailyMenuId);
        }
    }
}
