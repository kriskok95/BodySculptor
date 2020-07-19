namespace BodySculptor.Statistics.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Statistics.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AdministrationStatisticsController : ApiController
    {
        private readonly IAdministraionStatisticsService administraionStatisticsService;

        public AdministrationStatisticsController(IAdministraionStatisticsService administraionStatisticsService)
        {
            this.administraionStatisticsService = administraionStatisticsService;
        }

        [HttpGet]
        [AuthorizeAdministrator]
        public async Task<ActionResult> Get()
        {
            var administrationStatistics = await this.administraionStatisticsService
                .GetAdministrationStatisticsAsync();

            return Ok(administrationStatistics);
        }

    }
}
