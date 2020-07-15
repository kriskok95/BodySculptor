namespace BodySculptor.Identity
{
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Identity.Data;
    using BodySculptor.Identity.Infrastructure;
    using BodySculptor.Identity.Services;
    using BodySculptor.Identity.Services.Interfaces;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Refit;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddWebService<IdentityDbContext>(this.Configuration)
                .AddUserStorage();

            services.AddTransient<IIdentityService, IdentityService>()
                    .AddTransient<ITokenGeneratorService, TokenGeneratorService>();

            services
               .AddRefitClient<INutritionRegisterService>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri(serviceEndpoints.Nutrition));

            services
               .AddRefitClient<IExercisesRegisterService>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri(serviceEndpoints.Exercises));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env);
        }
    }
}
