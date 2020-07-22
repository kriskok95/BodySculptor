namespace BodySculptor.Statistics.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IClientStatisticsService
    {
        Task<bool> CreateFoodAsync(string foodName);

        Task<bool> CreateExerciseAsync();

        Task<bool> CreateArticleAsync();
    }
}
