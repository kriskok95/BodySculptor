namespace BodySculptor.Nutrition.Data
{
    using BodySculptor.Common.Data;
    using BodySculptor.Nutrition.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class NutritionDbContext : MessageDbContext
    {
        public NutritionDbContext(DbContextOptions<NutritionDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<DailyMenu> DailyMenus { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
