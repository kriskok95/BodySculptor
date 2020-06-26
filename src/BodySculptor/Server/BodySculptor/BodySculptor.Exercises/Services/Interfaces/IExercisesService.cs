namespace BodySculptor.Exercises.Services.Interfaces
{
    using BodySculptor.Exercises.Models.Exercises;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IExercisesService
    {
        Task<IEnumerable<ExerciseDto>> GetAllExercisesAsync();

        Task<IEnumerable<ExerciseDto>> GetAllByMuscleGroupAsync(int muscleGroupId);

        Task<bool> IsExistsByIdAsync(int exerciseId);

        Task<ExerciseDto> GetExerciseByIdAsync(int exerciseId);

        Task<ExerciseDto> CraeteExercise(ExerciseInputModel input);

        Task<bool> IsExerciseExistsByName(string name);
    }
}
