namespace BodySculptor.Gateway.Services
{
    using BodySculptor.Gateway.Models.Articles;
    using BodySculptor.Gateway.Models.ArticlesStatistics;
    using BodySculptor.Gateway.Models.Statistics;
    using BodySculptor.Gateway.Services.Interfaces;
    using System.Collections.Generic;

    public class ArticlesStatisticsService : IArticlesStatisticsService
    {
        public ArticlesStatisticsDto GetArticlesStatisticsDto(IEnumerable<ArticleDto> articles, ClientStatisticsDto clientStatistics)
        {
            var articleStatisticsDto = new ArticlesStatisticsDto
            {
                Articles = articles,
                ClientStatistics = clientStatistics
            };

            return articleStatisticsDto;
        }
    }
}
