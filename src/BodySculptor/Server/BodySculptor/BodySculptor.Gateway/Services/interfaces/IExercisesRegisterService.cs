namespace BodySculptor.Gateway.Services.interfaces
{
    using BodySculptor.Gateway.Models;
    using Refit;
    using System.Threading.Tasks;

    public interface IExercisesRegisterService
    {
        [Post("/Users/Register")]
        Task<UserOutputModel> Register();
    }
}
