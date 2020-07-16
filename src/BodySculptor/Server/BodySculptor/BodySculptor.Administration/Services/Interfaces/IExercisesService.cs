namespace BodySculptor.Administration.Services.Interfaces
{
    using BodySculptor.Administration.Models.Exercises;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IExercisesService
    {
        [Get("/api/Exercises")]
        Task<IEnumerable<ExerciseDto>> GetExercises();
    }
}
