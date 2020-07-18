namespace BodySculptor.Identity.Services.Interfaces
{
    using BodySculptor.Identity.Models.Identity;
    using Refit;
    using System.Threading.Tasks;

    public interface IArticlesRegisterService
    {
        [Headers("Content-Type: application/json")]
        [Post("/api/Users/Register")]
        Task<ApiResponse<UserDto>> Register([Body] RegisterArticleUserInputModel model);
    }
}
