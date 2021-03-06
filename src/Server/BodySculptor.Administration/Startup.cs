namespace BodySculptor.Administration
{
    using BodySculptor.Administration.Infrastructure;
    using BodySculptor.Administration.Models.Identity;
    using BodySculptor.Administration.Services;
    using BodySculptor.Administration.Services.Interfaces;
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Common.Services;
    using BodySculptor.Common.Services.Intefraces;
    using BodySculptor.Services.Mapping;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Refit;
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
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services.AddTokenAuthentication(this.Configuration)
                    .AddScoped<ICurrentTokenService, CurrentTokenService>()
                    .AddTransient<JwtCookieAuthenticationMiddleware>()
                    .AddControllersWithViews(options =>
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services
               .AddRefitClient<IIdentityService>()
               .WithConfiguration(serviceEndpoints.Identity);

            services
                .AddRefitClient<INutritionService>()
                .WithConfiguration(serviceEndpoints.Nutrition);

            services
                .AddRefitClient<IExercisesService>()
                .WithConfiguration(serviceEndpoints.Exercises);

            services
                .AddRefitClient<IArticlesService>()
                .WithConfiguration(serviceEndpoints.Articles);

            services
                .AddRefitClient<IStatisticsService>()
                .WithConfiguration(serviceEndpoints.Statistics);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig
                .RegisterMappings(typeof(LoginFormModel)
                .GetTypeInfo()
                .Assembly);

            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage();
            }
            else
            {
                app
                    .UseExceptionHandler("/Home/Error")
                    .UseHsts();
            }

            app
                //.UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseJwtCookieAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapDefaultControllerRoute());
        }
    }
}
