namespace BodySculptor.Exercises.Data.Configurations
{
    using BodySculptor.Exercises.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ExerciseExercisePracticesConfiguration : IEntityTypeConfiguration<ExerciseExercisePractices>
    {
        public void Configure(EntityTypeBuilder<ExerciseExercisePractices> builder)
        {
            builder
                .HasOne(x => x.Exercise)
                .WithMany(x => x.ExerciseExercisePractices)
                .HasForeignKey(x => x.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.ExercisePractice)
                .WithMany(x => x.ExerciseExercisePractices)
                .HasForeignKey(x => x.ExercisePracticeId);

            builder
                .HasKey(x => new { x.ExercisePracticeId, x.ExerciseId });
        }
    }
}
