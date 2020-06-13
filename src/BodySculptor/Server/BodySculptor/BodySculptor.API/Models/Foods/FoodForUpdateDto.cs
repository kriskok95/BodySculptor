namespace BodySculptor.API.Models.Foods
{
    using System.ComponentModel.DataAnnotations;
    public class FoodForUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int FoodCategoryId { get; set; }

        [Required]
        public decimal Calories { get; set; }

        [Required]
        public decimal Carbs { get; set; }

        [Required]
        public decimal Proteins { get; set; }

        [Required]
        public decimal Fats { get; set; }
    }
}
