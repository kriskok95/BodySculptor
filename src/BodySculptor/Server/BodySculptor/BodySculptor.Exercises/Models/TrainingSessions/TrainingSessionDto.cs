namespace BodySculptor.Exercises.Models.TrainingSessions
{
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.Collections.Generic;

    public class TrainingSessionDto : IMapFrom<TrainingSession>
    {
        public IEnumerable<ExercisePracticeDto> ExercisePractices { get; set; }

        public int TimeSpendSeconds { get; set; }

        public int TotalCaloriesBurned { get; set; }
    }
}
