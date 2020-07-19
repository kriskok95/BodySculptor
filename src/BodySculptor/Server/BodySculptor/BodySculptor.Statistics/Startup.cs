namespace BodySculptor.Statistics
{
    using AutoMapper;
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Services.Mapping;
    using BodySculptor.Statistics.Data;
    using BodySculptor.Statistics.Models.AdministrationStatistics;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(AdministrationStatisticsDto).GetTypeInfo().Assembly);

            app.UseWebService(env);
        }
    }
}
