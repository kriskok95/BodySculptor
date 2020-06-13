namespace BodySculptor.API.Services
{
    using AutoMapper;
    using BodySculptor.API.Data;
    using BodySculptor.API.Models.Foods;
    using BodySculptor.API.Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System;
    using BodySculptor.API.Data.Models;

    public class FoodsService : IFoodsService
    {
        private readonly BodySculptorDbContext context;
        private readonly IMapper mapper;

        public FoodsService(BodySculptorDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<FoodDto> CreateFoodAsync(FoodForCreationDto food)
        {
            var foodForDb = this.mapper
                .Map<Food>(food);

            if(foodForDb == null)
            {
                throw new ArgumentNullException(nameof(food));
            }

            var isFoodExists = await this.IsFoodExistsAsync(food.Name);

            if (isFoodExists)
            {
                throw new InvalidOperationException("Food with the given name already exists in the DB!");
            }

            await this.context
               .Foods
               .AddAsync(foodForDb);

            await this.context
                .SaveChangesAsync();

            var foodDto = this.mapper
                .Map<FoodDto>(await this.context
                .Foods
                .Include(x => x.FoodCategory)
                .FirstOrDefaultAsync(x => x.Name == food.Name));

            return foodDto;
        }

        public async Task DeleteFood(int foodId)
        {
            var isFoodExists = await this.context
                .Foods
                .AnyAsync(food => food.Id == foodId);

            if (!isFoodExists)
            {
                throw new ArgumentException($"Food with the given ID: {foodId} doesn't exists!");
            }

            var foodToRemove = new Food { Id = foodId };

            this.context
                .Foods
                .Remove(foodToRemove);

            await this.context
                .SaveChangesAsync();
        }

        public async Task<FoodDto> EditFoodAsync(int foodId, FoodForUpdateDto food)
        {
            var isFoodExists = await IsFoodExistsAsync(foodId);

            if (!isFoodExists)
            {
                throw new ArgumentException($"Food with ID: {foodId} doesn't exists!");
            }

            var foodFromDb = await this.context
                .Foods
                .Include(x => x.FoodCategory)
                .FirstOrDefaultAsync(food => food.Id == foodId);

            var updatedFood = this.mapper
                .Map(food, foodFromDb);

            await this.context
                .SaveChangesAsync();

            var foodToReturn = this.mapper
                .Map<FoodDto>(updatedFood);

            return foodToReturn;
        }

        public async Task<FoodDto> GetFoodAsync(int foodId)
        {
            var foodFromDb = await this.context
                    .Foods
                    .Include(x => x.FoodCategory)
                    .FirstOrDefaultAsync(food => food.Id == foodId);

            if(foodFromDb == null)
            {
                throw new ArgumentNullException(nameof(foodId));
            }

            return this.mapper
                .Map<FoodDto>(foodFromDb);
        }

        public async Task<IEnumerable<FoodDto>> GetFoodsAsync()
        {
            var foodsFromDb = await this.context
                .Foods
                .Include(x => x.FoodCategory)
                .ToListAsync();

            var foodsDto = this.mapper
                .Map<IEnumerable<FoodDto>>(foodsFromDb)
                .ToList();

            return foodsDto;
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
    }
}
