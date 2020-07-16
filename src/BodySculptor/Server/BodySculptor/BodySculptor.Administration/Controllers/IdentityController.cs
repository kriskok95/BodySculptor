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
    using System.Threading.Tasks;

    public class IdentityController : AdministrationController
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            return await this.Handle(
                async () =>
                {
                    var result = await this.identityService
                        .Login(model.MapTo<UserInputModel>());

                    this.Response.Cookies.Append(
                        InfrastructureConstants.AuthenticationCookieName,
                        result.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            MaxAge = TimeSpan.FromDays(1)
                        });
                },
                success: RedirectToAction(nameof(ExercisesController.Index), "Exercises"),
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
