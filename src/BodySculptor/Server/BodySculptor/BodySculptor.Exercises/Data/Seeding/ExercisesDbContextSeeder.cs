namespace BodySculptor.Exercises.Data.Seeding
{
    using BodySculptor.Common.Data.Seeding;
    using BodySculptor.Exercises.Data;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExercisesDbContextSeeder : ISeeder<ExercisesDbContext>
    {
        public async Task SeedAsync(ExercisesDbContext dbContext, IServiceProvider serviceProvider)
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
            var logger = loggerService.CreateLogger(typeof(ExercisesDbContextSeeder));

            var seeders = new List<ISeeder<ExercisesDbContext>>
                          {
                              new MuscleGroupsSeeder(),
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
