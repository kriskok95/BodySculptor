namespace BodySculptor.Nutrition.Models.DailyMenus
{
    using AutoMapper;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class DailyMenuFoodDto : IMapFrom<DailyMenuFood>, IHaveCustomMappings
    {
        public string FoodName { get; set; }

        public string FoodCategory { get; set; }

        public decimal FoodCalories { get; set; }

        public decimal FoodCarbs { get; set; }

        public decimal FoodProteins { get; set; }

        public decimal FoodFats { get; set; }

        public int Amount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DailyMenuFood, DailyMenuFoodDto>()
                .ForMember(x => x.FoodCategory, y => y.MapFrom(x => x.Food.FoodCategory.Name))
                .ForMember(x => x.FoodProteins, y => y.MapFrom(x => x.Food.Proteins * x.Amount / 100))
                .ForMember(x => x.FoodCarbs, y => y.MapFrom(x => x.Food.Carbs * x.Amount / 100))
                .ForMember(x => x.FoodFats, y => y.MapFrom(x => x.Food.Fats * x.Amount / 100))
                .ForMember(x => x.FoodCalories, y => y.MapFrom(x => x.Food.Calories * x.Amount / 100));
        }
    }
}
