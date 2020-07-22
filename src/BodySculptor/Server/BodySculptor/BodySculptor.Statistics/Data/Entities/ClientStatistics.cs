namespace BodySculptor.Statistics.Data.Entities
{
    using BodySculptor.Common.Data.Entities;

    public class ClientStatistics : BaseModel<int>
    {
        public int TotalFoods { get; set; }

        public int TotalExercises { get; set; }

        public int TotalArticles { get; set; }
    }
}
