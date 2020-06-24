namespace BodySculptor.Articles.Data.Entities
{
    using BodySculptor.Common.Data.Entities;

    public class ArticleRating : BaseModel<int>
    {
        public int Positive { get; set; }

        public int Negative { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
