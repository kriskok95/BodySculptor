namespace BodySculptor.Administration.Models.Exercises
{
    using System.Collections.Generic;

    public class CreateExerciseInputModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int MainMuscleGroupId { get; set; }

        public IEnumerable<int> SecondaryMuscleGroups { get; set; }
    }
}
