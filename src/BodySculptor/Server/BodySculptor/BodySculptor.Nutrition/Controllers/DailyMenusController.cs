namespace BodySculptor.Nutrition.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Common.Services.Intefraces;
    using BodySculptor.Nutrition.Constants;
    using BodySculptor.Nutrition.Models.DailyMenus;
    using BodySculptor.Nutrition.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class DailyMenusController : ApiController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDailyMenusService dailyMenusService;
        private readonly IUsersService usersService;

        public DailyMenusController(ICurrentUserService currentUserService
            , IDailyMenusService dailyMenusService
            , IUsersService usersService)
        {
            this.currentUserService = currentUserService;
            this.dailyMenusService = dailyMenusService;
            this.usersService = usersService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetByUser()
        {
            var userId = this.currentUserService.UserId;

            var isUserExists = await this.usersService.IsUserExists(userId);

            if (!isUserExists)
            {
                return BadRequest(string.Format(UsersConstants.UserNotExists, userId));
            }

            var result = await this.dailyMenusService
                .GetDailyMenusByUser(userId);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(CreateDailyMenuInputModel input)
        {
            var userId = this.currentUserService.UserId;

            var isUserExists = await this.usersService.IsUserExists(userId);

            if (!isUserExists)
            {
                return BadRequest(string.Format(UsersConstants.UserNotExists, userId));
            }

            var isDailyMenuByDateExists = await this.dailyMenusService
                .CheckIfDailyMenuExistsByDate(userId, input.Date?? DateTime.UtcNow);

            if (isDailyMenuByDateExists)
            {
                return BadRequest(string.Format(FoodsConstants.DailyMenuExistsByDate, userId, input.Date?.ToString("MM/dd/yyyy")));
            }

            var result = await this.dailyMenusService.CreateDailyMenu(userId, input);

            return Ok(result);
        }
    }
}
