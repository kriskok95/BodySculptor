namespace BodySculptor.Nutrition.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;

    public class User : BaseModel<int>
    {
        public ICollection<DailyMenu> DailyMenus { get; set; }

        public string UserId { get; set; }
    }
}
