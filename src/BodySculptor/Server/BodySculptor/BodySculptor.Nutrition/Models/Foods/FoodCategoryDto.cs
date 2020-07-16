namespace BodySculptor.Nutrition.Models.Foods
{
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class FoodCategoryDto : IMapFrom<FoodCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
