namespace BodySculptor.Articles.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;

    public class ArticleRating : BaseModel<int>
    {
        public int Rating { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
