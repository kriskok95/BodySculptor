namespace BodySculptor.Articles.Controllers
{
    using BodySculptor.Articles.Models.Users;
    using BodySculptor.Articles.Services.Interfaces;
    using BodySculptor.Common.Constants;
    using BodySculptor.Common.Controllers;
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
            if (await usersService.IsUserExists(input.UserId))
            {
                return BadRequest(string.Format(UsersConstants.UserAlreadyExists, input.UserId));
            }

            var result = await usersService
                .RegisterUser(input.UserId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }
    }
}
