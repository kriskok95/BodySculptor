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
        private readonly ApplicationSettings appSettings;
        private readonly IIdentityService identityService;
        private readonly IExercisesRegisterService exercisesRegisterService;
        private readonly INutritionRegisterService nutritionRegisterService;

        public IdentityController(
            UserManager<User> userManager
            , IOptions<ApplicationSettings> appSettings
            , IIdentityService identityService
            , IExercisesRegisterService exercisesRegisterService
            , INutritionRegisterService nutritionRegisterService)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
            this.exercisesRegisterService = exercisesRegisterService;
            this.nutritionRegisterService = nutritionRegisterService;
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

            var nutritionInputModel = new RegisterNutritionUserInputModel { UserId = result.Data.Id };
            var exerciseUserInputModel = new RegisterExerciseUserInputModel { UserId = result.Data.Id };

            await this.nutritionRegisterService.Register(nutritionInputModel);
            await this.exercisesRegisterService.Register(exerciseUserInputModel);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginRequestModel model)
        {
            var isValidCredentials = await this.identityService
                .CheckCredentials(model);

            if (!isValidCredentials.Succeeded)
            {
                return Unauthorized(isValidCredentials.Errors);
            }

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
