namespace BodySculptor.Nutrition.Infrastructure.Profiles
{
    using AutoMapper;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Nutrition.Models;
    using System;

    public class FoodsProfile : Profile
    {
        public FoodsProfile()
        {
            CreateMap<Food, FoodDto>()
                .ForMember(foodDto => foodDto.FoodCategory, x => x.MapFrom(category => category.FoodCategory.Name))
                .ForMember(foodDto => foodDto.Id, x => x.MapFrom(x => x.Id));

            CreateMap<FoodForCreationDto, Food>();

            CreateMap<FoodForUpdateDto, Food>()
                .ForMember(Food => Food.ModifiedOn, x => x.MapFrom(modifiedOn => DateTime.UtcNow));
        }
    }
}
