namespace BodySculptor.Nutrition.Services.Interfaces
{
    using BodySculptor.Common.Services;
    using BodySculptor.Nutrition.Models.Users;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        public Task<Result<UserDto>> RegisterUser(string userId);

        public Task<bool> IsUserExists(string userId);
    }
}
