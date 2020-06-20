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

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebService<IdentityDbContext>(this.Configuration)
                .AddUserStorage();

            services.AddTransient<IIdentityService, IdentityService>()
                    .AddTransient<ITokenGeneratorService, TokenGeneratorService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env);
        }
    }
}
