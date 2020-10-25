namespace BodySculptor.Articles.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.ComponentModel.DataAnnotations;

    public class Comment : BaseModel<int>
    {
        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
