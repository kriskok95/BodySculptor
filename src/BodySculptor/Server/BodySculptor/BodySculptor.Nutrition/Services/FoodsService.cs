namespace BodySculptor.Nutrition.Services
{
    using AutoMapper.QueryableExtensions;
    using BodySculptor.Common.Services;
    using BodySculptor.Nutrition.Constants;
    using BodySculptor.Nutrition.Data;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Nutrition.Models.Foods;
    using BodySculptor.Nutrition.Services.Interfaces;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FoodsService : IFoodsService
    {
        private readonly NutritionDbContext context;
    
        public FoodsService(NutritionDbContext context)
        {
            this.context = context;
        }

        public async Task<Result<FoodDto>> GetFoodAsync(int foodId)
        {
            var foodFromDb = await context
                    .Foods
                    .Include(x => x.FoodCategory)
                    .FirstOrDefaultAsync(food => food.Id == foodId);

            if (foodFromDb == null)
            {
                throw new ArgumentNullException(nameof(foodId));
            }

            return foodFromDb
                .MapTo<FoodDto>();
        }

        public async Task<IEnumerable<FoodDto>> GetFoodsAsync()
        {
            var foodsFromDb = await context
                .Foods
                .Include(x => x.FoodCategory)
                .To<FoodDto>()
                .ToListAsync();

            return foodsFromDb;
        }

        public async Task<Result<FoodDto>> CreateFoodAsync(FoodForCreationDto food)
        {
            var foodForDb = food
                .MapTo<Food>();

            if (foodForDb == null)
            {
                throw new ArgumentNullException(nameof(food));
            }

            var isFoodExists = await IsFoodExistsAsync(food.Name);

            if (isFoodExists)
            {
                return Result<FoodDto>.Failure(new List<string> { FoodsConstants.ExistingFoodByName });
            }

            await context
               .Foods
               .AddAsync(foodForDb);

            await context
                .SaveChangesAsync();

            var foodFromDb = await context
                .Foods
                .Include(x => x.FoodCategory)
                .FirstOrDefaultAsync(x => x.Name == food.Name);

            return Result<FoodDto>.SuccessWith(foodFromDb
                .MapTo<FoodDto>());
        }

        public async Task<Result<FoodDto>> EditFoodAsync(int foodId, FoodForUpdateDto food)
        {
            var isFoodExists = await IsFoodExistsAsync(foodId);

            if (!isFoodExists)
            {
                return Result<FoodDto>.Failure(new List<string> { string.Format(FoodsConstants.UnexistingFoodById, foodId) });
            }

            var foodFromDb = await context
                .Foods
                .Include(x => x.FoodCategory)
                .FirstOrDefaultAsync(food => food.Id == foodId);

            var updatedFood = food
                .MapTo<FoodForUpdateDto, Food>(foodFromDb);

            await context
                .SaveChangesAsync();

            var foodToReturn = updatedFood
                .MapTo<FoodDto>();

            return Result<FoodDto>.SuccessWith(foodToReturn);
        }

        public async Task DeleteFood(int foodId)
        {
            var isFoodExists = await context
                .Foods
                .AnyAsync(food => food.Id == foodId);

            if (!isFoodExists)
            {
                throw new ArgumentException(string.Format(FoodsConstants.UnexistingFoodById, foodId));
            }

            var foodToRemove = new Food { Id = foodId };

            context
                .Foods
                .Remove(foodToRemove);

            await context
                .SaveChangesAsync();
        }

        public async Task<bool> IsFoodCategoryExistsAsync(int foodCategoryId)
        {
            return await this.context
                .FoodCategories
                .AnyAsync(fc => fc.Id == foodCategoryId);
        }

        public Task<bool> IsFoodExistsAsync(int foodId)
        {
            return this.context
                .Foods
                .AnyAsync(food => food.Id == foodId);
        }

        public async Task<bool> IsFoodExistsAsync(string foodName)
        {
            return await this.context
                .Foods
                .AnyAsync(food => food.Name == foodName);
        }

        public async Task<IEnumerable<FoodCategoryDto>> GetFoodCategoriesAsync()
        {
            return await this.context
                .FoodCategories
                .To<FoodCategoryDto>()
                .ToListAsync();
        }
    }
}
