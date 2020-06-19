namespace BodySculptor.Identity.Controllers
{
    using BodySculptor.Common;
    using BodySculptor.Common.Controllers;
    using BodySculptor.Identity.Data.Entities;
    using BodySculptor.Identity.Models.Identity;
    using BodySculptor.Identity.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;
        private readonly IIdentityService identityService;

        public IdentityController(
            UserManager<User> userManager
            , IOptions<AppSettings> appSettings
            , IIdentityService identityService)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRquestModel userModel)
        {
            var result = await this.identityService
                .Register(userModel);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginRequestModel model)
        {
            var result = await this.identityService
                .Login(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);

            }

            return new LoginOutputModel(result.Data.Token);
        }
    }
}
