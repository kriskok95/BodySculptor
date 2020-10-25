namespace BodySculptor.Statistics
{
    using AutoMapper;
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Common.Messages.Nutrition;
    using BodySculptor.Services.Mapping;
    using BodySculptor.Statistics.Data;
    using BodySculptor.Statistics.Data.Seeding;
    using BodySculptor.Statistics.Messages;
    using BodySculptor.Statistics.Models.AdministrationStatistics;
    using BodySculptor.Statistics.Services;
    using BodySculptor.Statistics.Services.Interfaces;
    using MassTransit;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Reflection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebService<StatisticsDbContext>(this.Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMessaging(this.Configuration
                , typeof(TrainingSessionCreatedConsumer)
                , typeof(DailyMenuCreatedConsumer)
                , typeof(FoodCreatedConsumer)
                , typeof(ExerciseCreatedConsumer)
                , typeof(ArticleCreatedConsumer));

            services.AddTransient<IAdministraionStatisticsService, AdministrationStatisticsService>();
            services.AddTransient<IClientStatisticsService, ClientStatisticsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(AdministrationStatisticsDto).GetTypeInfo().Assembly);

            app.UseWebService(env);

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<StatisticsDbContext>();

                //if (env.IsDevelopment())
                //{
                    dbContext.Database.Migrate();
                //}

                new StatisticsDbContextSeeder()
                    .SeedAsync(dbContext, serviceScope.ServiceProvider)
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}
