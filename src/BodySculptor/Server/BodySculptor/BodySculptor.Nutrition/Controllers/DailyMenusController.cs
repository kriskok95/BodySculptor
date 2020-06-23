namespace BodySculptor.Nutrition.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Nutrition.Models.DailyMenus;
    using BodySculptor.Nutrition.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class DailyMenusController : ApiController
    {
        private readonly IDailyMenusService dailyMenusService;

        public DailyMenusController(IDailyMenusService dailyMenusService)
        {
            this.dailyMenusService = dailyMenusService;
        }

        public async Task<ActionResult> CreateDailyMenu(CreateDailyMenuInputModel input)
        {
            await this.dailyMenusService.CreateDailyMenu(input);

            return Ok();
        }
    }
}
