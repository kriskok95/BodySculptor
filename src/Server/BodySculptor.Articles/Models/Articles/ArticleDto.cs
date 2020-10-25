namespace BodySculptor.Articles.Models.Articles
{
    using BodySculptor.Articles.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class ArticleDto : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorId { get; set; }
    }
}
