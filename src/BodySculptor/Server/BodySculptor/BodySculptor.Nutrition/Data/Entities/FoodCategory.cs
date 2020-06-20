namespace BodySculptor.Nutrition.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FoodCategory : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
