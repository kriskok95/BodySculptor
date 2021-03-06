﻿namespace BodySculptor.Identity.Data.Seeding
{
    using BodySculptor.Common.Data.Seeding;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class IdentityDbContextSeeder : ISeeder<IdentityDbContext>
    {
        private readonly IApplicationBuilder app;

        public IdentityDbContextSeeder(IApplicationBuilder app)
        {
            this.app = app;
        }

        public async Task SeedAsync(IdentityDbContext dbContext, IServiceProvider serviceProvider)
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
            var logger = loggerService.CreateLogger(typeof(IdentityDbContextSeeder));

            var seeders = new List<ISeeder<IdentityDbContext>>
                          {
                              new IdentitySeeder(app),
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
