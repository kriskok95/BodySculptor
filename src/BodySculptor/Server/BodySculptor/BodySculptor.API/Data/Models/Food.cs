namespace BodySculptor.API.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Food : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory {get;set;}

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
