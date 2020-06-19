namespace BodySculptor.Identity.Services.Interfaces
{
    using BodySculptor.Common.Services;
    using BodySculptor.Identity.Data.Entities;
    using BodySculptor.Identity.Models.Identity;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        Task<Result<User>> Register(RegisterUserRquestModel userInput);

        Task<Result<LoginOutputModel>> Login(LoginRequestModel userInput);
    }
}
