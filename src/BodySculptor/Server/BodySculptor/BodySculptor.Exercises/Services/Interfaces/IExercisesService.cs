namespace BodySculptor.Exercises.Services.Interfaces
{
    using BodySculptor.Common.Services.Intefraces;
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Exercises.Models.Exercises;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IExercisesService : IDataService<Exercise>
    {
        Task<IEnumerable<ExerciseDto>> GetAllExercisesAsync();

        Task<IEnumerable<ExerciseDto>> GetAllByMuscleGroupAsync(int muscleGroupId);

        Task<bool> IsExistsByIdAsync(int exerciseId);

        Task<ExerciseDto> GetExerciseByIdAsync(int exerciseId);

        Task<ExerciseDto> CreateExerciseAsync(ExerciseInputModel input);

        Task<bool> IsExerciseExistsByName(string name);

        Task<ExerciseDto> EditExerciseAsync(int exerciseId, ExerciseEditModel input);

        Task DeleteExerciseByIdAsync(int exerciseId);
    }
}
