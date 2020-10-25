namespace BodySculptor.Administration.Controllers
{
    using BodySculptor.Administration.Models.Identity;
    using BodySculptor.Administration.Services.Interfaces;
    using BodySculptor.Common.Constants;
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Services.Mapping;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class IdentityController : AdministrationController
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            return await this.Handle(
                async () =>
                {
                    try
                    {
                        var loginModel = model.MapTo<UserInputModel>();

                        var result = await this.identityService
                        .Login(loginModel);
                        this.Response.Cookies.Append(
                        InfrastructureConstants.AuthenticationCookieName,
                        result.Content.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = false,
                            MaxAge = TimeSpan.FromDays(1)
                        });
                    }
                    catch (Exception ex)
                    {
                        ;
                        throw;
                    }
                },
                success: RedirectToAction(nameof(HomeController.Index), "Home"),
                failure: View("../Home/Index", model));
        }

        [AuthorizeAdministrator]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete(InfrastructureConstants.AuthenticationCookieName);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
