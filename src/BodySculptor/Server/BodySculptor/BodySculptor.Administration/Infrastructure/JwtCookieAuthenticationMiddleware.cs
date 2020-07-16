namespace BodySculptor.Administration.Infrastructure
{
    using BodySculptor.Common.Constants;
    using BodySculptor.Common.Services.Intefraces;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class JwtCookieAuthenticationMiddleware : IMiddleware
    {
        private readonly ICurrentTokenService currentToken;

        public JwtCookieAuthenticationMiddleware(ICurrentTokenService currentToken)
            => this.currentToken = currentToken;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Cookies[InfrastructureConstants.AuthenticationCookieName];

            if (token != null)
            {
                this.currentToken.Set(token);

                context.Request.Headers.Append(InfrastructureConstants.AuthorizationHeaderName, $"{InfrastructureConstants.AuthorizationHeaderValuePrefix} {token}");
            }

            await next.Invoke(context);
        }
    }

    public static class JwtCookieAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtCookieAuthentication(
            this IApplicationBuilder app)
            => app
                .UseMiddleware<JwtCookieAuthenticationMiddleware>()
                .UseAuthentication();
    }
}
