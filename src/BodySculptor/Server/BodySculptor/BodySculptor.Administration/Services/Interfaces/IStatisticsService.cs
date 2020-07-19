namespace BodySculptor.Administration.Services.Interfaces
{
    using BodySculptor.Administration.Models.Statistics;
    using Refit;
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        [Get("/api/AdministrationStatistics")]
        Task<ApiResponse<AdministrationStatisticsModel>> GetAdministrationStatistics();
    }
}
