namespace BodySculptor.Nutrition.Services
{
    using AutoMapper;
    using BodySculptor.Nutrition.Data;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Nutrition.Models;
    using BodySculptor.Nutrition.Services.Interfaces;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FoodsService : IFoodsService
    {
        private readonly NutritionDbContext context;
        private readonly IMapper mapper;
    
        public FoodsService(NutritionDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<FoodDto> CreateFoodAsync(FoodForCreationDto food)
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
                throw new InvalidOperationException("Food with the given name already exists in the DB!");
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

            return foodFromDb
                .MapTo<FoodDto>();
        }

        public async Task DeleteFood(int foodId)
        {
            var isFoodExists = await context
                .Foods
                .AnyAsync(food => food.Id == foodId);

            if (!isFoodExists)
            {
                throw new ArgumentException($"Food with the given ID: {foodId} doesn't exists!");
            }

            var foodToRemove = new Food { Id = foodId };

            context
                .Foods
                .Remove(foodToRemove);

            await context
                .SaveChangesAsync();
        }

        public async Task<FoodDto> EditFoodAsync(int foodId, FoodForUpdateDto food)
        {
            var isFoodExists = await IsFoodExistsAsync(foodId);

            if (!isFoodExists)
            {
                throw new ArgumentException($"Food with ID: {foodId} doesn't exists!");
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

            return foodToReturn;
        }

        public async Task<FoodDto> GetFoodAsync(int foodId)
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

        public async Task<bool> IsFoodCategoryExistsAsync(int foodCategoryId)
        {
            return await context
                .FoodCategories
                .AnyAsync(fc => fc.Id == foodCategoryId);
        }

        public Task<bool> IsFoodExistsAsync(int foodId)
        {
            return context
                .Foods
                .AnyAsync(food => food.Id == foodId);
        }

        public async Task<bool> IsFoodExistsAsync(string foodName)
        {
            return await context
                .Foods
                .AnyAsync(food => food.Name == foodName);
        }
    }
}
