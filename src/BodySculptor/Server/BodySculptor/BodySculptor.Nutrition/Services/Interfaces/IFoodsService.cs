namespace BodySculptor.Nutrition.Services.Interfaces
{
    using BodySculptor.Nutrition.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodsService
    {
        Task<IEnumerable<FoodDto>> GetFoodsAsync();

        Task<FoodDto> GetFoodAsync(int foodId);

        Task<bool> IsFoodExistsAsync(int foodId);

        Task<bool> IsFoodCategoryExistsAsync(int foodCategoryId);

        Task<FoodDto> CreateFoodAsync(FoodForCreationDto food);

        Task<bool> IsFoodExistsAsync(string foodName);

        Task<FoodDto> EditFoodAsync(int foodId, FoodForUpdateDto food);

        Task DeleteFood(int foodId);
    }
}
