namespace BodySculptor.Nutrition.Models.DailyMenus
{
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class CreateDailyMenuFoodInputModel : IMapTo<DailyMenuFood>
    {
        public int FoodId { get; set; }

        public int Amount { get; set; }
    }
}
