namespace BodySculptor.Exercises.Services.Interfaces
{
    using BodySculptor.Common.Services.Intefraces;
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Exercises.Models.TrainingSessions;
    using System.Threading.Tasks;

    public interface ITrainingSessionsService : IDataService<TrainingSession>
    {
        Task<TrainingSessionDto> CreateTrainingSessionAsync(string userId, TrainingSessionInputModel input);
    }
}
