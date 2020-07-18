namespace BodySculptor.Articles.Models.Articles
{
    using BodySculptor.Articles.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CreateArticleInputModel : IMapTo<Article>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
