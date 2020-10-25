namespace BodySculptor.Exercises.Services
{
    using BodySculptor.Common.Data.Entities;
    using BodySculptor.Common.Messages.Statistics;
    using BodySculptor.Common.Services;
    using BodySculptor.Exercises.Data;
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Exercises.Models.TrainingSessions;
    using BodySculptor.Exercises.Services.Interfaces;
    using BodySculptor.Services.Mapping;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class TrainingSessionsService : DataService<TrainingSession>, ITrainingSessionsService
    {
        private readonly ExercisesDbContext context;
        private readonly IBus publisher;

        public TrainingSessionsService(ExercisesDbContext context, IBus publisher)
            :base(context)
        {
            this.context = context;
            this.publisher = publisher;
        }

        public async Task<TrainingSessionDto> CreateTrainingSessionAsync(string userId, TrainingSessionInputModel input)
        {
            var trainingSessionForDb = input.MapTo<TrainingSession>();

            trainingSessionForDb.UserId = userId;

            var messageData = new TrainingSessionCreatedMessage { TrainingSessionId = trainingSessionForDb.Id };

            var message = new Message(messageData);

            await this.Save(trainingSessionForDb, message);

            await this.publisher.Publish(messageData);

            await this.MarkMessageAsPublished(message.Id);

            var trainingSessionFromDb = await this.context
                .TrainingSessions
                .Include(x => x.ExercisePractices)
                .FirstOrDefaultAsync(x => x.Id == trainingSessionForDb.Id);

            var trainingSessionToReturn = trainingSessionFromDb
                .MapTo<TrainingSessionDto>();

            return trainingSessionToReturn;
        }
    }
}
