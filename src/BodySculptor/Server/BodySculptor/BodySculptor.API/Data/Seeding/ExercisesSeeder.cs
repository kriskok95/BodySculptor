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

            //Shoulders
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Arnold Dumbbell Presses", MainMuscleGroupId = 1 });
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Machine Rear Deltoid Fly", MainMuscleGroupId = 1 });

            //Calves
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Calf Raises", MainMuscleGroupId = 2 });

            //Hamstrings
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Barbell Straight Leg Deadlift", MainMuscleGroupId = 3 });

            //Gluteus
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Barbell Front Squats", MainMuscleGroupId = 4 });

            //Tricpes
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Close Grip Presses", MainMuscleGroupId = 5 });

            //Traps
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Barbell Shrugs", MainMuscleGroupId = 6 });

            //Lats
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Close Grip Chins", MainMuscleGroupId = 7 });

            //Chest
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Barbell Flat Bench Presses", MainMuscleGroupId = 8 });
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Barbell Incline Bench Presses", MainMuscleGroupId = 8 });
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Close Grip Pushups", MainMuscleGroupId = 8 });
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Decline Barbell Presses", MainMuscleGroupId = 8 });
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Dumbbell Flat Bench Presses", MainMuscleGroupId = 8 });

            //Biceps
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Double Arm Can Curls", MainMuscleGroupId = 9 });

            //Forearm
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Reverse Barbell Curls", MainMuscleGroupId = 10 });

            //Abs
            await dbContext.Exercises.AddAsync(new Exercise { Name = "Crunches", MainMuscleGroupId = 1 });
        }
    }
}
