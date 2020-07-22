namespace BodySculptor.Statistics.Messages
{
    using BodySculptor.Common.Messages.Articles;
    using BodySculptor.Statistics.Services.Interfaces;
    using MassTransit;
    using System.Threading.Tasks;

    public class ArticleCreatedConsumer : IConsumer<ArticlesCreatedMessage>
    {
        private readonly IClientStatisticsService clientStatisticsService;

        public ArticleCreatedConsumer(IClientStatisticsService clientStatisticsService)
        {
            this.clientStatisticsService = clientStatisticsService;
        }

        public async Task Consume(ConsumeContext<ArticlesCreatedMessage> context)
        {
            await this.clientStatisticsService.CreateArticleAsync();
        }
    }
}
