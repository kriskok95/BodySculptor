namespace BodySculptor.Nutrition.Models.DailyMenus
{
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.Collections.Generic;

    public class DailyMenuDto : IMapFrom<DailyMenu>
    {
        public int Id { get; set; }

        public IEnumerable<DailyMenuFoodDto> DailyMenuFoods { get; set; }

        public decimal Water { get; set; }
    }
}
