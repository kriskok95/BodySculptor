namespace BodySculptor.Statistics.Services.Interfaces
{
    using BodySculptor.Statistics.Models.AdministrationStatistics;
    using System.Threading.Tasks;

    public interface IAdministraionStatisticsService
    {
        Task<AdministrationStatisticsDto> GetAdministrationStatisticsAsync();

        Task<bool> CreateTrainingSession(int trainingSessionId);

        Task<bool> CreateDailyMenu(int dailyMenuId);
    }
}
