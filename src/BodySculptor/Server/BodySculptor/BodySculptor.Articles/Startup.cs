namespace BodySculptor.Articles
{
    using AutoMapper;
    using BodySculptor.Articles.Data;
    using BodySculptor.Articles.Messages;
    using BodySculptor.Articles.Models.Articles;
    using BodySculptor.Articles.Services;
    using BodySculptor.Articles.Services.Interfaces;
    using BodySculptor.Common.Infrastructure;
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
            services.AddWebService<ArticlesDbContext>(this.Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMessaging(this.Configuration, typeof(UserCreatedConsumer));

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IArticlesService, ArticlesService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ArticleDto).GetTypeInfo().Assembly);

            app.UseWebService(env);

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ArticlesDbContext>();

                //if (env.IsDevelopment())
                //{
                    dbContext.Database.Migrate();
                //}
            }
        }
    }
}
