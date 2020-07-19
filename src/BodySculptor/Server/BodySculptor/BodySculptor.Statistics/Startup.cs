namespace BodySculptor.Statistics
{
    using AutoMapper;
    using BodySculptor.Common.Infrastructure;
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

            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<TrainingSessionCreatedConsumer>();
                mt.AddConsumer<DailyMenuCreatedConsumer>();

                mt.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(rmq =>
                {
                    rmq.Host("localhost");

                    rmq.ReceiveEndpoint(nameof(TrainingSessionCreatedConsumer), endpoint =>
                    {
                        endpoint.ConfigureConsumer<TrainingSessionCreatedConsumer>(bus);
                    });
                    rmq.ReceiveEndpoint(nameof(DailyMenuCreatedConsumer), endpoint =>
                    {
                        endpoint.ConfigureConsumer<DailyMenuCreatedConsumer>(bus);
                    });
                }));
            });

            services.AddMassTransitHostedService();

            services.AddTransient<IAdministraionStatisticsService, AdministrationStatisticsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(AdministrationStatisticsDto).GetTypeInfo().Assembly);

            app.UseWebService(env);

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<StatisticsDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new StatisticsDbContextSeeder()
                    .SeedAsync(dbContext, serviceScope.ServiceProvider)
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}
