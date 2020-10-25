namespace BodySculptor.Exercises.Models.TrainingSessions
{
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class ExercisePracticeInputModel : IMapTo<ExercisePractice>
    {
        public int Reps { get; set; }

        public int Sets { get; set; }

        public int SecondsDuration { get; set; }

        public int ExerciseId { get; set; }
    }
}
