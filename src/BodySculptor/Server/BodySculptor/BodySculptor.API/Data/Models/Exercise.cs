namespace BodySculptor.API.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Exercise : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public byte[] Image { get; set; }

        public int CaloriesBurned { get; set; }

        public int MainMuscleGroupId { get; set; }
        public MuscleGroup MainMuscleGroup { get; set; }

        public int SecondaryMuscleGroupsId { get; set; }
        public ICollection<MuscleGroup> SecondaryMuscleGroups { get; set; }

        public ICollection<ExerciseExercisePractices> ExerciseExercisePractices { get; set; }
    }
}
