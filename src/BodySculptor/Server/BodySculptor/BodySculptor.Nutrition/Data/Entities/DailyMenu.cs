﻿namespace BodySculptor.Nutrition.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DailyMenu : BaseModel<int>
    {
        [Required]
        public IEnumerable<Food> Foods { get; set; }

        [Required]
        public decimal Water { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}