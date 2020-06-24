namespace BodySculptor.Exercises.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : BaseModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public ICollection<ExercisePractice> ExercisePractices { get; set; }

        public ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
