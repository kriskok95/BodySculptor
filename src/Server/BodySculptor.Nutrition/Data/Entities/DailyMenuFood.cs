namespace BodySculptor.Nutrition.Data.Entities
{
    using BodySculptor.Common.Data.Entities;

    public class DailyMenuFood : BaseModel<int>
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int Amount { get; set; }

        public int DailyMenuId { get; set; }
        public DailyMenu DailyMenu { get; set; }
    }
}
