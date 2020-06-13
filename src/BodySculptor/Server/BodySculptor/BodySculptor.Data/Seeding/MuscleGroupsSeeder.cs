namespace BodySculptor.Data.Seeding
{
    using BodySculptor.Data.Entities.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class MuscleGroupsSeeder : ISeeder
    {
        public async Task SeedAsync(BodySculptorDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.MuscleGroups.AnyAsync())
            {
                return;
            }

            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Chest", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Lats", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Traps", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Tricpes", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Gluteus", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Harmstrings", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Calves", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Shoulders", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Biceps", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Forearm", CreatedOn = DateTime.UtcNow });
            await dbContext.MuscleGroups.AddAsync(new MuscleGroup { Name = "Abs", CreatedOn = DateTime.UtcNow });
        }
    }
}
