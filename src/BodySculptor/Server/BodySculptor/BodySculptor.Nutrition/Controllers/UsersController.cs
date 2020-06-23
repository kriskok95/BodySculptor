namespace BodySculptor.Nutrition.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Nutrition.Constants;
    using BodySculptor.Nutrition.Models.Users;
    using BodySculptor.Nutrition.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class UsersController : ApiController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserInputModel input)
        {
            if (await this.usersService.IsUserExists(input.UserId))
            {
                return BadRequest(string.Format(UsersConstants.UserAlreadyExists, input.UserId));
            }

            var result = await this.usersService
                .RegisterUser(input.UserId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }
    }
}
