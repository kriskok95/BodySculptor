namespace BodySculptor.Gateway.Services.Interfaces
{
    using BodySculptor.Gateway.Models.Articles;
    using BodySculptor.Gateway.Models.ArticlesStatistics;
    using BodySculptor.Gateway.Models.Statistics;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesStatisticsService
    {
        ArticlesStatisticsDto GetArticlesStatisticsDto(IEnumerable<ArticleDto> articles, ClientStatisticsDto clientStatistics);
    }
}
