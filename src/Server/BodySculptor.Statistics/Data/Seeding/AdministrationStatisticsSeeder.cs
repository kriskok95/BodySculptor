namespace BodySculptor.Statistics.Data.Seeding
{
    using BodySculptor.Common.Data.Seeding;
    using BodySculptor.Statistics.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class AdministrationStatisticsSeeder : ISeeder<StatisticsDbContext>
    {
        public async Task SeedAsync(StatisticsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.AdministrationStatistics.AnyAsync())
            {
                return;
            }

            await dbContext.AdministrationStatistics.AddAsync(new AdministrationStatistics { });
        }
    }
}
