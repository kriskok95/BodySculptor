namespace BodySculptor.Statistics.Services.Interfaces
{
    using BodySculptor.Statistics.Models.ClientStatistics;
    using System.Threading.Tasks;

    public interface IClientStatisticsService
    {
        Task<ClientStatisticsDto> GetClientStatisticsAsync();

        Task<bool> CreateFoodAsync(string foodName);

        Task<bool> CreateExerciseAsync();

        Task<bool> CreateArticleAsync();
    }
}
