namespace BodySculptor.Statistics.Services
{
    using BodySculptor.Services.Mapping;
    using BodySculptor.Statistics.Data;
    using BodySculptor.Statistics.Models.AdministrationStatistics;
    using BodySculptor.Statistics.Services.Interfaces;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class AdministrationStatisticsService : IAdministraionStatisticsService
    {
        private readonly StatisticsDbContext context;
        private readonly IBus consumer;

        public AdministrationStatisticsService(StatisticsDbContext context, IBus consumer)
        {
            this.context = context;
            this.consumer = consumer;
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

        public async Task<bool> CreateTrainingSession(int trainingSessionId)
        {
            //TODO: Fix the bug with creating training session

            var administrationStatisticsFromDb = await this.context
                .AdministrationStatistics
                .FirstOrDefaultAsync();

            if(trainingSessionId != 0 && administrationStatisticsFromDb != null)
            {
                administrationStatisticsFromDb.TotalTrainingSessions++;
                await this.context
                    .SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CreateDailyMenu(int dailyMenuId)
        {
            var administrationStatisticsFromDb = await this.context
                .AdministrationStatistics
                .FirstOrDefaultAsync();

            if (dailyMenuId != 0 && administrationStatisticsFromDb != null)
            {
                administrationStatisticsFromDb.TotalTrainingSessions++;
                await this.context
                    .SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
