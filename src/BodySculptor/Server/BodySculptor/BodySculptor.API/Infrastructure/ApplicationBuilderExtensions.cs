namespace BodySculptor.API.Infrastructure
{
    using BodySculptor.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static void AppMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<BodySculptorDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
