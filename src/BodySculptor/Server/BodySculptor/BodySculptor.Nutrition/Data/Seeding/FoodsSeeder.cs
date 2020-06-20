namespace BodySculptor.Nutrition.Data.Seeding
{
    using BodySculptor.Common.Data.Seeding;
    using BodySculptor.Nutrition.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class FoodsSeeder : ISeeder<NutritionDbContext>
    {
        public async Task SeedAsync(NutritionDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Foods.AnyAsync())
            {
                return;
            }

            //Vegetales
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 1, Name = "Beans", Calories = 35, Proteins = 1.89M, Carbs = 7.88M, Fats = 0.28M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 1, Name = "Broccoli", Calories = 34, Proteins = 2.82M, Carbs = 6.64M, Fats = 0.37M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 1, Name = "Peas", Calories = 42, Proteins = 2.80M, Carbs = 7.20M, Fats = 0.30M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 1, Name = "Beans", Calories = 35, Proteins = 1.89M, Carbs = 7.88M, Fats = 0.28M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 1, Name = "Mushrooms", Calories = 15, Proteins = 2.10M, Carbs = 0.50M, Fats = 0.50M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 1, Name = "Tomatoes", Calories = 18, Proteins = 0.95M, Carbs = 4.01M, Fats = 0.11M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 1, Name = "Cabbage", Calories = 15, Proteins = 2.10M, Carbs = 0.50M, Fats = 0.50M });

            //Fruits
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 2, Name = "Pineapple", Calories = 50, Proteins = 0.54M, Carbs = 13.12M, Fats = 0.12M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 2, Name = "Apple", Calories = 52, Proteins = 0.26M, Carbs = 13.81M, Fats = 0.17M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 2, Name = "Blueberies", Calories = 57, Proteins = 0, Carbs = 18.85M, Fats = 0.16M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 2, Name = "Grapefruit", Calories = 33, Proteins = 0.69M, Carbs = 8.41M, Fats = 0.10M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 2, Name = "Grapes", Calories = 57, Proteins = 0.81M, Carbs = 13.93M, Fats = 0.47M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 2, Name = "Peaches", Calories = 39, Proteins = 0.91M, Carbs = 9.54M, Fats = 0.25M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 2, Name = "Cherries", Calories = 63, Proteins = 1.06M, Carbs = 16.01M, Fats = 0.20M });

            //Grains, Beans and Nuts
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 3, Name = "Almonds", Calories = 579, Proteins = 21.15M, Carbs = 21.55M, Fats = 49.93M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 3, Name = "Cashew", Calories = 552, Proteins = 18.22M, Carbs = 30.19M, Fats = 43.85M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 3, Name = "Walnuts", Calories = 654, Proteins = 15.23M, Carbs = 13.71M, Fats = 65.21M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 3, Name = "Sesame", Calories = 567, Proteins = 16.96M, Carbs = 26.04M, Fats = 48M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 3, Name = "Buckwheat", Calories = 359, Proteins = 13M, Carbs = 68M, Fats = 3M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 3, Name = "Oat Flakes", Calories = 87, Proteins = 3M, Carbs = 15M, Fats = 1.70M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 3, Name = "Rice", Calories = 336, Proteins = 6M, Carbs = 78M, Fats = 2.20M });

            //Meat and seafoods
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 4, Name = "Stack", Calories = 259, Proteins = 25.58M, Carbs = 0M, Fats = 16.61M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 4, Name = "Ham", Calories = 126, Proteins = 16.60M, Carbs = 0M, Fats = 6.20M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 4, Name = "Beef", Calories = 212, Proteins = 33.36M, Carbs = 0M, Fats = 6.67M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 4, Name = "Lamb", Calories = 134, Proteins = 20.29M, Carbs = 0M, Fats = 5.25M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 4, Name = "Chicken", Calories = 125, Proteins = 20.08M, Carbs = 0M, Fats = 4.31M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 4, Name = "Trout", Calories = 148, Proteins = 20.77M, Carbs = 0M, Fats = 6.61M });

            //Dairy Foods and Eggs
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 5, Name = "Curd", Calories = 132, Proteins = 18.70M, Carbs = 3.70M, Fats = 4.70M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 5, Name = "Yoghurt", Calories = 56, Proteins = 5.73M, Carbs = 7.68M, Fats = 0.18M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 5, Name = "Butter", Calories = 717, Proteins = 0.85M, Carbs = 0.06M, Fats = 81.11M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 5, Name = "Milk", Calories = 134, Proteins = 6.81M, Carbs = 10.04M, Fats = 7.56M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 5, Name = "Cheese", Calories = 264, Proteins = 22M, Carbs = 16M, Fats = 17M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 5, Name = "Eggs", Calories = 185, Proteins = 12.81M, Carbs = 1.45M, Fats = 13.77M });

            //Drinks
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 6, Name = "Coca Cola", Calories = 42, Proteins = 2.15M, Carbs = 10.405M, Fats = 3.44M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 6, Name = "Beer", Calories = 43, Proteins = 0.46M, Carbs = 3.55M, Fats = 0M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 6, Name = "White Wine", Calories = 82, Proteins = 0.06M, Carbs = 3.12M, Fats = 0M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 6, Name = "Red Wine", Calories = 11, Proteins = 0.07M, Carbs = 2.62M, Fats = 0M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 6, Name = "Coffee", Calories = 2, Proteins = 0.20M, Carbs = 0.30M, Fats = 0M });

            //Fast Foods
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 7, Name = "Burger Whoopper", Calories = 234, Proteins = 15.47M, Carbs = 11.55M, Fats = 13.94M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 7, Name = "KFC Chicken", Calories = 209, Proteins = 16.15M, Carbs = 8.46M, Fats = 12.31M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 7, Name = "Mcdonald's potatoes", Calories = 295, Proteins = 4M, Carbs = 36M, Fats = 15M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 7, Name = "Cheesburger", Calories = 251, Proteins = 13M, Carbs = 25M, Fats = 11M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 7, Name = "Starbucks sandwich", Calories = 272, Proteins = 11.27M, Carbs = 28.17M, Fats = 12.68M });
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 7, Name = "Subway sandwich", Calories = 159, Proteins = 12M, Carbs = 15.20M, Fats = 5.60M });

            //Other foods
            await dbContext.Foods.AddAsync(new Food { FoodCategoryId = 8, Name = "Nutrim Mix protein bar", Calories = 305, Proteins = 36M, Carbs = 29M, Fats = 5M });
        }
    }
}
