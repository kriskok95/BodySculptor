namespace BodySculptor.Statistics.Services
{
    using BodySculptor.Statistics.Data;
    using BodySculptor.Statistics.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ClientStatisticsService : IClientStatisticsService
    {
        //TODO: Add Cashing for client statistics

        private readonly StatisticsDbContext context;

        public ClientStatisticsService(StatisticsDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateArticleAsync()
        {
            var clientStatistics = await this.context
                .ClientStatistics
                .FirstOrDefaultAsync();

            if(clientStatistics != null)
            {
                clientStatistics.TotalArticles++;

                await this.context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> CreateExerciseAsync()
        {
            var clientStatistics = await this.context
                .ClientStatistics
                .FirstOrDefaultAsync();

            if(clientStatistics != null)
            {
                clientStatistics.TotalExercises++;

                await this.context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> CreateFoodAsync(string foodName)
        {
            var clientStatistics = await this.context
                .ClientStatistics
                .FirstOrDefaultAsync();

            if(clientStatistics != null && !string.IsNullOrWhiteSpace(foodName))
            {
                clientStatistics.TotalFoods++;

                await this.context
                    .SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
