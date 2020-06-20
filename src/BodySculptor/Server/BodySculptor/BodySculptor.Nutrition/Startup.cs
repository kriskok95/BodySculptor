namespace BodySculptor.Nutrition
{
    using AutoMapper;
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Nutrition.Data;
    using BodySculptor.Nutrition.Data.Seeding;
    using BodySculptor.Nutrition.Models;
    using BodySculptor.Nutrition.Services;
    using BodySculptor.Nutrition.Services.Interfaces;
    using BodySculptor.Services.Mapping;
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
            services.AddWebService<NutritionDbContext>(this.Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IFoodsService, FoodsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(FoodDto).GetTypeInfo().Assembly);

            app.UseWebService(env);

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<NutritionDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new NutritionDbContextSeeder()
                    .SeedAsync(dbContext, serviceScope.ServiceProvider)
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}
