namespace BodySculptor.Nutrition.Models.DailyMenus
{
    using AutoMapper;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateDailyMenuInputModel : IMapTo<DailyMenu>
    {
        public IEnumerable<CreateDailyMenuFoodInputModel> DailyMenuFoods { get; set; }

        public decimal Water { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
