namespace BodySculptor.Articles.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : BaseModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
