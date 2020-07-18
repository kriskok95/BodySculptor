namespace BodySculptor.Articles.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Article : BaseModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
        public string AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<ArticleRating> ArticleRatings { get; set; }

        public ICollection<Comment> Comments{ get; set; }
    }
}
