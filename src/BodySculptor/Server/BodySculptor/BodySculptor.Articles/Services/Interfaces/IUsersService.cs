namespace BodySculptor.Articles.Services.Interfaces
{
    using BodySculptor.Articles.Models.Users;
    using BodySculptor.Common.Services;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        public Task<Result<UserDto>> RegisterUser(string userId);

        public Task<bool> IsUserExists(string userId);
    }
}
