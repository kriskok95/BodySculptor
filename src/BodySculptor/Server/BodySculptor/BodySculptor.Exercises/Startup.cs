namespace BodySculptor.Exercises
{
    using AutoMapper;
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Exercises.Data;
    using BodySculptor.Exercises.Data.Seeding;
    using BodySculptor.Exercises.Models.Exercises;
    using BodySculptor.Exercises.Services;
    using BodySculptor.Exercises.Services.Interfaces;
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
            services.AddWebService<ExercisesDbContext>(this.Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IExercisesService, ExercisesService>();
            services.AddTransient<IMuscleGroupsService, MuscleGroupsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ExerciseDto).GetTypeInfo().Assembly);

            app.UseWebService(env);

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ExercisesDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ExercisesDbContextSeeder()
                    .SeedAsync(dbContext, serviceScope.ServiceProvider)
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}
