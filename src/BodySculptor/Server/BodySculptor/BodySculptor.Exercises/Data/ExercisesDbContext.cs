namespace BodySculptor.Exercises.Data
{
    using BodySculptor.Exercises.Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ExercisesDbContext : DbContext
    {
        public ExercisesDbContext(DbContextOptions<ExercisesDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseExercisePractices> ExerciseExercisePractices { get; set; }
        public DbSet<TrainingSession> TrainingSessions{ get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<MuscleGroupExercises> MuscleGroupExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Exercise>()
                .HasOne(x => x.MainMuscleGroup)
                .WithMany(x => x.Exercises)
                .HasForeignKey(x => x.MainMuscleGroupId);

            builder.Entity<ExerciseExercisePractices>()
                .HasOne(x => x.Exercise)
                .WithMany(x => x.ExerciseExercisePractices)
                .HasForeignKey(x => x.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExerciseExercisePractices>()
                .HasOne(x => x.ExercisePractice)
                .WithMany(x => x.ExerciseExercisePractices)
                .HasForeignKey(x => x.ExercisePracticeId);


            builder.Entity<ExerciseExercisePractices>()
                .HasKey(x => new { x.ExercisePracticeId, x.ExerciseId });

            builder.Entity<ExercisePractice>()
                .HasOne(x => x.User)
                .WithMany(x => x.ExercisePractices)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MuscleGroupExercises>()
                .HasOne(x => x.Exercise)
                .WithMany(x => x.SecondaryMuscleGroupExercises)
                .HasForeignKey(x => x.ExerciseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MuscleGroupExercises>()
                .HasOne(x => x.MuscleGroup)
                .WithMany(x => x.SecondaryMuscleGroupExercises)
                .HasForeignKey(x => x.MuscleGroupId);

            builder.Entity<MuscleGroupExercises>()
                .HasKey(x => new { x.ExerciseId, x.MuscleGroupId });
        }
    }
}
