namespace BodySculptor.Exercises.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ExercisePractice : BaseModel<int>
    {
        [Required]
        public int Reps { get; set; }

        public int Sets { get; set; }

        [Required]
        public int SecondsDuration { get; set; }

        public int TrainingSessionId { get; set; }
        public TrainingSession TrainingSession { get; set; }

        public ICollection<ExerciseExercisePractices> ExerciseExercisePractices { get; set; }
    }
}
