namespace BodySculptor.Gateway.Models.ArticlesStatistics
{
    using BodySculptor.Gateway.Models.Articles;
    using BodySculptor.Gateway.Models.Statistics;
    using System.Collections.Generic;

    public class ArticlesStatisticsDto
    {
        public ClientStatisticsDto ClientStatistics { get; set; }

        public IEnumerable<ArticleDto> Articles { get; set; }
    }
}
