namespace BodySculptor.API.Data.Seeding
{
    using BodySculptor.API.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class MuscleGroupExercisesSeeder : ISeeder
    {
        public async Task SeedAsync(BodySculptorDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.MuscleGroupExercises.AnyAsync())
            {
                return;
            }

            //Shoulders
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 1, MuscleGroupId = 5 });
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 2, MuscleGroupId = 6 });

            //Calves

            //Hamstrings
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 3, MuscleGroupId = 7 });
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 3, MuscleGroupId = 1 });

            //Gluteus
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 5, MuscleGroupId = 6 });

            //Tricpes
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 6, MuscleGroupId = 1 });
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 6, MuscleGroupId = 8 });

            //Traps
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 7, MuscleGroupId = 10 });

            //Lats
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 8, MuscleGroupId = 9 });

            //Chest
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 9, MuscleGroupId = 6 });
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 10, MuscleGroupId = 6 });

            //Biceps
            await dbContext.MuscleGroupExercises.AddAsync(new MuscleGroupExercises { ExerciseId = 14, MuscleGroupId = 10 });

            //Forearm

            //Abs
        }
    }
}
