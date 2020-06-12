namespace BodySculptor.API.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Exercise : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public byte[] Image { get; set; }

        public int MainMuscleGroupId { get; set; }
        public MuscleGroup MainMuscleGroup { get; set; }

        public ICollection<MuscleGroupExercises> SecondaryMuscleGroupExercises { get; set; }

        public ICollection<ExerciseExercisePractices> ExerciseExercisePractices { get; set; }
    }
}
