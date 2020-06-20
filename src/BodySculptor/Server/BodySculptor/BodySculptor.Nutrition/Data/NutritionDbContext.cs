namespace BodySculptor.Nutrition.Data
{
    using BodySculptor.Nutrition.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class NutritionDbContext : DbContext
    {
        public NutritionDbContext(DbContextOptions<NutritionDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<DailyMenu> DailyMenus { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
