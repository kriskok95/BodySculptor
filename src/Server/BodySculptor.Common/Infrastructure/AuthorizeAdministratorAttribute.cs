namespace BodySculptor.Common.Infrastructure
{
    using BodySculptor.Common.Constants;
    using Microsoft.AspNetCore.Authorization;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = UsersConstants.AdministratorRole;
    }
}
