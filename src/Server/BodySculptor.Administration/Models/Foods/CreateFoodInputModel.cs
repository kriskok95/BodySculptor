namespace BodySculptor.Administration.Models.Foods
{
    using System.ComponentModel.DataAnnotations;

    public class CreateFoodInputModel
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
