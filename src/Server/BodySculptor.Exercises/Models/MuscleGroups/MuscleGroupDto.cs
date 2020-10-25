namespace BodySculptor.Exercises.Models.MuscleGroups
{
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class MuscleGroupDto : IMapFrom<MuscleGroup>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
