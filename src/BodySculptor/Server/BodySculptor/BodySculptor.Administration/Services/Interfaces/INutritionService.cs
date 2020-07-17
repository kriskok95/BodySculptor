namespace BodySculptor.Administration.Services.Interfaces
{
    using BodySculptor.Administration.Models.Foods;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INutritionService
    {
        [Get("/api/Foods")]
        Task<ApiResponse<IEnumerable<FoodDto>>> GetFoods();

        [Get("/api/Foods/{foodId}")]
        Task<ApiResponse<FoodDto>> GetFood(string foodId);

        [Headers("Content-Type: application/json")]
        [Post("/api/Foods")]
        Task<ApiResponse<FoodDto>> CreateFood([Body] CreateFoodInputModel model);

        [Headers("Content-Type: application/json")]
        [Put("/api/Foods/{foodId}")]
        Task<ApiResponse<FoodDto>> EditFood(string foodId, [Body] UpdateFoodInputModel model);

        [Get("/api/Foods/GetFoodCategories")]
        Task<ApiResponse<IEnumerable<FoodCategoryDto>>> GetFoodCategories();
    }
}
