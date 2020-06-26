namespace BodySculptor.Exercises.Models.Exercises
{
    using AutoMapper;
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.Collections.Generic;
    using System.Linq;

    public class ExerciseDto : IMapFrom<Exercise>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string MainMuscleGroupName { get; set; }

        public IEnumerable<string> SecondaryMuscleGroupNames { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Exercise, ExerciseDto>()
                .ForMember(x => x.SecondaryMuscleGroupNames, y => y.MapFrom(x => x.SecondaryMuscleGroupExercises.Select(x => x.MuscleGroup.Name)));
        }
    }
}
