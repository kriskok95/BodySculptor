namespace BodySculptor.Gateway.Services.Interfaces
{
    using BodySculptor.Gateway.Models.Statistics;
    using Refit;
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        [Get("/api/ClientStatistics")]
        Task<ApiResponse<ClientStatisticsDto>> GetClientStatistics();
    }
}
