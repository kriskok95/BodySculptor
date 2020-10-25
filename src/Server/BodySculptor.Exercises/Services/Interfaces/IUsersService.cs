namespace BodySculptor.Exercises.Services.Interfaces
{
    using BodySculptor.Common.Services;
    using BodySculptor.Exercises.Models.Users;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        public Task<Result<UserDto>> RegisterUser(string userId);

        public Task<bool> IsUserExists(string userId);
    }
}
