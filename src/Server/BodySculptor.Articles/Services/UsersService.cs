namespace BodySculptor.Articles.Services
{
    using BodySculptor.Articles.Data;
    using BodySculptor.Articles.Data.Entities;
    using BodySculptor.Articles.Models.Users;
    using BodySculptor.Articles.Services.Interfaces;
    using BodySculptor.Common.Constants;
    using BodySculptor.Common.Services;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsersService : IUsersService
    {
        private readonly ArticlesDbContext context;

        public UsersService(ArticlesDbContext context)
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
