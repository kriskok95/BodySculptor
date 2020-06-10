namespace BodySculptor.API.Data.Seeding
{
    using BodySculptor.API.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class FoodCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(BodySculptorDbContext dbContext, IServiceProvider serviceProvider)
        {
            if(await dbContext.FoodCategories.AnyAsync())
            {
                return;
            }

            await dbContext.FoodCategories.AddAsync(new FoodCategory { CreatedOn = DateTime.UtcNow, Name = "Vegetables"});
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
