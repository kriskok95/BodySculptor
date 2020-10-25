namespace BodySculptor.Identity.Infrastructure
{
    using BodySculptor.Identity.Data;
    using BodySculptor.Identity.Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserStorage(
            this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                })
                   .AddEntityFrameworkStores<IdentityDbContext>();

            return services;
        }
    }
}
