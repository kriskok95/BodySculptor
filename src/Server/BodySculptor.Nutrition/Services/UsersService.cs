namespace BodySculptor.Nutrition.Services
{
    using BodySculptor.Common.Services;
    using BodySculptor.Nutrition.Constants;
    using BodySculptor.Nutrition.Data;
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Nutrition.Models.Users;
    using BodySculptor.Nutrition.Services.Interfaces;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsersService : IUsersService
    {
        private readonly NutritionDbContext context;

        public UsersService(NutritionDbContext context)
        {
            this.context = context;
        }

        public async Task<Result<UserDto>> RegisterUser(string userId)
        {
            if (await context.Users.AnyAsync(x => x.UserId == userId))
            {
                return Result<UserDto>.Failure(new List<string> { string.Format(UsersConstants.UserAlreadyExists, userId) });
            }

            var user = new User
            {
                UserId = userId
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            var userToReturn = user
                .MapTo<UserDto>();

            return Result<UserDto>.SuccessWith(userToReturn);
        }

        public async Task<bool> IsUserExists(string userId)
        {
            return await context.Users.AnyAsync(x => x.UserId == userId) == true;
        }
    }
}
