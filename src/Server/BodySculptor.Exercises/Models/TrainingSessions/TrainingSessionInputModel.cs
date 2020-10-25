namespace BodySculptor.Exercises.Models.TrainingSessions
{
    using AutoMapper;
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.Collections.Generic;
    using System.Linq;

    public class TrainingSessionInputModel : IMapTo<TrainingSession>, IHaveCustomMappings
    {
        public IEnumerable<ExercisePracticeInputModel> ExercisePractices { get; set; }

        public int TimeSpendSeconds { get; set; }

        public int TotalCaloriesBurned { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<TrainingSessionInputModel, TrainingSession>()
                .ForMember(x => x.TimeSpendSeconds, y => y.MapFrom(x => x.ExercisePractices.Sum(y => y.SecondsDuration)));

        }
    }
}
