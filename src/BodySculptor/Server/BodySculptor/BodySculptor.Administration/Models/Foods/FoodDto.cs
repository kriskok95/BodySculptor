namespace BodySculptor.Administration.Models.Foods
{
    public class FoodDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FoodCategory { get; set; }

        public decimal Calories { get; set; }

        public decimal Carbs { get; set; }

        public decimal Proteins { get; set; }

        public decimal Fats { get; set; }
    }
}
