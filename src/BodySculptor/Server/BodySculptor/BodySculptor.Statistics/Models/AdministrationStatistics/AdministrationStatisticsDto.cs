namespace BodySculptor.Statistics.Models.AdministrationStatistics
{
    using BodySculptor.Services.Mapping;
    using BodySculptor.Statistics.Data.Entities;

    public class AdministrationStatisticsDto : IMapFrom<AdministrationStatistics>
    {
        public int TotalTrainingSessions { get; set; }

        public int TotalDailyMenus { get; set; }
    }
}
