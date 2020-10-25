namespace BodySculptor.Nutrition.Data.Seeding
{
    using BodySculptor.Common.Data.Seeding;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NutritionDbContextSeeder : ISeeder<NutritionDbContext>
    {
        public async Task SeedAsync(NutritionDbContext dbContext, IServiceProvider serviceProvider)
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
            var logger = loggerService.CreateLogger(typeof(NutritionDbContextSeeder));

            var seeders = new List<ISeeder<NutritionDbContext>>
                          {
                              new FoodCategoriesSeeder(),
                              new FoodsSeeder(),
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
