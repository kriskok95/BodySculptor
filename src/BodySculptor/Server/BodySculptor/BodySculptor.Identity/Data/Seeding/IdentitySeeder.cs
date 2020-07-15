namespace BodySculptor.Identity.Data.Seeding
{
    using BodySculptor.Common.Constants;
    using BodySculptor.Common.Data.Seeding;
    using BodySculptor.Identity.Data.Entities;
    using BodySculptor.Identity.Models.Identity;
    using BodySculptor.Identity.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class IdentitySeeder : ISeeder<IdentityDbContext>
    {
        public async Task SeedAsync(IdentityDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var exerciseRegisterService = serviceProvider.GetRequiredService<IExercisesRegisterService>();
            var nutritionRegisterService = serviceProvider.GetRequiredService<INutritionRegisterService>();

            await SeedRoleAsync(roleManager, userManager, exerciseRegisterService, nutritionRegisterService, UsersConstants.AdministratorRole);
        }

        private static async Task SeedRoleAsync(
            RoleManager<IdentityRole> roleManager
            , UserManager<User> userManager
            , IExercisesRegisterService exerciseRegisterService
            , INutritionRegisterService nutritionRegisterService
            , string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }

            if (!await userManager.Users.AnyAsync())
            {
                var user = new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                var password = "123456";

                var result = await userManager.CreateAsync(user, password);

                await nutritionRegisterService.Register(new RegisterNutritionUserInputModel { UserId = user.Id});
                await exerciseRegisterService.Register(new RegisterExerciseUserInputModel { UserId = user.Id });

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, UsersConstants.AdministratorRole);
                }
            }
        }
    }
}
