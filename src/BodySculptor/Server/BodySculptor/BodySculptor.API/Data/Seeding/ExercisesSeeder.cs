namespace BodySculptor.API.Data.Seeding
{
    using BodySculptor.API.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExercisesSeeder : ISeeder
    {
        public async Task SeedAsync(BodySculptorDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Exercises.AnyAsync())
            {
                return;
            }

            //Chest
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Barbell Flat Bench Presses", MainMuscleGroupId = 1,  SecondaryMuscleGroupsId = new List<int> {4, 8 },  })
        }
    }
}
