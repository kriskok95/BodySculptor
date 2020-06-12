namespace BodySculptor.API.Profiles
{
    using AutoMapper;
    using BodySculptor.API.Data.Models;
    using BodySculptor.API.Models.Foods;

    public class FoodsProfile : Profile
    {
        public FoodsProfile()
        {
            CreateMap<Food, FoodDto>()
                .ForMember(foodDto => foodDto.FoodCategory, x => x.MapFrom(category => category.FoodCategory.Name))
                .ForMember(foodDto => foodDto.Id, x => x.MapFrom(x => x.Id));
            CreateMap<FoodForCreationDto, Food>();
        }
    }
}
