namespace BodySculptor.Nutrition.Models
{
    using AutoMapper;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class FoodForUpdateDto : IMapTo<Food>, IHaveCustomMappings
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int FoodCategoryId { get; set; }

        [Required]
        public decimal Calories { get; set; }

        [Required]
        public decimal Carbs { get; set; }

        [Required]
        public decimal Proteins { get; set; }

        [Required]
        public decimal Fats { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<FoodForUpdateDto, Food>()
                .ForMember(Food => Food.ModifiedOn, x => x.MapFrom(modifiedOn => DateTime.UtcNow));
        }
    }
}
