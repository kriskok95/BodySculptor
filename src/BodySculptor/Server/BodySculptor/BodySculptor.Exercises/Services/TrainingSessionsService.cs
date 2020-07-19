namespace BodySculptor.Exercises.Services
{
    using BodySculptor.Common.Messages.Statistics;
    using BodySculptor.Exercises.Data;
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Exercises.Models.TrainingSessions;
    using BodySculptor.Exercises.Services.Interfaces;
    using BodySculptor.Services.Mapping;
    using MassTransit;
    using System.Threading.Tasks;

    public class TrainingSessionsService : ITrainingSessionsService
    {
        private readonly ExercisesDbContext context;
        private readonly IBus publisher;

        public TrainingSessionsService(ExercisesDbContext context, IBus publisher)
        {
            this.context = context;
            this.publisher = publisher;
        }

        public async Task<TrainingSessionDto> CreateTrainingSessionAsync(string userId, TrainingSessionInputModel input)
        {
            //TODO: Fix the bug with FK

            var trainingSessionForDb = input.MapTo<TrainingSession>();

            await this.context
                .TrainingSessions
                .AddAsync(trainingSessionForDb);

            await this.context
                .SaveChangesAsync();

            await this.publisher.Publish(new TrainingSessionCreatedMessage { TrainingSessionId = trainingSessionForDb.Id });

            return null;
        }
    }
}
