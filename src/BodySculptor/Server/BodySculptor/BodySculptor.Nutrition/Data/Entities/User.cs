namespace BodySculptor.Nutrition.Data.Entities
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public ICollection<DailyMenu> DailyMenus { get; set; }

        public string UserId { get; set; }
    }
}
