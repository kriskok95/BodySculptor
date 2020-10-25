namespace BodySculptor.Exercises.Models.Exercises
{
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class MuscleGroupExercisesEditModel : IMapTo<MuscleGroupExercises>
    {
        public int MuscleGroupId { get; set; }
    }
}
