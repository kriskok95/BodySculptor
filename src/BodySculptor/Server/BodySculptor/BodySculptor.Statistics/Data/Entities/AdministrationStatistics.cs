namespace BodySculptor.Statistics.Data.Entities
{
    using BodySculptor.Common.Data.Entities;

    public class AdministrationStatistics : BaseModel<int>
    {
        public int TotalTrainingSessions { get; set; }

        public int TotalDailyMenus { get; set; }
    }
}
