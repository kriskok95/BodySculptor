
namespace BodySculptor.Statistics.Services
{
    using BodySculptor.Services.Mapping;
    using BodySculptor.Statistics.Data;
    using BodySculptor.Statistics.Models.AdministrationStatistics;
    using BodySculptor.Statistics.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class AdministrationStatisticsService : IAdministraionStatisticsService
    {
        private readonly StatisticsDbContext context;

        public AdministrationStatisticsService(StatisticsDbContext context)
        {
            this.context = context;
        }

        public async Task<AdministrationStatisticsDto> GetAdministrationStatisticsAsync()
        {
            var administrationStatisticsFromDb = await this.context
                .AdministrationStatistics
                .FirstOrDefaultAsync();

            var administrationStatisticsToReturn = administrationStatisticsFromDb
                .MapTo<AdministrationStatisticsDto>();

            return administrationStatisticsToReturn;
        }
    }
}
