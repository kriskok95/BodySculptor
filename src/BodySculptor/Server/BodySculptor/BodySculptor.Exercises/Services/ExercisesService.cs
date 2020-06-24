using BodySculptor.Exercises.Services.Interfaces;

namespace BodySculptor.Exercises.Services
{
    using BodySculptor.Exercises.Data;
    using BodySculptor.Exercises.Models;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
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
    }
}
