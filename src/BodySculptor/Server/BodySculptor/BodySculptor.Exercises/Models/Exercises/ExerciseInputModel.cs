namespace BodySculptor.Exercises.Models.Exercises
{
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ExerciseInputModel : IMapTo<Exercise>
    {
        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int MainMuscleGroupId { get; set; }

        public IEnumerable<int> SecondaryMuscleGroups{ get; set; }
    }
}
