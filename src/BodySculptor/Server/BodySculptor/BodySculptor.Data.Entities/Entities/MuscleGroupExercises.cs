namespace BodySculptor.Data.Entities.Entities
{
    public class MuscleGroupExercises
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int MuscleGroupId { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
