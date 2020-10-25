namespace BodySculptor.Nutrition.Models.DailyMenus
{
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class EditDailyMenuFoodInputModel : IMapTo<DailyMenuFood>
    {
        public int FoodId { get; set; }

        public int Amount { get; set; }
    }
}
