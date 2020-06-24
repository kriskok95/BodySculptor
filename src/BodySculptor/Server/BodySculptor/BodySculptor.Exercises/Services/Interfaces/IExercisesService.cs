namespace BodySculptor.Exercises.Services.Interfaces
{
    using BodySculptor.Exercises.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IExercisesService
    {
        Task<IEnumerable<ExerciseDto>> GetAllExercisesAsync();

        Task<IEnumerable<ExerciseDto>> GetAllByMuscleGroupAsync(int muscleGroupId);

        Task<bool> IsExistsByIdAsync(int exerciseId);

        Task<ExerciseDto> GetExerciseByIdAsync(int exerciseId);
    }
}
