namespace BodySculptor.API.Data.Seeding
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BodySculptorDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(BodySculptorDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var loggerService = (ILoggerFactory)serviceProvider.GetService(typeof(ILoggerFactory));
            var logger = loggerService.CreateLogger(typeof(BodySculptorDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              new FoodCategoriesSeeder(),
                              new MuscleGroupsSeeder(),
                              new FoodsSeeder(),
                              new ExercisesSeeder(),
                              new MuscleGroupExercisesSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
