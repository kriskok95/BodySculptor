namespace BodySculptor.Statistics.Messages
{
    using BodySculptor.Common.Messages.Nutrition;
    using BodySculptor.Statistics.Services.Interfaces;
    using MassTransit;
    using System.Threading.Tasks;

    public class FoodCreatedConsumer : IConsumer<FoodCreatedMessage>
    {
        private readonly IClientStatisticsService clientStatisticsService;

        public FoodCreatedConsumer(IClientStatisticsService clientStatisticsService)
        {
            this.clientStatisticsService = clientStatisticsService;
        }

        public async Task Consume(ConsumeContext<FoodCreatedMessage> context)
        {
            var message = context.Message;

            await this.clientStatisticsService.CreateFoodAsync(message.FoodName);
        }
    }
}
