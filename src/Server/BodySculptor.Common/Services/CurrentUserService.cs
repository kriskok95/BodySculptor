namespace BodySculptor.Common.Services
{
    using BodySculptor.Common.Constants;
    using BodySculptor.Common.Services.Intefraces;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Security.Claims;

    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if(user == null)
            {
                throw new InvalidOperationException(UsersConstants.NotAuthenticatedUser);
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
