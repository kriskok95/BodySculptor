namespace BodySculptor.Exercises.Data.Entities
{
    using BodySculptor.Common.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Exercise : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int MainMuscleGroupId { get; set; }
        public MuscleGroup MainMuscleGroup { get; set; }

        public ICollection<MuscleGroupExercises> SecondaryMuscleGroupExercises { get; set; }

        public ICollection<ExerciseExercisePractices> ExerciseExercisePractices { get; set; }
    }
}
