using BodySculptor.Exercises.Services.Interfaces;

namespace BodySculptor.Exercises.Services
{
    using BodySculptor.Exercises.Constants;
    using BodySculptor.Exercises.Data;
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Exercises.Models.Exercises;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExercisesService : IExercisesService
    {
        private readonly ExercisesDbContext context;

        public ExercisesService(ExercisesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ExerciseDto>> GetAllExercisesAsync()
        {
            return await context
                .Exercises
                .To<ExerciseDto>()
                .ToListAsync();
        }

        public async Task<IEnumerable<ExerciseDto>> GetAllByMuscleGroupAsync(int muscleGroupId)
        {
            return await this.context
                .Exercises
                .Where(x => x.MainMuscleGroup.Id == muscleGroupId)
                .To<ExerciseDto>()
                .ToListAsync();
        }

        public async Task<ExerciseDto> GetExerciseByIdAsync(int exerciseId)
        {
            var exerciseFromDb = await this.context
                .Exercises
                .Include(x => x.MainMuscleGroup)
                .Include(x => x.SecondaryMuscleGroupExercises)
                .ThenInclude(x => x.MuscleGroup)
                .FirstOrDefaultAsync(x => x.Id == exerciseId);

            return exerciseFromDb
                .MapTo<ExerciseDto>();
        }

        public async Task<bool> IsExistsByIdAsync(int exerciseId)
        {
            return await this.context
                .Exercises
                .AnyAsync(x => x.Id == exerciseId);
        }

        public async Task<ExerciseDto> CreateExerciseAsync(ExerciseInputModel input)
        {
            var exerciseForDb = input
                .MapTo<Exercise>();

            await this.context
                .Exercises
                .AddAsync(exerciseForDb);

            var muscleGroupExercises = new List<MuscleGroupExercises>();

            foreach (var muscleGroupId in input.SecondaryMuscleGroups)
            {
                var muscleGroupExercise = new MuscleGroupExercises
                {
                    MuscleGroupId = muscleGroupId,
                    Exercise = exerciseForDb
                };

                muscleGroupExercises.Add(muscleGroupExercise);
            }

            await context
                .MuscleGroupExercises
                .AddRangeAsync(muscleGroupExercises);

            await this.context
                .SaveChangesAsync();

            var exerciseFromDb = await this.context
                .Exercises
                .Include(x => x.MainMuscleGroup)
                .Include(x => x.SecondaryMuscleGroupExercises)
                .ThenInclude(x => x.MuscleGroup)
                .FirstOrDefaultAsync(x => x.Name == input.Name);

            return exerciseFromDb
                .MapTo<ExerciseDto>();
        }

        public async Task<ExerciseDto> EditExerciseAsync(int exerciseId, ExerciseEditModel input)
        {
            var exerciseFromDb = await this.context
                .Exercises
                .Include(x => x.MainMuscleGroup)
                .Include(x => x.SecondaryMuscleGroupExercises)
                .ThenInclude(x => x.MuscleGroup)
                .FirstOrDefaultAsync(x => x.Id == exerciseId);

            if(exerciseFromDb == null)
            {
                throw new ArgumentNullException(string.Format(ExercisesConstants.UnexistingExercise, exerciseId));
            }

            var updatedExercise = input
                .MapTo<ExerciseEditModel, Exercise>(exerciseFromDb);

            await this.context
                .SaveChangesAsync();

            var exerciseToReturn = await this.context
                .Exercises
                .Include(x => x.MainMuscleGroup)
                .Include(x => x.SecondaryMuscleGroupExercises)
                .ThenInclude(x => x.MuscleGroup)
                .FirstOrDefaultAsync(x => x.Name == input.Name);

            return exerciseToReturn
                .MapTo<ExerciseDto>();
        }

        public async Task DeleteExerciseByIdAsync(int exerciseId)
        {
            var muscleGroupExercisesToDelete = await context
                .MuscleGroupExercises
                .Where(x => x.ExerciseId == exerciseId)
                .ToListAsync(); ;

            context
                .MuscleGroupExercises
                .RemoveRange(muscleGroupExercisesToDelete);

            var exerciseToDelete = new Exercise { Id = exerciseId };

            this.context
                .Exercises
                .Remove(exerciseToDelete);

            await this.context
                .SaveChangesAsync();
        }

        public async Task<bool> IsExerciseExistsByName(string name)
        {
            return await this.context
                .Exercises
                .AnyAsync(x => x.Name == name);
        }
    }
}
