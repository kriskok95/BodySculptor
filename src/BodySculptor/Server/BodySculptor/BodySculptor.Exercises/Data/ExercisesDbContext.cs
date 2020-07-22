namespace BodySculptor.Exercises.Data
{
    using BodySculptor.Common.Data;
    using BodySculptor.Exercises.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class ExercisesDbContext : MessageDbContext
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

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
