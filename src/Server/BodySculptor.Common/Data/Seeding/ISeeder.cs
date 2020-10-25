namespace BodySculptor.Common.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder<TDbContext>
    {
        Task SeedAsync(TDbContext dbContext, IServiceProvider serviceProvider);
    }
}
