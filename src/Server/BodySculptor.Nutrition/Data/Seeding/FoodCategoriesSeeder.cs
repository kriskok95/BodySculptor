namespace BodySculptor.Nutrition.Data.Seeding
{
    using BodySculptor.Common.Data.Seeding;
    using BodySculptor.Nutrition.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class FoodCategoriesSeeder : ISeeder<NutritionDbContext>
    {
        public async Task SeedAsync(NutritionDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.FoodCategories.AnyAsync())
            {
                return;
            }

            await dbContext.FoodCategories.AddAsync(new FoodCategory { CreatedOn = DateTime.UtcNow, Name = "Vegetables" });
            await dbContext.FoodCategories.AddAsync(new FoodCategory { CreatedOn = DateTime.UtcNow, Name = "Fruits" });
            await dbContext.FoodCategories.AddAsync(new FoodCategory { CreatedOn = DateTime.UtcNow, Name = "Grains, Beans and Nuts" });
            await dbContext.FoodCategories.AddAsync(new FoodCategory { CreatedOn = DateTime.UtcNow, Name = "Meat, Seafoods and Poultry" });
            await dbContext.FoodCategories.AddAsync(new FoodCategory { CreatedOn = DateTime.UtcNow, Name = "Dairy Foods and Eggs" });
            await dbContext.FoodCategories.AddAsync(new FoodCategory { CreatedOn = DateTime.UtcNow, Name = "Drinks" });
            await dbContext.FoodCategories.AddAsync(new FoodCategory { CreatedOn = DateTime.UtcNow, Name = "Fast Foods" });
            await dbContext.FoodCategories.AddAsync(new FoodCategory { CreatedOn = DateTime.UtcNow, Name = "Other Foods" });
        }
    }
}
