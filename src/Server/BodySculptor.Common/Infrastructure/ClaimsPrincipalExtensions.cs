namespace BodySculptor.Common.Infrastructure
{
    using BodySculptor.Common.Constants;
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
            => user.IsInRole(UsersConstants.AdministratorRole);
    }
}
