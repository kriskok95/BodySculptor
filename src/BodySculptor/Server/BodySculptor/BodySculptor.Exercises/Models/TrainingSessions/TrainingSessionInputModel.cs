namespace BodySculptor.Exercises.Models.TrainingSessions
{
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.Collections.Generic;

    public class TrainingSessionInputModel : IMapTo<TrainingSession>
    {
        public IEnumerable<ExercisePracticeInputModel> ExercisePractices { get; set; }
    }
}
