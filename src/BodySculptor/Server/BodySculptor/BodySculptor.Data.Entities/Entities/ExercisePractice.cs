namespace BodySculptor.Data.Entities.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ExercisePractice : BaseModel<int>
    {
        [Required]
        public int Reps { get; set; }

        public int Sets { get; set; }

        [Required]
        public int SecondsDuration { get; set; }

        public int ExerciseId { get; set; }
        [Required]
        public Exercise Exercise { get; set; }

        public int TrainingSessionId { get; set; }
        public TrainingSession TrainingSession { get; set; }

        public int UserId { get; set; }
        [Required]
        public User User { get; set; }

        public ICollection<ExerciseExercisePractices> ExerciseExercisePractices { get; set; }
    }
}
