namespace BodySculptor.API.Data
{
    using BodySculptor.API.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BodySculptorDbContext : IdentityDbContext<User>
    {
        public BodySculptorDbContext(DbContextOptions<BodySculptorDbContext> options)
            : base(options)
        {
        }

        public new DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<DailyMenu> DailyMenus { get; set; }
        public DbSet<Exercise> Exercises{ get; set; }
        public DbSet<TrainingSession> ExercisesSets{ get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories{ get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<ExercisePractice> ExercisePractices{ get; set; }
        public DbSet<ExerciseExercisePractices> ExerciseExercisePractices { get; set; }
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
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MuscleGroupExercises>()
                .HasOne(x => x.MuscleGroup)
                .WithMany(x => x.SecondaryMuscleGroupExercises)
                .HasForeignKey(x => x.MuscleGroupId);

            builder.Entity<MuscleGroupExercises>()
                .HasKey(x => new { x.ExerciseId, x.MuscleGroupId });
        }
    }
}
