namespace BodySculptor.Nutrition.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Food : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }

        public decimal Calories { get; set; }

        public decimal Carbs { get; set; }

        public decimal Proteins { get; set; }

        public decimal Fats { get; set; }

        public ICollection<DailyMenuFood> DailyMenuFoods { get; set; }
    }
}
