namespace BodySculptor.Identity.Services.Interfaces
{
    using BodySculptor.Identity.Models.Identity;
    using BodySculptor.Nutrition.Models.Users;
    using Refit;
    using System.Threading.Tasks;

    public interface IExercisesRegisterService
    {
        [Headers("Content-Type: application/json")]
        [Post("/api/Users/Register")]
        Task<ApiResponse<UserDto>> Register([Body] RegisterExerciseUserInputModel model);
    }
}
