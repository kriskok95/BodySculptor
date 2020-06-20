namespace BodySculptor.Nutrition.Models
{
    using AutoMapper;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class FoodDto : IMapFrom<Food>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FoodCategory { get; set; }

        public decimal Calories { get; set; }

        public decimal Carbs { get; set; }

        public decimal Proteins { get; set; }

        public decimal Fats { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Food, FoodDto>()
                .ForMember(foodDto => foodDto.FoodCategory, x => x.MapFrom(category => category.FoodCategory.Name))
                .ForMember(foodDto => foodDto.Id, x => x.MapFrom(x => x.Id));
        }
    }
}
