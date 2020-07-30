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

        [HttpGet("{date}", Name = "GetDailyMenuByUserAndDate")]
        [Authorize]
        public async Task<ActionResult> GetByUserAndDate(DateTime date)
        {
            var userId = this.currentUserService.UserId;

            var isUserExists = await this.usersService.IsUserExists(userId);

            if (!isUserExists)
            {
                return BadRequest(string.Format(UsersConstants.UserNotExists, userId));
            }

            var result = await this.dailyMenusService
                .GetDailyMenuByUserAndDate(userId, date);

            if(result == null)
            {
                return NotFound(string.Format(FoodsConstants.DailyMenuDoesntExistsByDate, userId, date.ToString("MM/dd/yyyy")));
            }

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

            return CreatedAtRoute("GetDailyMenuByUserAndDate",
                new { date = input.Date },
                result);
        }

        [HttpPut]
        [Authorize]
        [Route("{dailyMenuId}")]
        public async Task<ActionResult> Edit(int dailyMenuId, EditDailyMenuInputModel input)
        {
            var userId = this.currentUserService.UserId;

            var isUserExists = await this.usersService.IsUserExists(userId);

            if (!isUserExists)
            {
                return BadRequest(string.Format(UsersConstants.UserNotExists, userId));
            }

            var isDailyMenuExists = await this.dailyMenusService
                .IsDailyMenuExists(dailyMenuId);

            if (!isDailyMenuExists)
            {
                return BadRequest(string.Format(FoodsConstants.DailyMenuDoesntExistsById, dailyMenuId));
            }

            var isDailyMenuExistsByUser = await this.dailyMenusService
                .IsDailyMenuExistsByUser(userId, dailyMenuId);

            if (!isDailyMenuExistsByUser)
            {
                return BadRequest(string.Format(FoodsConstants.DailyMenuDoesntExistsByUser, userId, dailyMenuId));
            }

            var result = await this.dailyMenusService
                .EditDailyMenu(userId, dailyMenuId, input);

            return Ok(result);
        }

        [HttpDelete]
        [Authorize]
        [Route("{dailyMenuId}")]
        public async Task<ActionResult> Delete(int dailyMenuId)
        {
            var userId = this.currentUserService.UserId;

            var isUserExists = await this.usersService.IsUserExists(userId);

            if (!isUserExists)
            {
                return BadRequest(string.Format(UsersConstants.UserNotExists, userId));
            }

            var isDailyMenuExistsByUser = await this.dailyMenusService
               .IsDailyMenuExistsByUser(userId, dailyMenuId);

            if (!isDailyMenuExistsByUser)
            {
                return BadRequest(string.Format(FoodsConstants.DailyMenuDoesntExistsByUser, userId, dailyMenuId));
            }

            await this.dailyMenusService
                .DeleteDailyMenu(userId, dailyMenuId);

            return NoContent();
        }
    }
}
