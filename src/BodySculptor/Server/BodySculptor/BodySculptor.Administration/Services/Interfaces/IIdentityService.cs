namespace BodySculptor.Administration.Services.Interfaces
{
    using BodySculptor.Administration.Models.Identity;
    using Refit;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        [Post("/api/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
