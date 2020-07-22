namespace BodySculptor.Statistics.Messages
{
    using BodySculptor.Common.Messages.Exercises;
    using BodySculptor.Statistics.Services.Interfaces;
    using MassTransit;
    using System.Threading.Tasks;

    public class ExerciseCreatedConsumer : IConsumer<ExerciseCreatedMessage>
    {
        private readonly IClientStatisticsService clientStatisticsService;

        public ExerciseCreatedConsumer(IClientStatisticsService clientStatisticsService)
        {
            this.clientStatisticsService = clientStatisticsService;
        }

        public async Task Consume(ConsumeContext<ExerciseCreatedMessage> context)
        {
            await this.clientStatisticsService.CreateExerciseAsync();
        }
    }
}
