namespace BodySculptor.Nutrition.Models.DailyMenus
{
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EditDailyMenuInputModel : IMapTo<DailyMenu>
    {
        public IEnumerable<EditDailyMenuFoodInputModel> DailyMenuFoods { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public decimal Water { get; set; }
    }
}
