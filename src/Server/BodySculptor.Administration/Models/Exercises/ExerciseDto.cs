namespace BodySculptor.Administration.Models.Exercises
{
    using System.Collections.Generic;

    public class ExerciseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string MainMuscleGroupName { get; set; }

        public IEnumerable<string> SecondaryMuscleGroupNames { get; set; }
    }
}
