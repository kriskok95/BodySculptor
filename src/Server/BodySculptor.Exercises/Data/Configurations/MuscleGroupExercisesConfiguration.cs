namespace BodySculptor.Exercises.Data.Configurations
{
    using BodySculptor.Exercises.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MuscleGroupExercisesConfiguration : IEntityTypeConfiguration<MuscleGroupExercises>
    {
        public void Configure(EntityTypeBuilder<MuscleGroupExercises> builder)
        {
            builder
                .HasOne(x => x.Exercise)
                .WithMany(x => x.SecondaryMuscleGroupExercises)
                .HasForeignKey(x => x.ExerciseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.MuscleGroup)
                .WithMany(x => x.SecondaryMuscleGroupExercises)
                .HasForeignKey(x => x.MuscleGroupId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasKey(x => new { x.ExerciseId, x.MuscleGroupId });
        }
    }
}
