namespace BodySculptor.Statistics.Messages
{
    using BodySculptor.Common.Messages.Statistics;
    using BodySculptor.Statistics.Services.Interfaces;
    using MassTransit;
    using System.Threading.Tasks;

    public class TrainingSessionCreatedConsumer : IConsumer<TrainingSessionCreatedMessage>
    {
        private readonly IAdministraionStatisticsService administraionStatisticsService;

        public TrainingSessionCreatedConsumer(IAdministraionStatisticsService administraionStatisticsService)
        {
            this.administraionStatisticsService = administraionStatisticsService;
        }

        public async Task Consume(ConsumeContext<TrainingSessionCreatedMessage> context)
        {
            var message = context.Message;

            await this.administraionStatisticsService.CreateTrainingSession(message.TrainingSessionId);
        }
    }
}
