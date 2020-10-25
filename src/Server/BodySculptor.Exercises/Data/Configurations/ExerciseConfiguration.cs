namespace BodySculptor.Exercises.Data.Configurations
{
    using BodySculptor.Exercises.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .HasOne(x => x.MainMuscleGroup)
                .WithMany(x => x.Exercises)
                .HasForeignKey(x => x.MainMuscleGroupId);
        }
    }
}
