namespace BodySculptor.Nutrition.Models.DailyMenus
{
    using AutoMapper;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.Collections.Generic;

    public class DailyMenuDto : IMapFrom<DailyMenu>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public IEnumerable<DailyMenuFoodDto> DailyMenuFoods { get; set; }

        public decimal Water { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DailyMenu, DailyMenuDto>()
                 .ForMember(x => x.Date, y => y.MapFrom(x => x.Date.ToString("dd-MM yyyy")));
        }
    }
}
