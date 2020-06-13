namespace BodySculptor.Data.Entities.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TrainingSession : BaseModel<int>
    {
        public IEnumerable<ExercisePractice> ExercisePractices { get; set; }

        [Required]
        public int TimeSpendSeconds { get; set; }

        [Required]
        public int TotalCaloriesBurned { get; set; }

        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
    }
}
