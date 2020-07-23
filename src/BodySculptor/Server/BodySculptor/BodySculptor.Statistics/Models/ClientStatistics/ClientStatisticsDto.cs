namespace BodySculptor.Statistics.Models.ClientStatistics
{
    using BodySculptor.Services.Mapping;
    using BodySculptor.Statistics.Data.Entities;

    public class ClientStatisticsDto : IMapFrom<ClientStatistics>
    {
        public int TotalFoods { get; set; }

        public int TotalExercises { get; set; }

        public int TotalArticles { get; set; }
    }
}
