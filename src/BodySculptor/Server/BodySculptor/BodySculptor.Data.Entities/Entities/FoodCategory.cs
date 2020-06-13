namespace BodySculptor.Data.Entities.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FoodCategory : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
