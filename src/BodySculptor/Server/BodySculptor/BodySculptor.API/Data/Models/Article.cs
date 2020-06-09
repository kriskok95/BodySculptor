namespace BodySculptor.API.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Article : BaseModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public int AuthorId { get; set; }
        [Required]
        public User Author { get; set; }
    }
}
