namespace BodySculptor.API.Data.Seeding
{
    using System;
    using System.Threading.Tasks;


    public interface ISeeder
    {
        Task SeedAsync(BodySculptorDbContext dbContext, IServiceProvider serviceProvider);
    }
}
