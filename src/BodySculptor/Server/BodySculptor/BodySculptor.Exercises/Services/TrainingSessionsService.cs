namespace BodySculptor.Exercises.Services
{
    using BodySculptor.Exercises.Data;
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Exercises.Models.TrainingSessions;
    using BodySculptor.Exercises.Services.Interfaces;
    using BodySculptor.Services.Mapping;
    using System;
    using System.Threading.Tasks;

    public class TrainingSessionsService : ITrainingSessionsService
    {
        private readonly ExercisesDbContext context;

        public TrainingSessionsService(ExercisesDbContext context)
        {
            this.context = context;
        }

        public async Task<TrainingSessionDto> CreateTrainingSessionAsync(string userId, TrainingSessionInputModel input)
        {
            var trainingSessionForDb = input.MapTo<TrainingSession>();

            await this.context
                .TrainingSessions
                .AddAsync(trainingSessionForDb);

            await this.context
                .SaveChangesAsync();

            return null;
        }
    }
}
