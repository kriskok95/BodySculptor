﻿namespace BodySculptor.Exercises.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TrainingSession : BaseModel<int>
    {
        public IEnumerable<ExercisePractice> ExercisePractices { get; set; }

        [Required]
        public int TimeSpendSeconds { get; set; }

        [Required]
        public int TotalCaloriesBurned { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
