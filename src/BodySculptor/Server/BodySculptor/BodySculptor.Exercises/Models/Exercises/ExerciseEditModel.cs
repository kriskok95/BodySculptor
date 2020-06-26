namespace BodySculptor.Exercises.Models.Exercises
{
    using AutoMapper;
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ExerciseEditModel : IMapTo<Exercise>, IHaveCustomMappings
    {
        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int MainMuscleGroupId { get; set; }

        public IEnumerable<MuscleGroupExercisesEditModel> SecondaryMuscleGroups { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ExerciseEditModel, Exercise>()
                .ForMember(x => x.SecondaryMuscleGroupExercises, y => y.MapFrom(x => x.SecondaryMuscleGroups.Select(x => x)));
        }
    }
}
