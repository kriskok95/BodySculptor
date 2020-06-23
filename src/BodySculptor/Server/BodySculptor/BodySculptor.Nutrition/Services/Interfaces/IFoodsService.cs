
namespace BodySculptor.Nutrition.Services.Interfaces
{
    using BodySculptor.Common.Services;
    using BodySculptor.Nutrition.Models.Foods;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodsService
    {
        Task<IEnumerable<FoodDto>> GetFoodsAsync();

        Task<Result<FoodDto>> GetFoodAsync(int foodId);

        Task<bool> IsFoodExistsAsync(int foodId);

        Task<bool> IsFoodCategoryExistsAsync(int foodCategoryId);

        Task<Result<FoodDto>> CreateFoodAsync(FoodForCreationDto food);

        Task<bool> IsFoodExistsAsync(string foodName);

        Task<Result<FoodDto>> EditFoodAsync(int foodId, FoodForUpdateDto food);

        Task DeleteFood(int foodId);
    }
}
