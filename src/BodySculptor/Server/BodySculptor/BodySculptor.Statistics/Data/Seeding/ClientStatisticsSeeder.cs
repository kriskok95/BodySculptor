namespace BodySculptor.Statistics.Data.Seeding
{
    using BodySculptor.Common.Data.Seeding;
    using BodySculptor.Statistics.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class ClientStatisticsSeeder : ISeeder<StatisticsDbContext>
    {
        public async Task SeedAsync(StatisticsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.ClientStatistics.AnyAsync())
            {
                return;
            }

            await dbContext.ClientStatistics.AddAsync(new ClientStatistics { TotalExercises = 16, TotalFoods = 45, TotalArticles = 1 });
        }
    }
}
