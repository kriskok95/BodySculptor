namespace BodySculptor.Gateway.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Gateway.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ArticlesStatisticsController : ApiController
    {
        private readonly IArticlesService articlesService;
        private readonly IStatisticsService statisticsService;
        private readonly IArticlesStatisticsService articlesStatisticsService;

        public ArticlesStatisticsController(IArticlesService articlesService
            , IStatisticsService statisticsService
            , IArticlesStatisticsService articlesStatisticsService)
        {
            this.articlesService = articlesService;
            this.statisticsService = statisticsService;
            this.articlesStatisticsService = articlesStatisticsService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var articles = await this.articlesService
                .GetArticles();

            var clientStatistics = await this.statisticsService
                .GetClientStatistics();

            var articleStatistics = this.articlesStatisticsService
                .GetArticlesStatisticsDto(articles.Content, clientStatistics.Content);

            return Ok(articleStatistics);
        }
    }
}
