namespace BodySculptor.Exercises.Data.Entities
{
    using BodySculptor.Data.Entities.Entities;
    using System.Collections.Generic;

    public class MuscleGroup : BaseModel<int>
    {
        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public ICollection<MuscleGroupExercises> SecondaryMuscleGroupExercises { get; set; }
    }
}
