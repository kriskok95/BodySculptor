namespace BodySculptor.Exercises.Data.Entities
{
    public class MuscleGroupExercises
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int MuscleGroupId { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
