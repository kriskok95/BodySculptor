namespace BodySculptor.Nutrition.Models.DailyMenus
{
    using BodySculptor.Services.Mapping;

    public class CreateDailyMenuFoodInputModel : IMapFrom<CreateDailyMenuInputModel>
    {
        public int FoodId { get; set; }

        public int Amount { get; set; }
    }
}
