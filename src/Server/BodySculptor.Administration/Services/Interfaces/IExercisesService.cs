namespace BodySculptor.Administration.Services.Interfaces
{
    using BodySculptor.Administration.Models.Exercises;
    using BodySculptor.Administration.Models.MuscleGroups;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IExercisesService
    {
        [Get("/api/Exercises")]
        Task<ApiResponse<IEnumerable<ExerciseDto>>> GetExercises();

        [Get("/api/Exercises/{exerciseId}")]
        Task<ApiResponse<ExerciseDto>> GetExerciseById(string exerciseId);

        [Get("/api/MuscleGroups")]
        Task<ApiResponse<IEnumerable<MuscleGroupDto>>> GetMuscleGroups();

        [Headers("Content-Type: application/json")]
        [Put("/api/Exercises/{exerciseId}")]
        Task<ApiResponse<ExerciseDto>> EditExercise(string exerciseId, [Body] EditExerciseInputModel model);

        [Headers("Content-Type: application/json")]
        [Post("/api/Exercises")]
        Task<ApiResponse<ExerciseDto>> CreateExercise([Body] CreateExerciseInputModel model);

        [Delete("/api/Exercises/{exerciseId}")]
        Task DeleteExercise(string exerciseId);
    }
}
