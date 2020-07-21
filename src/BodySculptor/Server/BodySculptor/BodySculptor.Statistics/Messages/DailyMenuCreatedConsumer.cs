namespace BodySculptor.Statistics.Messages
{
    using BodySculptor.Common.Messages.Statistics;
    using BodySculptor.Statistics.Services.Interfaces;
    using MassTransit;
    using System.Threading.Tasks;

    public class DailyMenuCreatedConsumer : IConsumer<DailyMenuCreatedMessage>
    {
        private readonly IAdministraionStatisticsService administraionStatisticsService;

        public DailyMenuCreatedConsumer(IAdministraionStatisticsService administraionStatisticsService)
        {
            this.administraionStatisticsService = administraionStatisticsService;
        }

        public async Task Consume(ConsumeContext<DailyMenuCreatedMessage> context)
        {
            var message = context.Message;

            var result = await this.administraionStatisticsService.CreateDailyMenu(message.UserId);
        }
    }
}
