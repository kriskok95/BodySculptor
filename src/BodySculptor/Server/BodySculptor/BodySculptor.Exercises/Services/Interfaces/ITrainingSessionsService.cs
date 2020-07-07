namespace BodySculptor.Exercises.Services.Interfaces
{
    using BodySculptor.Exercises.Models.TrainingSessions;
    using System.Threading.Tasks;

    public interface ITrainingSessionsService
    {
        Task<TrainingSessionDto> CreateTrainingSessionAsync(string userId, TrainingSessionInputModel input);
    }
}
